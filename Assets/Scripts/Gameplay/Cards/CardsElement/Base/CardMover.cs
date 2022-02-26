using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardMover
  {
    private readonly Transform cardTransform;

    public CardMover(Transform cardTransform)
    {
      this.cardTransform = cardTransform;
    }
    
    public void MoveTo(Vector3 localPosition)
    {
      cardTransform.localPosition = localPosition;
    }
  }
}