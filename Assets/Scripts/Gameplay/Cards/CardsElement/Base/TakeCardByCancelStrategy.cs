using System.Collections;
using Services;
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
    
    public TakeCardByCancelStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerDeck playerDeck ) : base(data, coroutineRunner)
    {
      this.playerDeck = playerDeck;
      additionalCard = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
    }
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using());
    }

    private IEnumerator Using()
    {
      yield return new WaitForSeconds(1f);
      if (isTriggered)
        playerDeck.ChangeNumberOfCardsToTake(additionalCard);
      yield return new WaitForSeconds(1f);
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