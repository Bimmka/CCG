using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class BlockPlayerCellStrategy : CardUseStrategy, IMultipliedCard
  {
    private readonly Field field;
    private readonly Vector2Int cardPosition;

    public BlockPlayerCellStrategy(CardStrategyStaticData data, Field field, Vector2Int cardPosition) : base(data)
    {
      this.field = field;
      this.cardPosition = cardPosition;
    }

    public override void Use()
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