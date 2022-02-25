namespace Gameplay.GameMachine.States
{
  public class PlayerEndTurn : GameplayState
  {
    public PlayerEndTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine) : base(pvpGameStateMachine, stateMachine)
    {
    }

    public override void Enter()
    {
      base.Enter();
      
    }
    
  }
}