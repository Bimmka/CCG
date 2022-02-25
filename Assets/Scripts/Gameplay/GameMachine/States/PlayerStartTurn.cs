using Gameplay.Cards.Hand;
using Gameplay.Clicks;

namespace Gameplay.GameMachine.States
{
  public class PlayerStartTurn : GameplayState
  {
    private readonly GameplayPlayerHand playerHand;
    private readonly PlayerClickHandler playerClickHandler;

    public PlayerStartTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine,
      GameplayPlayerHand playerHand, PlayerClickHandler playerClickHandler) : base(pvpGameStateMachine, stateMachine)
    {
      this.playerHand = playerHand;
      this.playerClickHandler = playerClickHandler;
    }
    
   
    public override void Enter()
    {
      base.Enter();
      playerHand.CollectCards();
      playerClickHandler.UnlockCLick();
      stateMachine.ChangeState(gameplay.PlayerTurnState);
    }
    
  }
}