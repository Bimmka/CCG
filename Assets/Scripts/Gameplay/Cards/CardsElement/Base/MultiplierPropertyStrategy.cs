using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class MultiplierPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;
    private readonly int MultiplierCoeff;

    public MultiplierPropertyStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, Field field) : base(data, coroutineRunner)
    {
      this.field = field;
      MultiplierCoeff = ((MultiplierPropertyStrategyStaticData) data).MultiplierCoeff;
    }

    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      FieldCell cell;
      yield return new WaitForSeconds(1f);
      for (int i = 0; i < field.Size.x; i++)
      {
        if (i == cardPosition.x)
          continue;
        cell = field.Cell(new Vector2Int(i, cardPosition.y));
        
        if (cell != null && cell.IsFill && cell.CurrentCard.IsCanBeMultiplied())
          cell.CurrentCard.MultiplyOperationsNumber(MultiplierCoeff);
      }
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }
  }
}