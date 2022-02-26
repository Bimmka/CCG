using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class MultiplierPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;
    private readonly Vector2Int cardPosition;

    private readonly int MultiplierCoeff;

    public MultiplierPropertyStrategy(CardStrategyStaticData data, Field field, Vector2Int cardPosition) : base(data)
    {
      this.field = field;
      this.cardPosition = cardPosition;
      MultiplierCoeff = ((MultiplierPropertyStrategyStaticData) data).MultiplierCoeff;
    }

    public override void Use()
    {
      FieldCell cell;
      for (int i = 0; i < field.Size.x; i++)
      {
        if (i == cardPosition.x)
          continue;
        cell = field.Cell(new Vector2Int(i, cardPosition.y));
        
        if (cell != null && cell.IsFill && cell.CurrentCard.IsCanBeMultiplied())
          cell.CurrentCard.MultiplyOperationsNumber(MultiplierCoeff);
      }
      
      NotifyAboutEnd();
    }
  }
}