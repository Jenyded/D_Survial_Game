using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        private GameStateMachine _gameStateMachine;
        private Game _game;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void Awake()
        {
            _game = new Game(_gameStateMachine);
            _game.Launch();
            
            DontDestroyOnLoad(gameObject);
        }

        private void OnApplicationQuit()
        {
            _game.Shutdown();
        }
    }
}