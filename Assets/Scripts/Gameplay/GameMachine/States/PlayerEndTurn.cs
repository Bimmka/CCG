using Gameplay.Clicks;
using Gameplay.GameplayActionPipeline;
using Gameplay.Table;

namespace Gameplay.GameMachine.States
{
  public class PlayerEndTurn : GameplayState
  {
    private readonly PlayerClickHandler playerClickHandler;
    private readonly ActionPipeline actionPipeline;
    private readonly Field field;

    public PlayerEndTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine,
      PlayerClickHandler playerClickHandler, ActionPipeline actionPipeline, Field field) : base(pvpGameStateMachine, stateMachine)
    {
      this.playerClickHandler = playerClickHandler;
      this.actionPipeline = actionPipeline;
      this.field = field;
    }

    public override void Enter()
    {
      base.Enter();
      playerClickHandler.LockClick();
      field.UnlockCells();
      actionPipeline.StartPipeline();
    }
    
  }
}