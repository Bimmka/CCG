using System;
using Services.Cards.Decks.Player;
using StaticData.Gameplay.Cards.Strategies;

namespace Gameplay.Cards.CardsElement.Base
{
  public abstract class CardUseStrategy : ICardUseStrategy
  {
    
    private int currentOperationsNumber;
    protected int OperationsCount => currentOperationsNumber;
    public event Action Ended;

    public CardUseStrategy(CardStrategyStaticData data)
    {
      currentOperationsNumber = data.MinOperationsNumber;
    }
    public abstract void Use();

    protected void MultiplyOperations(int multiplier) => 
      currentOperationsNumber *= multiplier;

    protected void DecOperationsCount() => 
      currentOperationsNumber--;

    protected bool IsOperationsEnd() => 
      currentOperationsNumber <= 0;

    protected void NotifyAboutEnd() => 
      Ended?.Invoke();
  }
}