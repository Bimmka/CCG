using Services.Cards.Decks.GameOpponent;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards.Decks
{
  public class GameplayOpponentDeck : MonoBehaviour
  {
    private IOpponentDeck deck;

    [Inject]
    private void Construct(IOpponentDeck opponentDeck)
    {
      deck = opponentDeck;
    }

    public CardStaticData GetRandomCard() => 
      deck.GetCard();
  }
}