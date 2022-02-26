using System;
using System.Collections.Generic;
using Gameplay.Cards.CardsElement.Base;
using Gameplay.Cards.Spawners;
using Gameplay.Table;
using Services.Cards.Decks.Player;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards.Decks
{
  public class GameplayPlayerDeck : MonoBehaviour
  {
    [SerializeField] private CardSpawner spawner;
    [SerializeField] private Field field;

    private IPlayerDeck deck;
    private List<Card> spawnedCards;

    public int NumberOfCardsToTake => deck.CurrentNumberOfCardsToTake;
      
    [Inject]
    private void Construct(IPlayerDeck playerDeck)
    {
      deck = playerDeck;
      deck.Empty += OnDeckEnded;
      deck.CardUsed += OnCardUsed;
    }

    private void OnDestroy()
    {
      deck.Empty -= OnDeckEnded;
      deck.CardUsed -= OnCardUsed;
    }

    public void Init()
    {
      spawnedCards = spawner.SpawnPlayerDeck();
      deck.SetMinNumberOfCardsToTake(field.Size.x - 1);
    }

    public int DeckLength() => 
      deck.Length;

    public List<CardStaticData> GetNeededCard()
    {
      List<CardStaticData> cards = new List<CardStaticData>(NumberOfCardsToTake);
      for (int i = 0; i < NumberOfCardsToTake; i++)
      {
        cards.Add(deck.GetCard());
      }
      return cards;
    }

    public void ResetNumberOfCardsToTake()
    {
      deck.ResetNumberOfCardsToTake();
    }

    private void OnCardUsed(int index) => 
      spawnedCards[index].Hide();

    private void OnDeckEnded()
    {
      deck.ShuffleDeck();
      ShowAllCards();
    }

    private void ShowAllCards()
    {
      for (int i = 0; i < spawnedCards.Count; i++)
      {
        spawnedCards[i].Show();
      }
    }

   
  }
}