﻿using System;
using System.Collections.Generic;
using ConstantsValue;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Hand
{
  public class PlayerHand : IPlayerHand
  {
    private readonly List<CardStaticData> collectedCards;
    private readonly int maxCardCount;

    public event Action<CardStaticData> AddedCard;

    public PlayerHand()
    {
      maxCardCount = Constants.MaxCardInHand;
      collectedCards = new List<CardStaticData>(maxCardCount);
    }

    public void RemoveCards()
    {
      collectedCards.Clear();
    }

    public void AddCard(CardStaticData card)
    {
      collectedCards.Add(card);
      AddedCard?.Invoke(card);
    }

    public void UseCard(CardStaticData card)
    {
      collectedCards.Remove(card);
    }

    public bool IsCanAddCards(int count) => 
      collectedCards.Count + count <= maxCardCount;
  }
}