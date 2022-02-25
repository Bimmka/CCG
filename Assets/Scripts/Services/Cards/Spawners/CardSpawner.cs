using System.Collections.Generic;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Table;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public class CardSpawner : ICardSpawner
  {
    private readonly Queue<Card> pool;
    private ICardFactory cardFactory;

    public CardSpawner(ICardFactory factory)
    {
      cardFactory = factory;
      pool = new Queue<Card>(10);
    }

    public void SpawnEnemyCard(Vector3 localPosition, CardStaticData data)
    {
      if (pool.Count > 0)
        RespawnCard(pool.Dequeue(), localPosition, data, false);
      else
        SpawnCard(localPosition, data, false);
    }

    public void SpawnPlayerCard(Vector3 localPosition, CardStaticData data)
    {
      if (pool.Count > 0)
        RespawnCard(pool.Dequeue(), localPosition, data, true);
      else
        SpawnCard(localPosition, data, true);
    }

    private void SpawnCard(Vector3 localPosition, CardStaticData data, bool isPlayer)
    {
      Card card = cardFactory.CreateCard(data, isPlayer);
      card.transform.localPosition = localPosition;
      card.Hiden += ReturnCard;
      card.Show();
    }

    private void ReturnCard(Card card)
    {
      pool.Enqueue(card);
    }

    private void RespawnCard(Card card, Vector3 localPosition, CardStaticData data, bool isPlayer)
    {
      card = cardFactory.RecreateCard(card, data, isPlayer);
      card.transform.localPosition = localPosition;
      card.Show();
    }
  }
}