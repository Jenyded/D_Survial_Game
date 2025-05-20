uusing _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Enemy;
using _Project.Scripts.Gameplay.Skills;
using _Project.Scripts.Infrastructure.Services.AssetProvider;
using _Project.Scripts.Infrastructure.Services.Input;
using Configs;
using Cysharp.Threading.Tasks;
using Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IConfigService _configService;
        private readonly IInputService _inputService;
        private readonly SkillFactory _skillFactory;

        private CharacterConfig _characterConfig;
        private GameObject _character;

        public GameFactory(IConfigService configService, IAssetProvider assetProvider, IInputService inputService, SkillFactory skillFactory)
        {
            _configService = configService;
            _assetProvider = assetProvider;
            _inputService = inputService;
            _skillFactory = skillFactory;
        }

        public async UniTask<GameObject> CreateCharacter(CharacterId id)
        {
            _characterConfig = _configService.ForCharacter(id);
            CharacterStatus status = new CharacterStatus(_characterConfig);
            status.RefreshStatus();

            _character = await _assetProvider.CreateGameObject(_characterConfig.Prefab.AssetGUID);

            CharacterMovement movement = _character.GetComponent<CharacterMovement>();
            movement.Construct(status, _inputService);

            Health health = _character.GetComponent<Health>();
            health.Construct(status);

            HealthBar healthBar = _character.GetComponentInChildren<HealthBar>();
            healthBar.Construct(health);
            
            CharacterShield shield = _character.GetComponent<CharacterShield>();
            shield.Construct(status);

            CharacterAttack attack = _character.GetComponent<CharacterAttack>();
            attack.Construct(status, _characterConfig.AttackSequence);

            CharacterAnimator animator = _character.GetComponent<CharacterAnimator>();
            animator.Construct(_inputService);

            HealthRegeneration healthRegeneration = _character.GetComponent<HealthRegeneration>();
            healthRegeneration.Construct(status);

            CharacterSkillSet characterSkillSet = _character.GetComponent<CharacterSkillSet>();
            characterSkillSet.Construct(status);

            TargetDetection targetDetection = _character.GetComponentInChildren<TargetDetection>();
            targetDetection.Initialize();

            return _character;
        }
        
        public async UniTask<GameObject> CreateEnemy(EnemyId id)
        {
            EnemyConfig enemyConfig = _configService.ForEnemy(id);
            
            EnemyStatus status = new EnemyStatus(enemyConfig);
            status.RefreshStatus();

            GameObject enemyGameObject = await _assetProvider.CreateGameObject(enemyConfig.Prefab.AssetGUID);

            Health health = enemyGameObject.GetComponent<Health>();
            health.Construct(status);
            
            HealthBar healthBar = enemyGameObject.GetComponentInChildren<HealthBar>();
            healthBar.Construct(health);

            return enemyGameObject;
        }

        public async UniTask CreateHud()
        {
            UIConfig uiConfig = _configService.ForUI();

            GameObject hud = await _assetProvider.CreateGameObject(uiConfig.HudPrefab.AssetGUID);
            
            GridLayoutGroup skillsGrid = hud.GetComponentInChildren<GridLayoutGroup>();
            _characterConfig.Skills.ForEach(async x =>
            {
                GameObject skillButton = await _assetProvider.CreateGameObject(uiConfig.SkillButtonPrefab.AssetGUID, skillsGrid.transform);
                UseSkillButton useSkillButton = skillButton.GetComponent<UseSkillButton>();
                useSkillButton.Construct(_skillFactory.CreateNonTarget(x));
            });

            UseJoystickSkill joystickSkill = hud.GetComponentInChildren<UseJoystickSkill>();
            joystickSkill.GetComponent<Cooldown>().Construct(_characterConfig.JoystickSkill.Cooldown);
            joystickSkill.Construct(_character.transform, _skillFactory.CreateTarget(_characterConfig.JoystickSkill));

            UseSwipeSkill swipeSkill = hud.GetComponentInChildren<UseSwipeSkill>();
            swipeSkill.GetComponent<Cooldown>().Construct(_characterConfig.SwipeSkill.Cooldown);
            swipeSkill.Construct(_skillFactory.CreateDirection(_characterConfig.SwipeSkill), _character);
        }
    }
}
