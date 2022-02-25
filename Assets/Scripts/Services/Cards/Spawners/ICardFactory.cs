using Gameplay.Cards.CardsElement.Base;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Spawners
{
  public interface ICardFactory : IService
  {
    Card CreateCard(CardStaticData data, bool isPlayer);
    Card RecreateCard(Card pooledCard, CardStaticData data, bool isPlayer);
  }
}