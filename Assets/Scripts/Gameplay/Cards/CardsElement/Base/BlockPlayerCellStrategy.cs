using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BlockPlayerCellStrategy : CardUseStrategy, IMultipliedCard
  {
    private readonly Field field;

    public BlockPlayerCellStrategy(CardStrategyStaticData data,ICoroutineRunner coroutineRunner,  Field field) : base(data, coroutineRunner)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      FieldCell playerCell = field.Cell(cardPosition + Vector2Int.up);
      yield return new WaitForSeconds(1f);
      if (playerCell != null)
      {
        for (int i = 0; i < OperationsCount; i++)
        {
          playerCell.LockForNextTurn();  
        }
        yield return new WaitForSeconds(1f);
      }
      
      NotifyAboutEnd();
    }

    public void MultiplyOperationsCount(int multiplier) => 
      MultiplyOperations(multiplier);
  }
}