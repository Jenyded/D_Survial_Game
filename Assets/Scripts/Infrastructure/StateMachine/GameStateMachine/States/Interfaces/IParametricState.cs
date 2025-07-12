namespace _Project.Scripts.Infrastructure.StateMachine.GameStateMachine.States.Interfaces
{
    public interface IParametricState<TParameter> : IExitableState
    {
        void Enter(TParameter parameter);
    }

    public interface IParametricState<TParameter, TParameter2> : IExitableState
    {
        void Enter(TParameter parameter, TParameter2 parameter2);
    }
}