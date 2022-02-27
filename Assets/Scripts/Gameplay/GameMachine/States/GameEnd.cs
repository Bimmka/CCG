using Services.Audio;
using Services.UI.Factory;
using Services.UI.Windows;
using UnityEngine;

namespace Gameplay.GameMachine.States
{
  public class GameEnd : GameplayState
  {
    private readonly IWindowsService windowsService;
    private readonly IAudioService audioService;

    public GameEnd(GameplayStateMachine pvpGameStateMachine, StateMachine stateMachine, IWindowsService windowsService,
      IAudioService audioService) : base(pvpGameStateMachine, stateMachine)
    {
      this.windowsService = windowsService;
      this.audioService = audioService;
    }

    public override void Enter()
    {
      base.Enter();
      Debug.Log("Game End");
      audioService.ChangeMainTheme("DeathTheme");
      windowsService.Open(WindowId.DeathMenu);
    }
  }
}