using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardView : MonoBehaviour
  {
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image mainImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image secondIconImage;

    public void SetView(CardStaticData data)
    {
      backgroundImage.sprite = data.Shirt;
      mainImage.sprite = data.Icon;
    }

    public void Show() => 
      gameObject.SetActive(true);

    public void Hide() => 
      gameObject.SetActive(false);
  }
}