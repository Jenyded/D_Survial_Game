using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.Services;
using _Project.Scripts.Infrastructure.Services.SceneLoader;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States
{
    public class MetaState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly Scenes _scenes;
        private readonly EntryFinder _entryFinder;

        public MetaState(GameStateMachine gameStateMachine, EntryFinder entryFinder, Scenes scenes,
            ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _entryFinder = entryFinder;
            _scenes = scenes;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(_scenes.Meta, OnLoaded);
        }

        private void OnLoaded()
        {
            _entryFinder.FindEntry<MetaEntry>().Initialize();
        }

        public void Exit()
        {
            
        }
    }
}