using System;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public interface ICardUseStrategy
  {
    event Action Ended;
    void Use(Vector2Int startPosition);
  }
}