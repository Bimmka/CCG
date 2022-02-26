using Gameplay.Cards.CardsElement.Base;
using Gameplay.Table;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public interface ICardSpawnerService : IService
  {
    Card SpawnEnemyCard(Vector3 localPosition,Transform parent, CardStaticData data);
    Card SpawnPlayerCard(Vector3 localPosition, Transform parent, CardStaticData data);
    Card SpawnPlayerCardProps(Vector3 localPosition, Transform playerDeckParent, int index);
    void SetField(Field field);
  }
}