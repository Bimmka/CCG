using Services.UI.Factory;
using Services.UI.Windows;
using UnityEngine;

namespace Gameplay.GameMachine.States
{
  public class GameEnd : GameplayState
  {
    private readonly IWindowsService windowsService;

    public GameEnd(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine, IWindowsService windowsService) : base(pvpGameStateMachine, stateMachine)
    {
      this.windowsService = windowsService;
    }

    public override void Enter()
    {
      base.Enter();
      Debug.Log("Game End");
      windowsService.Open(WindowId.DeathMenu);
    }
  }
}