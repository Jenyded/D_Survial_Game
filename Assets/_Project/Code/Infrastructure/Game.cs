using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States;

namespace _Project.Scripts.Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _gameStateMachine;
    
        public Game(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Launch()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }

        public void Shutdown()
        {
            _gameStateMachine.Enter<ShutdownState>();
        }
    }
}