using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BlockPlayerCellStrategy : CardUseStrategy, IMultipliedCard
  {
    private readonly Field field;

    public BlockPlayerCellStrategy(CardStrategyStaticData data, Field field) : base(data)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      FieldCell playerCell = field.Cell(cardPosition + Vector2Int.up);

      if (playerCell != null)
      {
        for (int i = 0; i < OperationsCount; i++)
        {
          playerCell.LockForNextTurn();  
        }
        
      }
      
      NotifyAboutEnd();
    }

    public void MultiplyOperationsCount(int multiplier) => 
      MultiplyOperations(multiplier);
  }
}