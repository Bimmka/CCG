﻿using System;
using System.Collections.Generic;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Decks.Player
{
  public class PlayerDeck : IPlayerDeck
  {

    private int minNumberOfCardsToTake = 2;
    private List<CardStaticData> cards;
    private int currentCardIndex = 0;

    public int CurrentNumberOfCardsToTake { get; private set; }
    public int Length => cards.Count;

    public event Action<int> CardUsed;
    public event Action Empty;
    

    public void UpdateDeck(List<CardStaticData> deck)
    {
      cards = deck;
      currentCardIndex = 0;
    }

    public void ShuffleDeck() => 
      currentCardIndex = 0;

    public void SetMinNumberOfCardsToTake(int count)
    {
      minNumberOfCardsToTake = count;
      CurrentNumberOfCardsToTake = minNumberOfCardsToTake;
    }

    public void IncNumberOfCardsToTake(int additionalCardsCount)
    {
      CurrentNumberOfCardsToTake += additionalCardsCount;
    }

    public CardStaticData GetCard()
    {
      CardStaticData card = cards[currentCardIndex];
      NotifyAboutUse(currentCardIndex);
      currentCardIndex++;
      if (currentCardIndex >= cards.Count)
        NotifyAboutEmpty();
      return card;
    }
    
    public void ResetNumberOfCardsToTake() => 
      CurrentNumberOfCardsToTake = minNumberOfCardsToTake;
    

    private void NotifyAboutUse(int index) => 
      CardUsed?.Invoke(index);

    private void NotifyAboutEmpty() => 
      Empty?.Invoke();
  }
}