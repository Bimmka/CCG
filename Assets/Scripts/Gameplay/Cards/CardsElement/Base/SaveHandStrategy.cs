using System.Collections;
using Gameplay.Cards.Hand;
using Services;
using Services.Cards.Hand;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class SaveHandStrategy : CardUseStrategy
  {
    private readonly IPlayerHand hand;

    public SaveHandStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, IPlayerHand hand) : base(data, coroutineRunner)
    {
      this.hand = hand;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using());
    }

    private IEnumerator Using()
    {
      yield return new WaitForSeconds(1f);
      hand.SetSaveCard();
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }
  }
}