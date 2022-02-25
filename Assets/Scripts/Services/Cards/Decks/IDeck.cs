using System.Collections.Generic;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Decks
{
  public interface IDeck : IService
  {
    void UpdateDeck(List<CardStaticData> deck);
    CardStaticData GetRandomCard();
  }
}