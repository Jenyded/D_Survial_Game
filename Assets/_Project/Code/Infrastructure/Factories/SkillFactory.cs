using System;
using System.Collections.Generic;
using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay.Skills;
using _Project.Scripts.Gameplay.Skills.Interfaces;
using Services.Interfaces;

namespace _Project.Scripts.Infrastructure.Factories
{

    public class SkillFactory
    {
        private readonly IConfigService _configService;
        private readonly Dictionary<Type, Func<SkillConfig, INonTargetSkill>> _nonTargetSkills;
        private readonly Dictionary<Type, Func<SkillConfig, ITargetSkill>> _targetSkills;
        private readonly Dictionary<Type, Func<SkillConfig, IDirectionSkill>> _directionSkills;
        private StatusEffectFactory _statusEffectFactory;

        public SkillFactory(IConfigService configService, StatusEffectFactory statusEffectFactory)
        {
            _configService = configService;
            _statusEffectFactory = statusEffectFactory;
            _nonTargetSkills = new()
            {
                [typeof(RoarConfig)] = config => new RoarSkill((RoarConfig)config, _statusEffectFactory),
            };

            _targetSkills = new()
            {
                [typeof(HealConfig)] = config => new HealSkill((HealConfig)config),
            };

            _directionSkills = new()
            {
                [typeof(DashConfig)] = config => new DashSkill((DashConfig)config)
            };
        }

        public ITargetSkill CreateTarget(SkillConfig skillConfig)
        {
            ITargetSkill targetSkill = _targetSkills[skillConfig.GetType()].Invoke(skillConfig);

            return targetSkill;
        }
        
        public INonTargetSkill CreateNonTarget(SkillConfig skillConfig)
        {
            INonTargetSkill nonTargetSkill = _nonTargetSkills[skillConfig.GetType()].Invoke(skillConfig);

            return nonTargetSkill;
        }

        public IDirectionSkill CreateDirection(SkillConfig skillConfig)
        {
            IDirectionSkill directionSkill = _directionSkills[skillConfig.GetType()].Invoke(skillConfig);

            return directionSkill;
        }
    }
}