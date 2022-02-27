using System.Collections.Generic;
using System.Linq;
using ConstantsValue;
using Gameplay.Cards.CardsElement.Base;
using Services.UI.Factory;
using StaticData.Audio;
using StaticData.Gameplay.Cards.Decks;
using StaticData.Gameplay.Cards.Elements;
using StaticData.Gameplay.Cards.Strategies;
using StaticData.Gameplay.Player;
using StaticData.Gameplay.Table;
using StaticData.UI;
using UnityEngine;

namespace Services.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<WindowId, WindowInstantiateData> windows;
    private Dictionary<string, List<CardStaticData>> opponentDecks;
    private Dictionary<PlayingActionType, CardStrategyStaticData> strategies;
    private Dictionary<string, AudioClip> audioClips;
    private DeckStaticData playerDeck;

    private PlayerGoldStaticData playerGoldStaticData;

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
      
      strategies = Resources.
        LoadAll<CardStrategyStaticData>(AssetsPath.CardStrategies)
        .ToDictionary(x => x.Type, x => x);
      
      audioClips = Resources.
        Load<AudioStaticData>(AssetsPath.AudioClipsPath).Clips
        .ToDictionary(x => x.Name, x => x.Clip);
      
      playerDeck = Resources.Load<DeckStaticData>(AssetsPath.PlayerDeckPath);

      fieldCreateStaticData = Resources.Load<FieldCreateStaticData>(AssetsPath.FieldCreatePath);
      
      playerGoldStaticData = Resources.Load<PlayerGoldStaticData>(AssetsPath.PlayerGoldPath);
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

    public CardStrategyStaticData ForStrategy(PlayingActionType actionType) =>
      strategies.TryGetValue(actionType, out CardStrategyStaticData staticData)
        ? staticData 
        : null;

    public PlayerGoldStaticData ForPlayerGold() => 
      playerGoldStaticData;

    public AudioClip ForAudio(string clipName) => 
      audioClips.TryGetValue(clipName, out AudioClip clip) 
        ? clip
        : null;
  }
}