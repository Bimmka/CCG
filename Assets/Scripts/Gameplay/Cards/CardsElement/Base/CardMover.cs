using DG.Tweening;
using StaticData.Gameplay.Cards.Components;
using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardMover
  {
    private readonly Transform cardTransform;
    private readonly CardMoverStaticData data;
    public CardMover(Transform cardTransform, CardMoverStaticData data)
    {
      this.cardTransform = cardTransform;
      this.data = data;
    }
    
    public void MoveTo(Vector3 localPosition) => 
      MoveSequence(localPosition);

    private void MoveSequence(Vector3 endPosition) => 
      cardTransform.DOLocalMove(UpMovePosition(endPosition), data.UpDuration).SetEase(Ease.InOutSine).OnComplete(() => ForwardMove(endPosition));

    private void ForwardMove(Vector3 endPosition) => 
      cardTransform.DOLocalMove(ForwardMovePosition(endPosition), data.MoveDuration).SetEase(Ease.InOutSine).OnComplete(() => DownMove(endPosition));

    private void DownMove(Vector3 endPosition) => 
      cardTransform.DOLocalMove(endPosition, data.DownDuration).SetEase(Ease.InOutSine);

    private Vector3 UpMovePosition(Vector3 endPosition) => 
      new Vector3(
        cardTransform.localPosition.x, 
        cardTransform.localPosition.y + data.YOffset, 
        cardTransform.localPosition.z - (cardTransform.localPosition.z -endPosition.z) * data.XPercentEndpointsOffset
        );

    private Vector3 ForwardMovePosition(Vector3 endPosition) => 
      new Vector3(
        cardTransform.localPosition.x,
        cardTransform.localPosition.y, 
        endPosition.z - (cardTransform.localPosition.z -endPosition.z) * data.XPercentEndpointsOffset);
  }
}