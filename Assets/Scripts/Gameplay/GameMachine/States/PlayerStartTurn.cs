namespace Gameplay.GameMachine.States
{
  public class PlayerStartTurn : GameplayState
  {
    public PlayerStartTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine) : base(pvpGameStateMachine, stateMachine)
    {
    }
    
   
    public override void Enter()
    {
      base.Enter();
     
    }
    
  }
}