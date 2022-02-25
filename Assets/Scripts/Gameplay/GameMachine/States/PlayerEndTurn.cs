using Gameplay.Clicks;
using Gameplay.GameplayActionPipeline;

namespace Gameplay.GameMachine.States
{
  public class PlayerEndTurn : GameplayState
  {
    private readonly PlayerClickHandler playerClickHandler;
    private readonly ActionPipeline actionPipeline;

    public PlayerEndTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine,
      PlayerClickHandler playerClickHandler, ActionPipeline actionPipeline) : base(pvpGameStateMachine, stateMachine)
    {
      this.playerClickHandler = playerClickHandler;
      this.actionPipeline = actionPipeline;
    }

    public override void Enter()
    {
      base.Enter();
      playerClickHandler.LockClick();
      actionPipeline.StartPipeline();
    }
    
  }
}