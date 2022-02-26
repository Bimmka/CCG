using Services.Cards.Decks.Player;
using Services.Cards.Hand;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class TakeCardByCancelStrategy : CardUseStrategy, ITriggered
  {
    private readonly IPlayerDeck playerDeck;
    private readonly int additionalCard;
    
    private bool isTriggered;
    
    public TakeCardByCancelStrategy(CardStrategyStaticData data, IPlayerDeck playerDeck ) : base(data)
    {
      this.playerDeck = playerDeck;
      additionalCard = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
    }

    public override void Use(Vector2Int startPosition)
    {
      if (isTriggered)
        playerDeck.ChangeNumberOfCardsToTake(additionalCard);
      
      NotifyAboutEnd();
    }

    public bool IsCanBeTriggered(CardUseStrategy strategy)
    {
      return strategy.GetType() == typeof(CancelOpponentPropertyStrategy);
    }

    public void Trigger()
    {
      isTriggered = true;
    }
  }
}