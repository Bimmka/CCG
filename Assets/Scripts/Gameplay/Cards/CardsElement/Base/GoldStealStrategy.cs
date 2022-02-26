using Services.Hero;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public class GoldStealStrategy : CardUseStrategy, IInvertableCard, IMultipliedCard
  {
    private readonly IPlayerGold playerGold;
    private readonly int GoldCount;

    private bool isSteal = true;

    public GoldStealStrategy(CardStrategyStaticData data, IPlayerGold playerGold) : base(data)
    {
      this.playerGold = playerGold;
      GoldCount = ((GoldStealStrategyStaticData) data).GoldStealCount;
    }
    
    public override void Use()
    {
      for (int i = 0; i < OperationsCount; i++)
      {
        if (isSteal)
          playerGold.Steal(GoldCount);
        else
          playerGold.Add(GoldCount);
      }
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isSteal = false;
    }

    public void MultiplyOperationsCount(int multiplier) => 
      MultiplyOperations(multiplier);
  }
}