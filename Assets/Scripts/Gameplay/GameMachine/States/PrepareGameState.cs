namespace Gameplay.GameMachine.States
{
    public class PrepareGameState : GameplayState
    {
        public PrepareGameState(GameplayStateMachine gameplayStateMachine, StateMachine stateMachine) : base(gameplayStateMachine, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            CreateField();
            SpawnFirstCards();
            SpawnPlayerDeck();
            StartPlayerTurn();
        }

        private void CreateField() => 
            gameplay.CreateField();

        private void SpawnFirstCards() => 
            gameplay.SpawnFirstOpponentsCard();

        private void SpawnPlayerDeck() => 
            gameplay.SpawnPlayerDeckProps();

        private void StartPlayerTurn() => 
            stateMachine.ChangeState(gameplay.PlayerStartTurnState);
    }
}
