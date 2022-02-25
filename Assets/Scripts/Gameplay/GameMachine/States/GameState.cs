namespace Gameplay.GameMachine.States
{
  public abstract class GameState
  {
    protected readonly StateMachine stateMachine;
    protected GameState(StateMachine stateMachine)
    {
      this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Restore()
    {
    }
  }
}