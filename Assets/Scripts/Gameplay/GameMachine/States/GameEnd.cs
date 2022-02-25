using UnityEngine;

namespace Gameplay.GameMachine.States
{
  public class GameEnd : GameplayState
  {
    public GameEnd(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine) : base(pvpGameStateMachine, stateMachine)
    {
    }

    public override void Enter()
    {
      base.Enter();
      Debug.Log("Game End");
    }
  }
}