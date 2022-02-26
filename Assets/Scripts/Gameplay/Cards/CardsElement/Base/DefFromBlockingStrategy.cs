using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class DefFromBlockingStrategy : CardUseStrategy
  {
    private readonly Field field;

    public DefFromBlockingStrategy(CardStrategyStaticData data, Field field) : base(data)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      if (cardPosition.x > field.Size.x - 1)
        NotifyAboutEnd();

      FieldCell cell;
      for (int i = cardPosition.x; i < field.Size.x; i++)
      {
        cell = field.Cell(new Vector2Int(i, cardPosition.y));
          if (cell != null && cell.IsFill)
            cell.CurrentCard.Unblock();
      }
      
      NotifyAboutEnd();
    }
  }
}