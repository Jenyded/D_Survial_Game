using _Project.Scripts.Infrastructure.Services.SaveLoad;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States
{
    public class ShutdownState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;

        public ShutdownState(GameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            _saveLoadService.Save();
        }

        public void Exit()
        {
            
        }
    }
}