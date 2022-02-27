using Gameplay.Clicks;
using Services.UI.Factory;
using Services.UI.Windows;
using UnityEngine;
using Zenject;

namespace UI.Windows.PauseMenu
{
  public class PauseMenuObserver : MonoBehaviour
  {
    [SerializeField] private PlayerClickHandler clickHandler;
        
    private bool isPause;
        
    private IWindowsService windowsService;

    [Inject]
    private void Construct(IWindowsService windowsService)
    {
      this.windowsService = windowsService;
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        if (isPause)
        {
          CloseMenu();
          clickHandler.ContinueClick();
        }
        else
        {
          OpenMenu();
          clickHandler.StopClick();
        }

        isPause = !isPause;
      }
                
    }

    private void CloseMenu()
    {
      windowsService.Close(WindowId.PauseMenu);
    }

    private void OpenMenu()
    {
      windowsService.Open(WindowId.PauseMenu);
    }
  }
}