using System;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Windows.PlayerHand
{
  public class UIPlayerHandCard : MonoBehaviour, IPointerClickHandler
  {
    [SerializeField] private UIPlayerHandCardView view;
    private CardStaticData data;

    public event Action<CardStaticData> Clicked; 
    public int CardID => data == null ? -1 : data.ID;

    public void Construct(IRandomService randomService)
    {
      view.Construct(randomService);
    }

    public void Show(Action callback = null) => 
      view.Show(callback);

    public void Hide(Action callback = null) => 
      view.Hide(callback);

    public void ForceHide() => 
      view.ForceHide();

    public void SetData(CardStaticData data)
    {
      this.data = data;
      view.SetView(data);
    }

    public void OnPointerClick(PointerEventData eventData) => 
      Clicked?.Invoke(data);

    public void ResetData()
    {
      data = null;
    }
  }
}