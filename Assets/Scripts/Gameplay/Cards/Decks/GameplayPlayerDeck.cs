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
    
    private int minNumberOfCardsToTake = 2;

    private IPlayerDeck deck;
    private List<Card> spawnedCards;
    
    public int NumberOfCardsToTake { get; private set; }
      
    [Inject]
    private void Construct(IPlayerDeck playerDeck)
    {
      deck = playerDeck;
      deck.Empty += OnDeckEnded;
      deck.CardUsed += OnCardUsed;
    }

    public void Init()
    {
      spawnedCards = spawner.SpawnPlayerDeck();
      minNumberOfCardsToTake = field.Size.x - 1;
      ResetNumberOfCardsToTake();
    }

    public int DeckLength() => 
      deck.Length;

    public void IncNumberOfCardsToTake(int count) => 
      NumberOfCardsToTake += count;

    public List<CardStaticData> GetNeededCard()
    {
      List<CardStaticData> cards = new List<CardStaticData>(NumberOfCardsToTake);
      for (int i = 0; i < NumberOfCardsToTake; i++)
      {
        cards.Add(deck.GetCard());
      }
      return cards;
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

    private void ResetNumberOfCardsToTake() => 
      NumberOfCardsToTake = minNumberOfCardsToTake;
  }
}