using Gameplay.Table;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public class OpponentShuffleStrategy : CardUseStrategy, IMultipliedCard
  {
    private readonly Field field;

    public OpponentShuffleStrategy(CardStrategyStaticData data, Field field) : base(data)
    {
      this.field = field;
    }

    public override void Use()
    {
      for (int i = 0; i < OperationsCount; i++)
      {
        
      }
      
      NotifyAboutEnd();
      
    }

    public void MultiplyOperationsCount(int multiplier)
    {
      MultiplyOperations(multiplier);
    }
  }
}