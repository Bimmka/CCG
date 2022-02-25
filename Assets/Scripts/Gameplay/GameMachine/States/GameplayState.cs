namespace Gameplay.GameMachine.States
{
  public abstract class GameplayState : GameState
  {
    protected readonly GameplayStateMachine gameplay;


    protected GameplayState(GameplayStateMachine gameMachine, StateMachine stateMachine) : base(stateMachine)
    {
      gameplay = gameMachine;
    }
  }
}
