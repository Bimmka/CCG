using System;
using System.Collections.Generic;
using ConstantsValue;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Hand
{
  public class PlayerHand : IPlayerHand
  {
    private readonly List<CardStaticData> collectedCards;
    private readonly int maxCardCount;

    public bool IsNeedSaveCard { get; private set; }

    public event Action<CardStaticData> AddedCard;
    public event Action<CardStaticData> RemovedCard;

    public PlayerHand()
    {
      maxCardCount = Constants.MaxCardInHand;
      collectedCards = new List<CardStaticData>(maxCardCount);
    }

    public void ResetCards()
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
      NotifyAboutRemove(card);
    }

    public void ReleaseCard()
    {
      for (int i = 0; i < collectedCards.Count; i++)
      {
        NotifyAboutRemove(collectedCards[i]);
      }
      collectedCards.Clear();
    }

    public bool IsCanAddCard() => 
      collectedCards.Count < maxCardCount;

    private void NotifyAboutRemove(CardStaticData card) => 
      RemovedCard?.Invoke(card);
  }
}