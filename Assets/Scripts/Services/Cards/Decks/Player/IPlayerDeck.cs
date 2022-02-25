using System;

namespace Services.Cards.Decks.Player
{
  public interface IPlayerDeck : IDeck
  {
    int Length { get; }
    event Action Empty;
    event Action<int> CardUsed;
    void ShuffleDeck();
  }
}