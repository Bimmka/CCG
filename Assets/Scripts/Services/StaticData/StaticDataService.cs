using System.Collections.Generic;
using System.Linq;
using ConstantsValue;
using Gameplay.Cards.CardsElement.Base;
using Services.UI.Factory;
using StaticData.Gameplay.Cards.Decks;
using StaticData.Gameplay.Cards.Elements;
using StaticData.Gameplay.Table;
using StaticData.UI;
using UnityEngine;

namespace Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, WindowInstantiateData> windows;
    private Dictionary<string, List<CardStaticData>> opponentDecks;
    private DeckStaticData playerDeck;

    private FieldCreateStaticData fieldCreateStaticData;
    
    public void Load()
    {
      windows = Resources
        .Load<WindowsStaticData>(AssetsPath.WindowsDataPath)
        .InstantiateData
        .ToDictionary(x => x.ID, x => x);

      opponentDecks = Resources.
        LoadAll<OpponentDeckStaticData>(AssetsPath.OpponentDecksPath)
        .ToDictionary(x => x.LevelKey, x => x.Cards);
      
      playerDeck = Resources.Load<DeckStaticData>(AssetsPath.PlayerDeckPath);

      fieldCreateStaticData = Resources.Load<FieldCreateStaticData>(AssetsPath.FieldCreatePath);
    }
    
    public WindowInstantiateData ForWindow(WindowId windowId) =>
      windows.TryGetValue(windowId, out WindowInstantiateData staticData)
        ? staticData 
        : new WindowInstantiateData();

    public FieldCreateStaticData ForFieldCreate() => 
      fieldCreateStaticData;

    public List<CardStaticData> ForOpponent(string levelName) =>
      opponentDecks.TryGetValue(levelName, out List<CardStaticData> staticData)
        ? staticData 
        : new List<CardStaticData>();
    
    public List<CardStaticData> ForPlayer() =>
      playerDeck.Cards;
  }
}