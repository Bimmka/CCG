using System;
using StaticData.Gameplay.Cards.Elements;

namespace Services.Cards.Hand
{
  public interface IPlayerHand : IService
  {
    event Action<CardStaticData> AddedCard;
    event Action<CardStaticData> RemovedCard;
    bool IsNeedSaveCard { get; }
    void AddCard(CardStaticData card);
    void UseCard(CardStaticData card);
    void ReleaseCard();
    bool IsCanAddCard();
    void ResetCards();
    void ResetSaveCard();
    void SetSaveCard();
  }
}