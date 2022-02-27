using DG.Tweening;
using StaticData.UI.Displaying;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Displaying
{
  public class UIBar : MonoBehaviour
  {
    [SerializeField] private Image fillBar;
    [SerializeField] private BarDisplayingStaticData data;

    public void SetValue(float current, float max)
    {
      fillBar.fillAmount = current / max;
    }
    public void FillValue(float current, float max)
    {
      DOTween.Kill(fillBar);
      fillBar.DOFillAmount(current / max, data.BarFillDuration).SetEase(Ease.InOutSine);
    }
  }
}