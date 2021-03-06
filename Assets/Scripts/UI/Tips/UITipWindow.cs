using System;
using Gameplay.Clicks;
using Gameplay.Table;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;

namespace UI.Tips
{
    public class UITipWindow : MonoBehaviour
    {
      [SerializeField] private UICardTip tip;
      [SerializeField] private PlayerClickHandler clickHandler;

      private bool isTipHandCard;

      private void Awake()
      {
        clickHandler.ClickedCard += OnHandCardClicked;
        clickHandler.RemovedCard += OnCardRemove;
        FieldCell.Entered += OnCellEntered;
        FieldCell.Exited += OnCellExited;
      }

      private void OnDestroy()
      {
        clickHandler.ClickedCard -= OnHandCardClicked;
        clickHandler.RemovedCard -= OnCardRemove;
        FieldCell.Entered -= OnCellEntered;
        FieldCell.Exited -= OnCellExited;
      }

      private void OnHandCardClicked(CardStaticData data)
      {
        isTipHandCard = true;
        tip.SetView(data);
      }

      private void OnCellEntered(CardStaticData data)
      {
        if (isTipHandCard || clickHandler.IsStopped)
          return;
        
        tip.SetView(data);
      }

      private void OnCellExited()
      {
        if (isTipHandCard || clickHandler.IsStopped)
          return;
        tip.Disable();
      }

      private void OnCardRemove()
      {
        tip.Disable();
        isTipHandCard = false;
      }
    }
}
