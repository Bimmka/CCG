using System.Collections.Generic;
using Gameplay.Cards.Decks;
using Gameplay.Table;
using Services.Cards.Spawners;
using Services.Random;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards.Spawners
{
  public class CardSpawner : MonoBehaviour
  {
    [SerializeField] private Field field;
    [SerializeField] private GameplayOpponentDeck opponentDeck;
    [SerializeField] private float chanceToApplySpawnOpponentCard = 1f;
    
    private ICardSpawnerService cardSpawnerService;
    private IRandomService randomService;

    [Inject]
    private void Construct(ICardSpawnerService cardSpawnerService, IRandomService randomService)
    {
      this.cardSpawnerService = cardSpawnerService;
      this.randomService = randomService;
    }

    public void FirstOpponentSpawn()
    {
      List<Vector3> localPositions = field.RandomOpponentPositions();
      for (int i = 0; i < localPositions.Count; i++)
      {
        if (IsApplyOpponentSpawn())
          cardSpawnerService.SpawnEnemyCard(localPositions[i], field.FieldParent, opponentDeck.GetRandomCard());
      }
    }

    public void SpawnOnTopRow()
    {
      List<Vector3> localPositions = field.RandomTopRowPositions();
      for (int i = 0; i < localPositions.Count; i++)
      {
          if (IsApplyOpponentSpawn())
            cardSpawnerService.SpawnEnemyCard(localPositions[i], field.FieldParent,opponentDeck.GetRandomCard());
      }
    }
    
    private bool IsApplyOpponentSpawn() => 
      randomService.NextDouble() <= chanceToApplySpawnOpponentCard;
  }
}