using Gameplay.Cards.Hand;

namespace Gameplay.GameMachine.States
{
  public class PlayerStartTurn : GameplayState
  {
    private readonly GameplayPlayerHand playerHand;

    public PlayerStartTurn(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine,
      GameplayPlayerHand playerHand) : base(pvpGameStateMachine, stateMachine)
    {
      this.playerHand = playerHand;
    }
    
   
    public override void Enter()
    {
      base.Enter();
      if (playerHand.IsCanCollectCards())
      {
        playerHand.CollectCards();
        stateMachine.ChangeState(gameplay.PlayerTurnState);
      }
    }
    
  }
}