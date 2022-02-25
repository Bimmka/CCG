using StaticData.Gameplay.Cards.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.PlayerHand
{
  public class UIPlayerHandCard : MonoBehaviour
  {
    [SerializeField] private Image mainViewImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    
    private CardStaticData data;

    public int CardID => data == null ? -1 : data.ID;

    public void Show()
    {
      gameObject.SetActive(true);
    }

    public void Hide()
    {
      gameObject.SetActive(false);
    }

    public void ForceHide()
    {
      gameObject.SetActive(false);
    }

    public void SetData(CardStaticData data)
    {
      this.data = data;
      DisplayCardData();
    }

    public void ResetData()
    {
      data = null;
      ResetView();
    }

    private void ResetView()
    {
      mainViewImage.sprite = null;
      nameText.text = "";
      descriptionText.text = "";
    }

    private void DisplayCardData()
    {
      nameText.text = data.Name;
      descriptionText.text = data.Description;
    }
  }
}