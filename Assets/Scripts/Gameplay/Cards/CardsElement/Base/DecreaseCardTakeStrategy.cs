using Services.Cards.Decks.Player;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class DecreaseCardTakeStrategy : CardUseStrategy, IInvertableCard
  {
    private readonly IPlayerDeck playerDeck;
    private readonly int decCardCount;
    private bool isDec = true;
    
    public DecreaseCardTakeStrategy(CardStrategyStaticData data, IPlayerDeck playerDeck) : base(data)
    {
      decCardCount = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
      this.playerDeck = playerDeck;
    }

    public override void Use(Vector2Int startPosition)
    {
      if (isDec)
        playerDeck.ChangeNumberOfCardsToTake(-decCardCount);
      else
        playerDeck.ChangeNumberOfCardsToTake(decCardCount);
      
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isDec = false;
    }
  }
}