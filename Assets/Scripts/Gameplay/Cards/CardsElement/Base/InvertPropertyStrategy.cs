using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class InvertPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;
    private readonly Vector2Int cardPosition;

    public InvertPropertyStrategy(CardStrategyStaticData data, Field field, Vector2Int cardPosition) : base(data)
    {
      this.field = field;
      this.cardPosition = cardPosition;
    }

    public override void Use()
    {
      FieldCell cell = field.Cell(cardPosition - Vector2Int.up);
      
      if (cell != null && cell.IsFill && cell.CurrentCard.IsCanBeInverted())
        cell.CurrentCard.Invert();
      
      NotifyAboutEnd();
        
    }
  }
}