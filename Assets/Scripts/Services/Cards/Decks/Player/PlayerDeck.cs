using System;
using System.Collections.Generic;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Decks.Player
{
  public class PlayerDeck : IPlayerDeck
  {
    private readonly IRandomService randomService;
    
    private List<CardStaticData> cards;

    public event Action Empty;

    public PlayerDeck(IRandomService randomService)
    {
      this.randomService = randomService;
    }

    public void UpdateDeck(List<CardStaticData> deck)
    {
      cards = deck;
    }

    public CardStaticData GetRandomCard()
    {
      return cards[randomService.Next(0, cards.Count)];
    }
  }
}