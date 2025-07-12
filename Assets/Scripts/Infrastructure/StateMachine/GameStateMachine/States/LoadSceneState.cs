using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.LowLevel;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States
{
    public class LoadSceneState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly Scenes _scenes;

        public LoadSceneState(GameStateMachine gameStateMachine, Scenes scenes)
        {
            _gameStateMachine = gameStateMachine;
            _scenes = scenes;
        }
        
        public void Enter()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            
            if (currentScene != _scenes.Bootstrap)
            {
                if (currentScene == _scenes.Battle)
                    _gameStateMachine.Enter<BattleState>();
                else
                    _gameStateMachine.Enter<MetaState>();
            }
            else
            {
                _gameStateMachine.Enter<MetaState>();
            }
        }

        public void Exit()
        {
            
        }
    }
}