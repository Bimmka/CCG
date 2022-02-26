using System;

namespace Gameplay.Cards.CardsElement.Base
{
  public interface ICardUseStrategy
  {
    event Action Ended;
    void Use();
  }
}