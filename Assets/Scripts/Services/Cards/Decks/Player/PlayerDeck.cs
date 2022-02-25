using System;
using System.Collections.Generic;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Decks.Player
{
  public class PlayerDeck : IPlayerDeck
  {

    private List<CardStaticData> cards;
    private int currentCardIndex = 0;

    public int Length => cards.Count;

    public event Action<int> CardUsed;
    public event Action Empty;
    

    public void UpdateDeck(List<CardStaticData> deck)
    {
      cards = deck;
      currentCardIndex = 0;
    }

    public void ShuffleDeck()
    {
      currentCardIndex = 0;
    }

    public CardStaticData GetCard()
    {
      CardStaticData card = cards[currentCardIndex];
      NotifyAboutUse(currentCardIndex);
      currentCardIndex++;
      if (currentCardIndex >= cards.Count)
        NotifyAboutEmpty();
      return card;
    }

    private void NotifyAboutUse(int index) => 
      CardUsed?.Invoke(index);

    private void NotifyAboutEmpty() => 
      Empty?.Invoke();
  }
}