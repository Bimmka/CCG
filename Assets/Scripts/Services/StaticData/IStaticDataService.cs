using System.Collections.Generic;
using Gameplay.Cards.CardsElement.Base;
using Services.UI.Factory;
using StaticData.Gameplay.Cards.Elements;
using StaticData.Gameplay.Cards.Strategies;
using StaticData.Gameplay.Player;
using StaticData.Gameplay.Table;
using StaticData.UI;

namespace Services.StaticData
{
  public interface IStaticDataService : IService
  {
    void Load();
    WindowInstantiateData ForWindow(WindowId id);
    FieldCreateStaticData ForFieldCreate();
    List<CardStaticData> ForOpponent(string levelName);
    List<CardStaticData> ForPlayer();
    CardStrategyStaticData ForStrategy(PlayingActionType actionType);
    PlayerGoldStaticData ForPlayerGold();
  }
}