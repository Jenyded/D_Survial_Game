using _Project.Scripts.Gameplay;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
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
        public CharacterStatus CharacterStatus { get; private set; }

        private readonly IAssetProvider _assetProvider;
        private readonly IConfigService _configService;
        private readonly IInputService _inputService;
        private readonly SkillFactory _skillFactory;

        private CharacterConfig _characterConfig;
        private GameObject _character;
        private SkillExecutor _skillExecutor;

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
            CharacterStatus = new CharacterStatus(_characterConfig);
            CharacterStatus.RefreshStatus();

            _character = await _assetProvider.CreateGameObject(_characterConfig.Prefab.AssetGUID);

            StatusHolder statusHolder = _character.AddComponent<StatusHolder>();
            statusHolder.Construct(CharacterStatus);

            CharacterMovement movement = _character.GetComponent<CharacterMovement>();
            movement.Construct(CharacterStatus, _inputService);

            Health health = _character.GetComponent<Health>();
            health.Construct(CharacterStatus);

            HealthBar healthBar = _character.GetComponentInChildren<HealthBar>();
            healthBar.Construct(health);
            
            CharacterShield shield = _character.GetComponent<CharacterShield>();
            shield.Construct(CharacterStatus);

            CharacterAttack attack = _character.GetComponent<CharacterAttack>();
            attack.Construct(CharacterStatus, _characterConfig.AttackSequence);

            CharacterAnimator animator = _character.GetComponent<CharacterAnimator>();
            animator.Construct(_inputService);

            HealthRegeneration healthRegeneration = _character.GetComponent<HealthRegeneration>();
            healthRegeneration.Construct(CharacterStatus);

            TargetDetection targetDetection = _character.GetComponentInChildren<TargetDetection>();
            targetDetection.Initialize();
            
            _skillExecutor = _character.AddComponent<SkillExecutor>();
            _skillExecutor.Construct(_character);

            return _character;
        }
        
        public async UniTask<GameObject> CreateEnemy(EnemyId id)
        {
            EnemyConfig enemyConfig = _configService.ForEnemy(id);
            
            EnemyStatus status = new EnemyStatus(enemyConfig);
            status.RefreshStatus();

            GameObject enemyGameObject = await _assetProvider.CreateGameObject(enemyConfig.Prefab.AssetGUID);

            StatusHolder statusHolder = enemyGameObject.AddComponent<StatusHolder>();
            statusHolder.Construct(status);

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
                useSkillButton.Construct(_skillExecutor, x);
                useSkillButton.Init();
            });

            UseJoystickSkill joystickSkill = hud.GetComponentInChildren<UseJoystickSkill>();
            joystickSkill.GetComponent<Cooldown>().Construct(_characterConfig.JoystickSkill.Cooldown);
            joystickSkill.Construct(_skillExecutor, _characterConfig.JoystickSkill);

            UseSwipeSkill swipeSkill = hud.GetComponentInChildren<UseSwipeSkill>();
            swipeSkill.GetComponent<Cooldown>().Construct(_characterConfig.SwipeSkill.Cooldown);
            swipeSkill.Construct(_skillExecutor, _characterConfig.SwipeSkill, _character);
        }
    }
}