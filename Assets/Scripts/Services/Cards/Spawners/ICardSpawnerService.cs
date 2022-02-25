using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public interface ICardSpawnerService : IService
  {
    void SpawnEnemyCard(Vector3 localPosition,Transform parent, CardStaticData data);
    void SpawnPlayerCard(Vector3 localPosition, Transform parent, CardStaticData data);
  }
}