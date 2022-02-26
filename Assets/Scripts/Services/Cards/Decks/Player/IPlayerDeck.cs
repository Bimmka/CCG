using System;

namespace Services.Cards.Decks.Player
{
  public interface IPlayerDeck : IDeck
  {
    int Length { get; }
    int CurrentNumberOfCardsToTake { get; }
    event Action Empty;
    event Action<int> CardUsed;
    void ShuffleDeck();
    void ChangeNumberOfCardsToTake(int additionalCardsCount);
    void SetMinNumberOfCardsToTake(int count);
    void ResetNumberOfCardsToTake();
  }
}