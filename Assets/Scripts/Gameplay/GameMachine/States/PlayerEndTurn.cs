using Gameplay.Clicks;

namespace Gameplay.GameMachine.States
{
  public class PlayerEndTurn : GameplayState
  {
    private readonly PlayerClickHandler playerClickHandler;

    public PlayerEndTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine,
      PlayerClickHandler playerClickHandler) : base(pvpGameStateMachine, stateMachine)
    {
      this.playerClickHandler = playerClickHandler;
    }

    public override void Enter()
    {
      base.Enter();
      playerClickHandler.LockClick();
    }
    
  }
}