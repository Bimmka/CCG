using Services.Hero;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public class GetGoldStrategy : CardUseStrategy, IInvertableCard
  {
    private readonly IPlayerGold playerGold;
    private readonly int GoldCount;

    private bool isGet = true;

    public GetGoldStrategy(CardStrategyStaticData data, IPlayerGold playerGold) : base(data)
    {
      this.playerGold = playerGold;
      GoldCount = ((GoldTakeStrategyStaticData) data).GoldTakeCount;
    }
    
    public override void Use()
    {
      if (isGet)
        playerGold.Add(GoldCount);
      else
        playerGold.Steal(GoldCount);
      
      NotifyAboutEnd();
    }

    public void Invert()
    {
      isGet = false;
    }
  }
}