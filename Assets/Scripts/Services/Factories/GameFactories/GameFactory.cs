using Services.Assets;
using Services.Progress;
using Services.StaticData;
using Services.UI.Buttons;
using Services.UI.Windows;
using UnityEngine;

namespace Services.Factories.GameFactories
{
  public class GameFactory : IGameFactory
  {
    private readonly IAssetProvider assets;
    private readonly IStaticDataService staticData;
    private readonly IWindowsService windowsService;
    private readonly IPersistentProgressService progressService;
    private GameObject heroGameObject;

    public GameFactory(IAssetProvider assets,
      IStaticDataService staticData,
      IWindowsService windowsService,
      IPersistentProgressService progressService)
    {
      this.assets = assets;
      this.staticData = staticData;
     
      this.windowsService = windowsService;
      this.progressService = progressService;
    }
    
    public GameObject CreateHero()
    {
     
      return heroGameObject;
    }

    public GameObject CreateHud(GameObject hero)
    {
      
      return null;
    }

    private void InitButtons(GameObject hud)
    {
      OpenWindowButton[] buttons = hud.GetComponentsInChildren<OpenWindowButton>(true);
      for (int i = 0; i < buttons.Length; i++)
      {
        buttons[i].Construct(windowsService);
      }
    }
    
    private GameObject InstantiateObject(GameObject prefab, Vector3 at) => 
      assets.Instantiate(prefab, at);
  }
}