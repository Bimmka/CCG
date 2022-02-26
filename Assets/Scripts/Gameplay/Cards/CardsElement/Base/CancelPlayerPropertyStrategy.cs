using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CancelPlayerPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;
    private readonly Vector2Int useDirection;

    public CancelPlayerPropertyStrategy(CardStrategyStaticData data, Field field, Vector2Int useDirection) : base(data)
    {
      this.field = field;
      this.useDirection = useDirection;
    }
    
    public override void Use(Vector2Int cardPosition)
    {
      FieldCell forwardCell = field.Cell(cardPosition + useDirection);

      if (forwardCell != null && forwardCell.IsFill)
        forwardCell.CurrentCard.Block();
      
      NotifyAboutEnd();
    }
  }
}