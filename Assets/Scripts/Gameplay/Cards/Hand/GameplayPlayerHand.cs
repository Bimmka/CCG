using System;
using System.Collections.Generic;
using Gameplay.Cards.Decks;
using Services.Cards.Hand;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards.Hand
{
  public class GameplayPlayerHand : MonoBehaviour
  {
    [SerializeField] private GameplayPlayerDeck deck;
    
    private IPlayerHand hand;

    public event Action<CardStaticData> AddedCard;
    public event Action<CardStaticData> RemovedCard; 

    [Inject]
    private void Construct(IPlayerHand playerHand)
    {
      hand = playerHand;
    }

    public bool IsCanCollectCards()
    {
      return hand.IsCanAddCards(deck.NumberOfCardsToTake);
    }

    public void CollectCards()
    {
      List<CardStaticData> cards = deck.GetNeededCard();
      for (int i = 0; i < cards.Count; i++)
      {
        hand.AddCard(cards[i]);
        AddedCard?.Invoke(cards[i]);
      }
    }
  }
}