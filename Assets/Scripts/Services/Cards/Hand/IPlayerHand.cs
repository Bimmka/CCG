using System;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Hand
{
  public interface IPlayerHand : IService
  {
    event Action<CardStaticData> AddedCard;
    event Action<CardStaticData> RemovedCard;
    void AddCard(CardStaticData card);
    void UseCard(CardStaticData card);
    bool IsCanAddCards(int count);
    void ResetCards();
  }
}