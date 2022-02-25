namespace Gameplay.GameMachine.States
{
  public class PlayerTurn : GameplayState
  {
    public PlayerTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine) : base(pvpGameStateMachine, stateMachine)
    {
    }

    public override void Enter()
    {
      base.Enter();
      
    }

  }
}