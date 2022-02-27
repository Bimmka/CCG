using System.Collections;
using Gameplay.Table;
using Services;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BlockNearestActionsStrategy : CardUseStrategy
  {
    private readonly Field field;

    public BlockNearestActionsStrategy(CardStrategyStaticData data, ICoroutineRunner coroutineRunner, Field field) : base(data, coroutineRunner)
    {
      this.field = field;
    }

    
    public override void Use(Vector2Int cardPosition)
    {
      coroutineRunner.StartCoroutine(Using(cardPosition));
    }

    private IEnumerator Using(Vector2Int cardPosition)
    {
      int rowIndex = field.Size.y - field.PlayerRows;

      FieldCell cell;
      Debug.Log("Block Nearest");
      while (IsCorrectIndex(rowIndex))
      {
        for (int i = 0; i < field.Size.x; i++)
        {
          cell = field.Cell(new Vector2Int(i, rowIndex));
          if (cell != null && cell.IsFill)
          {
            if (cell.CurrentCard.IsCanBeTriggered(this))
            {
              
              cell.CurrentCard.Trigger();
              cell.CurrentCard.Activate(cardPosition);
            }
            
            if (cell.CurrentCard.IsCanBeBlocking())
              cell.CurrentCard.Block();
          }
          yield return new WaitForSeconds(1f);
        }

        rowIndex--;
        yield return new WaitForSeconds(1f);
      }
      NotifyAboutEnd();
    }

    private bool IsCorrectIndex(int playerRowIndex) => 
      playerRowIndex > field.FirstCommonRow;
  }
}