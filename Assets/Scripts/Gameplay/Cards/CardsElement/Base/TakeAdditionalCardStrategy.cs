using Gameplay.Cards.Decks;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public class TakeAdditionalCardStrategy : CardUseStrategy
  {
    private readonly GameplayPlayerDeck deck;

    private readonly int AdditionalCardsCount;

    public TakeAdditionalCardStrategy(CardStrategyStaticData data, GameplayPlayerDeck deck) : base(data)
    {
      this.deck = deck;
      AdditionalCardsCount = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
    }

    public override void Use()
    {
      deck.IncNumberOfCardsToTake(AdditionalCardsCount);
      NotifyAboutEnd();
    }
  }
}