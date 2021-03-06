using StaticData.Gameplay.Cards.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Tips
{
  public class UICardTip : MonoBehaviour
  {
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image mainViewImage;
    [SerializeField] private Image shirtImage;
    [SerializeField] private Image imageBackground; 
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    

    public void SetView(CardStaticData data)
    {
        ChangeCanvasAlpha(1f);
        UpdateData(data);
    }

    public void Disable()
    {
      ChangeCanvasAlpha(0f);
    }

    private void UpdateData(CardStaticData data)
    {
      mainViewImage.sprite = data.Icon;
      nameText.text = data.Name;
      descriptionText.text = data.Description;
      shirtImage.sprite = data.Shirt;
      shirtImage.color = data.ShortColor;
    }

    private void ChangeCanvasAlpha(float alpha)
    {
      canvasGroup.alpha = alpha;
    }
  }
}