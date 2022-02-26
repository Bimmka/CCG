using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class InvertPropertyStrategy : CardUseStrategy
  {
    private readonly Field field;

    public InvertPropertyStrategy(CardStrategyStaticData data, Field field) : base(data)
    {
      this.field = field;
    }

    public override void Use(Vector2Int cardPosition)
    {
      FieldCell cell = field.Cell(cardPosition - Vector2Int.up);
      
      if (cell != null && cell.IsFill && cell.CurrentCard.IsCanBeInverted())
        cell.CurrentCard.Invert();
      
      NotifyAboutEnd();
        
    }
  }
}