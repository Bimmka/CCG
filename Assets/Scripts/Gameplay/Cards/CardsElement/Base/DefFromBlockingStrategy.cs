using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class DefFromBlockingStrategy : CardUseStrategy
  {
    private readonly Field field;

    public DefFromBlockingStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner,  Field field) : base(data, coroutineRunner)
    {
      this.field = field;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      yield return new WaitForSeconds(1f);
      if (cardPosition.x > field.Size.x - 1)
      {
        yield return new WaitForSeconds(1f);
        NotifyAboutEnd();
      }

      FieldCell cell;
      for (int i = cardPosition.x; i < field.Size.x; i++)
      {
        cell = field.Cell(new Vector2Int(i, cardPosition.y));
        if (cell != null && cell.IsFill)
          cell.CurrentCard.Unblock();
      }
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }
  }
}