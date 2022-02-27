using UnityEngine;

namespace Gameplay.Cards.CardsElement.Base
{
  public class CardProps : MonoBehaviour
  {
    [SerializeField] private CardView view;
    
    public void Show() => 
      view.Show();

    public void Hide()
    {
      view.Hide();
    }
  }
}