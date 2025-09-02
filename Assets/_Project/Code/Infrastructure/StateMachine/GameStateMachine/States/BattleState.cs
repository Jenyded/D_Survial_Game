using System.Threading.Tasks;
using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.Services;
using _Project.Scripts.Infrastructure.Services.SceneLoader;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States
{
    public class BattleState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly Scenes _scenes;
        private readonly IGameFactory _gameFactory;
        private readonly EntryFinder _entryFinder;

        public BattleState(GameStateMachine gameStateMachine, EntryFinder entryFinder, IGameFactory gameFactory,
            Scenes scenes, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _entryFinder = entryFinder;
            _gameFactory = gameFactory;
            _scenes = scenes;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(_scenes.Battle, OnLoaded);            
        }

        private void OnLoaded()
        {
            _entryFinder.FindEntry<BattleEntry>().Initialize();
        }

        public void Exit()
        {
            
        }
    }
}
