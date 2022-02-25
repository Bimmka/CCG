using System.Collections.Generic;
using System.Linq;
using ConstantsValue;
using Services.UI.Factory;
using StaticData.Gameplay.Table;
using StaticData.UI;
using UnityEngine;

namespace Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, WindowInstantiateData> windows;

    private FieldCreateStaticData fieldCreateStaticData;
    
    public void Load()
    {
      windows = Resources
        .Load<WindowsStaticData>(AssetsPath.WindowsDataPath)
        .InstantiateData
        .ToDictionary(x => x.ID, x => x);

      fieldCreateStaticData = Resources.Load<FieldCreateStaticData>(AssetsPath.FieldCreatePath);
    }
    
    public WindowInstantiateData ForWindow(WindowId windowId) =>
      windows.TryGetValue(windowId, out WindowInstantiateData staticData)
        ? staticData 
        : new WindowInstantiateData();

    public FieldCreateStaticData ForFieldCreate() => 
      fieldCreateStaticData;
  }
}