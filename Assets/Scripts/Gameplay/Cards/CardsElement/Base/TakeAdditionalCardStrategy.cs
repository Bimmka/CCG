using System.Collections;
using Gameplay.Cards.Decks;
using Services;
using Services.Cards.Decks.Player;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class TakeAdditionalCardStrategy : CardUseStrategy
  {
    private readonly IPlayerDeck deck;

    private readonly int AdditionalCardsCount;

    public TakeAdditionalCardStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerDeck deck) : base(data, coroutineRunner)
    {
      this.deck = deck;
      AdditionalCardsCount = ((TakeAdditionalCardStrategyStaticData) data).AdditionalCardCount;
    }

    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using());
    }

    private IEnumerator Using()
    {
      yield return new WaitForSeconds(1f);
      deck.ChangeNumberOfCardsToTake(AdditionalCardsCount);
      NotifyAboutEnd();
    }
  }
}