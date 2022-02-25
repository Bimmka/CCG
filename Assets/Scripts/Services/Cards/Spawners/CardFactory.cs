using Gameplay.Cards.CardsElement.Base;
using Services.Assets;
using Services.StaticData;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Spawners
{
  public class CardFactory : ICardFactory
  {
    private Card prefab;
    private IAssetProvider assets;
    public CardFactory(IAssetProvider assetProvider, Card cardPrefab)
    {
      assets = assetProvider;
      prefab = cardPrefab;
    }
    
    public Card CreateCard(CardStaticData data, bool isPlayer)
    {
      return assets.Instantiate(prefab);
    }

    public Card RecreateCard(Card pooledCard, CardStaticData data, bool isPlayer)
    {
      return pooledCard;
    }
  }
}