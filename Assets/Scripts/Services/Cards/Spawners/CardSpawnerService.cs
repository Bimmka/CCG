﻿using System.Collections.Generic;
using Gameplay.Cards.CardsElement.Base;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace Services.Cards.Spawners
{
  public class CardSpawnerService : ICardSpawnerService
  {
    private readonly Queue<Card> pool;
    private readonly ICardFactory cardFactory;

    public CardSpawnerService(ICardFactory factory)
    {
      cardFactory = factory;
      pool = new Queue<Card>(10);
    }

    public void SpawnEnemyCard(Vector3 localPosition, Transform parent, CardStaticData data)
    {
      if (pool.Count > 0)
        RespawnCard(pool.Dequeue(), localPosition, data, false);
      else
        SpawnCard(localPosition, parent, data, false);
    }

    public void SpawnPlayerCard(Vector3 localPosition, Transform parent, CardStaticData data)
    {
      if (pool.Count > 0)
        RespawnCard(pool.Dequeue(), localPosition, data, true);
      else
        SpawnCard(localPosition, parent, data, true);
    }

    public Card SpawnPlayerCardProps(Vector3 localPosition, Transform parent, int index)
    {
      Card card = cardFactory.SpawnPropsCard(parent, true);
      card.transform.localPosition += Vector3.up * index * (card.transform.localScale.y);
      return card;
    }

    private void SpawnCard(Vector3 localPosition, Transform parent, CardStaticData data, bool isPlayer)
    {
      Card card = cardFactory.CreateCard(parent, data, isPlayer);
      card.transform.localPosition = localPosition;
      card.Hiden += ReturnCard;
      card.Show();
    }

    private void RespawnCard(Card card, Vector3 localPosition, CardStaticData data, bool isPlayer)
    {
      card = cardFactory.RecreateCard(card, data, isPlayer);
      card.transform.localPosition = localPosition;
      card.Show();
    }

    private void ReturnCard(Card card)
    {
      pool.Enqueue(card);
    }
  }
}