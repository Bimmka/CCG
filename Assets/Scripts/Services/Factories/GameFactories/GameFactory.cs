using ConstantsValue;
using Services.Assets;
using Services.Hero;
using Services.Progress;
using Services.StaticData;
using Services.UI.Buttons;
using Services.UI.Windows;
using UI.Displaying;
using UnityEngine;

namespace Services.Factories.GameFactories
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider assets;
    private readonly IStaticDataService staticData;
    private readonly IWindowsService windowsService;
    private readonly IPlayerGold playerGold;
    private GameObject heroGameObject;

    public GameFactory(IAssetProvider assets,
      IStaticDataService staticData,
      IWindowsService windowsService,
      IPlayerGold playerGold)
    {
      this.assets = assets;
      this.staticData = staticData;
     
      this.windowsService = windowsService;
      this.playerGold = playerGold;
    }
    
    public GameObject CreateHero()
    {
     
      return heroGameObject;
    }

    public GameObject CreateHud(GameObject hero, Transform uiRoot)
    {
      GameObject hud = InstantiateObject(AssetsPath.Hud, uiRoot);
      InitGoldDisplayer(hud.GetComponentInChildren<GoldDisplayer>(true), playerGold);
      InitButtons(hud);
      return hud;
    }

    private void InitGoldDisplayer(GoldDisplayer goldDisplayer, IPlayerGold playerGold)
    {
      goldDisplayer.Construct(playerGold);
    }

    private void InitButtons(GameObject hud)
    {
      OpenWindowButton[] buttons = hud.GetComponentsInChildren<OpenWindowButton>(true);
      for (int i = 0; i < buttons.Length; i++)
      {
        buttons[i].Construct(windowsService);
      }
    }
    
    private GameObject InstantiateObject(string path, Transform parent) => 
      assets.Instantiate<GameObject>(path, parent);
  }
}