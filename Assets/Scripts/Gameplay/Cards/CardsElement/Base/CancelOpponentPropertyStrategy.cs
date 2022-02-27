using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CancelOpponentPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;
    private readonly Vector2Int useDirection;

    public CancelOpponentPropertyStrategy(CardStrategyStaticData data,ICoroutineRunner coroutineRunner,  Field field, Vector2Int useDirection) : base(data, coroutineRunner)
    {
      this.field = field;
      this.useDirection = useDirection;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      yield return new WaitForSeconds(1f);
      FieldCell forwardCell = field.Cell(cardPosition + useDirection);

      if (forwardCell != null && forwardCell.IsFill)
      {
        if (forwardCell.CurrentCard.IsCanBeTriggered(this))
        {
          forwardCell.CurrentCard.Trigger();
          forwardCell.CurrentCard.Activate(cardPosition);
        }

        if (forwardCell.CurrentCard.IsCanBeBlocking()) 
          forwardCell.CurrentCard.Block();
      }
      yield return new WaitForSeconds(1f);
      NotifyAboutEnd();
    }
  }
}