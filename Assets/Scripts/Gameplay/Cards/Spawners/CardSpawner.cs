using System.Collections.Generic;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Cards.Decks;
using Gameplay.Table;
using Services.Cards.Spawners;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards.Spawners
{
  public class CardSpawner : MonoBehaviour
  {
    [SerializeField] private Field field;
    [SerializeField] private GameplayOpponentDeck opponentDeck;
    [SerializeField] private GameplayPlayerDeck playerDeck;
    [SerializeField] private float chanceToApplySpawnOpponentCard = 1f;
    [SerializeField] private float enemyFieldCardYOffset = 0.5f;
    

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
      List<FieldCell> rowCells = field.OpponentPositions();
      for (int i = 0; i < rowCells.Count; i++)
      {
        if (IsApplyOpponentSpawn())
          rowCells[i].SetCard(
            cardSpawnerService.SpawnEnemyCard(
              UppedPosition(rowCells[i].LocalPosition),
              field.FieldParent, 
              opponentDeck.GetRandomCard()
            )
          );
      }
    }

    public void SpawnOnTopRow()
    {
      List<FieldCell> rowCells = field.TopRowPositions();
      for (int i = 0; i < rowCells.Count; i++)
      {
        if (IsApplyOpponentSpawn())
          rowCells[i].SetCard(
            cardSpawnerService.SpawnEnemyCard(
              UppedPosition(rowCells[i].LocalPosition),
            field.FieldParent, 
              opponentDeck.GetRandomCard()
              )
            );
      }
    }

    public List<Card> SpawnPlayerDeck()
    {
      List<Card> cards = new List<Card>(playerDeck.DeckLength());
      for (int i = 0; i < playerDeck.DeckLength(); i++)
      {
        cards.Add(cardSpawnerService.SpawnPlayerCardProps(UppedPosition(field.PlayerDeckParent.localPosition), field.PlayerDeckParent, i));
      }

      return cards;
    }

    public Card SpawnPlayerCard(CardStaticData card, Vector3 localPosition, Transform parent)
    {
      return cardSpawnerService.SpawnPlayerCard(UppedPosition(localPosition), parent, card);
    }

    private bool IsApplyOpponentSpawn() => 
      randomService.NextDouble() <= chanceToApplySpawnOpponentCard;

    private Vector3 UppedPosition(Vector3 localPosition)
    {
      return localPosition + Vector3.up * enemyFieldCardYOffset;
    }
  }
}