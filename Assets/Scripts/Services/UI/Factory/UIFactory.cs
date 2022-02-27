using System;
using ConstantsValue;
using GameStates;
using Services.Assets;
using Services.Audio;
using Services.Hero;
using Services.Progress;
using Services.StaticData;
using StaticData.UI;
using UI.Base;
using UI.Windows;
using UI.Windows.LooseMenu;
using UI.Windows.MainMenu;
using UnityEngine;

namespace Services.UI.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly IGameStateMachine gameStateMachine;
    private readonly IAssetProvider assets;
    private readonly IStaticDataService staticData;

    private Transform uiRoot;

    private Camera mainCamera;
    private IPlayerGold playerGold;
    private readonly IPlayerTurns playerTurns;
    private readonly IAudioServiceSettings audioSettings;

    public Transform UIRoot => uiRoot;
    public event Action<WindowId,BaseWindow> Spawned;


    public UIFactory(IGameStateMachine gameStateMachine,
      IAssetProvider assets,
      IStaticDataService staticData, 
      IPlayerGold playerGold,
      IPlayerTurns playerTurns,
      IAudioServiceSettings audioSettings)
    {
      this.gameStateMachine = gameStateMachine;
      this.assets = assets;
      this.staticData = staticData;
      this.playerGold = playerGold;
      this.playerTurns = playerTurns;
      this.audioSettings = audioSettings;
    }

    public void CreateUIRoot()
    {
      uiRoot = assets.Instantiate<GameObject>(AssetsPath.UIRootPath).transform;
      uiRoot.GetComponent<UIRoot>().SetCamera(GetCamera());
    }

    public void CreateWindow(WindowId id)
    {
      WindowInstantiateData config = LoadWindowInstantiateData(id);
      switch (id)
      {
        case WindowId.MainMenu:
          CreateMainMenuWindow(config, id, gameStateMachine);
          break;
        case WindowId.DeathMenu:
          CreateDeathMenuWindow(config, id, gameStateMachine, playerTurns);
          break;
        case WindowId.Settings:
          CreateSettingsWindow(config, id, audioSettings);
          break;
        default:
          CreateWindow(config, id);
          break;
      }
    }

    private void CreateMainMenuWindow(WindowInstantiateData config, WindowId id, IGameStateMachine stateMachine)
    {
      BaseWindow window = InstantiateWindow(config);
      ((UIMainMenu) window).Construct(stateMachine);
      NotifyAboutCreateWindow(id, window);
    }

    private void CreateDeathMenuWindow(WindowInstantiateData config, WindowId id, IGameStateMachine stateMachine, IPlayerTurns turns)
    {
      BaseWindow window = InstantiateWindow(config);
      ((UIDeathMenu) window).Construct(stateMachine, turns);
      NotifyAboutCreateWindow(id, window);
    }

    private void CreateSettingsWindow(WindowInstantiateData config, WindowId id, IAudioServiceSettings settings)
    {
      BaseWindow window = InstantiateWindow(config);
      ((UISettingsMenu) window).Construct(settings);
      NotifyAboutCreateWindow(id, window);
    }

    private void CreateWindow(WindowInstantiateData config, WindowId id)
    {
      BaseWindow window = InstantiateWindow(config);
      NotifyAboutCreateWindow(id, window);
    }

    private void NotifyAboutCreateWindow(WindowId id, BaseWindow window) => 
      Spawned?.Invoke(id, window);

    private BaseWindow InstantiateWindow(WindowInstantiateData config) => 
      assets.Instantiate(config.Window, uiRoot);

    private WindowInstantiateData LoadWindowInstantiateData(WindowId id) => 
      staticData.ForWindow(id);

    private Camera GetCamera()
    {
      if (mainCamera == null)
        mainCamera = Camera.main;
      return mainCamera;
    }
  }
}