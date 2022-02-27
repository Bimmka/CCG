using System.Collections;
using Services;
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
    
    public DecreaseCardTakeStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerDeck playerDeck) : base(data, coroutineRunner)
    {
      decCardCount = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
      this.playerDeck = playerDeck;
    }

    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using());
    }

    private IEnumerator Using()
    {
      yield return new WaitForSeconds(1f);
      if (isDec)
        playerDeck.ChangeNumberOfCardsToTake(-decCardCount);
      else
        playerDeck.ChangeNumberOfCardsToTake(decCardCount);
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isDec = false;
    }
  }
}