using Gameplay.GameMachine.States;

namespace Gameplay.GameMachine
{
    public class StateMachine
    {
        private GameState state;

        public GameState State => state;

        private void ExitState() => 
            state.Exit();

        public void Initialize(GameState gameState)
        {
            state = gameState;
            state.Enter();
        }

        public void ChangeState(GameState gameState)
        {
            ExitState();
            Initialize(gameState);
        }
    }
}
