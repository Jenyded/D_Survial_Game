using System;
using System.Collections.Generic;
using _Project.Scripts.Infrastructure.Data;
using _Project.Scripts.Infrastructure.Factories;
using _Project.Scripts.Infrastructure.Services;
using _Project.Scripts.Infrastructure.Services.PersistentData;
using _Project.Scripts.Infrastructure.Services.SaveLoad;
using _Project.Scripts.Infrastructure.Services.SceneLoader;
using _Project.Scripts.Infrastructure.Services.WindowsService;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States;
using _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces;
using Services.Interfaces;

namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine
{
    public class GameStateMachine
    {
        private IExitableState _activeState;
        private readonly Dictionary<Type, IExitableState> _states;

       
        public GameStateMachine(EntryFinder entryFinder, IGameFactory gameFactory, Scenes scenes, ISaveLoadService saveLoadService,
            IPersistentDataService persistent, IConfigService configService, ISceneLoader sceneLoader, IWindowsService windowsService)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, scenes, configService, persistent, saveLoadService, windowsService),
                [typeof(LoadSceneState)] = new LoadSceneState(this, scenes),
                [typeof(MetaState)] = new MetaState(this, entryFinder, scenes, sceneLoader),
                [typeof(BattleState)] = new BattleState(this, entryFinder, gameFactory, scenes, sceneLoader),
                [typeof(ShutdownState)] = new ShutdownState(this, saveLoadService)
            };
        }

        public void Enter<TState>() where TState : IState
        {
            IExitableState changedState = ChangeState(_states[typeof(TState)]);

            IState newState = (IState)changedState;
            newState.Enter();
        }

        public void Enter<TState, TParameter>(TParameter value) where TState : IParametricState<TParameter>
        {
            IExitableState changedState = ChangeState(_states[typeof(TState)]);

            IParametricState<TParameter> newState = (IParametricState<TParameter>)changedState;
            newState.Enter(value);
        }

        public void Enter<TState, TParameter, TParameter2>(TParameter value, TParameter2 value2)
            where TState : IParametricState<TParameter, TParameter2>
        {
            IExitableState changedState = ChangeState(_states[typeof(TState)]);

            IParametricState<TParameter, TParameter2> newState = (IParametricState<TParameter, TParameter2>)changedState;
            newState.Enter(value, value2);
        }

        private IExitableState ChangeState(IExitableState newState)
        {
            if (_activeState != null)
                _activeState.Exit();

            _activeState = newState;

            return _activeState;
        }
    }
}

