using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class InvertPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;

    public InvertPropertyStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, Field field) : base(data, coroutineRunner)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      FieldCell cell = field.Cell(cardPosition - Vector2Int.up);
      yield return new WaitForSeconds(1f);
      if (cell != null && cell.IsFill && cell.CurrentCard.IsCanBeInverted())
        cell.CurrentCard.Invert();
      NotifyAboutEnd();
    }
  }
}