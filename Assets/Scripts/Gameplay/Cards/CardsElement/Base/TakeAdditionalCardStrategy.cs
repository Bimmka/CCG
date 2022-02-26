using Gameplay.Cards.Decks;
using Services.Cards.Decks.Player;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class TakeAdditionalCardStrategy : CardUseStrategy
  {
    private readonly IPlayerDeck deck;

    private readonly int AdditionalCardsCount;

    public TakeAdditionalCardStrategy(CardStrategyStaticData data, IPlayerDeck deck) : base(data)
    {
      this.deck = deck;
      AdditionalCardsCount = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
    }

    public override void Use(Vector2Int cardPosition)
    {
      deck.IncNumberOfCardsToTake(AdditionalCardsCount);
      NotifyAboutEnd();
    }
  }
}