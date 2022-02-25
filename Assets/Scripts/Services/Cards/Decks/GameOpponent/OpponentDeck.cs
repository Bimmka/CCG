using System.Collections.Generic;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Decks.GameOpponent
{
  public class OpponentDeck : IDeck
  {
    private readonly IRandomService randomService;
    
    private List<CardStaticData> cards;

    public OpponentDeck(IRandomService randomService)
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