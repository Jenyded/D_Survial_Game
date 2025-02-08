using System.Collections.Generic;
using Configs;
using Core.Character;

namespace _Project.Scripts.Gameplay.Character
{
    public class CharacterStatus
    {
        public StatusEffect Current => _status;
        
        private StatusEffectDecoratorFactory _statusDecoratorFactory;
        private StatusEffect _status;
        private readonly CharacterConfig _config;
        private readonly List<StatusEffect> _equipmentEffects;
        private readonly List<StatusEffect> _buffEffects;
    
        public CharacterStatus(CharacterConfig config)
        {
            _config = config;
            _equipmentEffects = new();
            _buffEffects = new();
        }

        public void RefreshStatus()
        {
            _status = new CharacterDefaultStatus(_config);
        
            //Add new layers which will modify default values
            _equipmentEffects.ForEach(x => _status = new EquipmentEffect(_status));
            _buffEffects.ForEach(x => _status = new BuffEffect(_status));
        }
    }
    
}