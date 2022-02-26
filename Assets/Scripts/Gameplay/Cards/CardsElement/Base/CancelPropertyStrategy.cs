using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CancelPropertyStrategy : CardUseStrategy
  {
    private readonly Vector2Int cardPosition;
    private readonly Field field;
    private readonly Vector2Int useDirection;

    public CancelPropertyStrategy(CardStrategyStaticData data, Vector2Int cardPosition, Field field, Vector2Int useDirection) : base(data)
    {
      this.cardPosition = cardPosition;
      this.field = field;
      this.useDirection = useDirection;
    }
    
    public override void Use()
    {
      FieldCell forwardCell = field.Cell(cardPosition + useDirection);

      if (forwardCell != null && forwardCell.IsFill)
        forwardCell.CurrentCard.Block();
      
      NotifyAboutEnd();
    }
  }
}