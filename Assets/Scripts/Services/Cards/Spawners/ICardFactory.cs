using Gameplay.Cards.CardsElement.Base;
using Gameplay.Table;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public interface ICardFactory : IService
  {
    Card CreateCard(Transform transform, CardStaticData data, bool isPlayer);
    Card RecreateCard(Card pooledCard, CardStaticData data, bool isPlayer);
    CardProps SpawnPropsCard( Transform parent, bool isPlayer);
    void SetCurrentField(Field field);
  }
}