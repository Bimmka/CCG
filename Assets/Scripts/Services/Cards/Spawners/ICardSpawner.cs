using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public interface ICardSpawner : IService
  {
    void SpawnEnemyCard(Vector3 localPosition, CardStaticData data);
    void SpawnPlayerCard(Vector3 localPosition, CardStaticData data);
  }
}