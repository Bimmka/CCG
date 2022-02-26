using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BlockNearestActionsStrategy : CardUseStrategy
  {
    private readonly Field field;

    public BlockNearestActionsStrategy(CardStrategyStaticData data, Field field) : base(data)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      int rowIndex = field.Size.y - field.PlayerRows;

      FieldCell cell;
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
        }

        rowIndex--;
      }
      NotifyAboutEnd();
    }

    private bool IsCorrectIndex(int playerRowIndex) => 
      playerRowIndex >= field.FirstCommonRow;
  }
}