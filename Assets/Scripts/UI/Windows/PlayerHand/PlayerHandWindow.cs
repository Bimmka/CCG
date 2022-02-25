using System;
using System.Collections.Generic;
using Gameplay.Cards.Hand;
using Services.Assets;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using Zenject;

namespace UI.Windows.PlayerHand
{
  public class PlayerHandWindow : MonoBehaviour
  {
    [SerializeField] private RectTransform cardsParent;
    [SerializeField] private GameplayPlayerHand playerHand;
    [SerializeField] private UIPlayerHandCard prefab;

    private readonly List<UIPlayerHandCard> cardsInHand = new List<UIPlayerHandCard>(10);
    private readonly Queue<UIPlayerHandCard> pool = new Queue<UIPlayerHandCard>(10);
    
    private IAssetProvider assets;

    [Inject]
    private void Construct(IAssetProvider assetProvider) => 
      assets = assetProvider;

    private void Awake()
    {
      playerHand.AddedCard += OnCardAdded;
      playerHand.RemovedCard += OnCardRemoved;
    }

    private void OnDestroy()
    {
      playerHand.AddedCard -= OnCardAdded;
      playerHand.RemovedCard -= OnCardRemoved;
    }

    private void OnCardAdded(CardStaticData card)
    {
      if (pool.Count > 0)
        ReinitCardFromPool(card);
      else
        CreateCard(card);
    }

    private void OnCardRemoved(CardStaticData card)
    {
      for (int i = 0; i < cardsInHand.Count; i++)
      {
        if (cardsInHand[i].CardID == card.ID)
        {
          RemoveCard(cardsInHand[i]);
          break;
        }
      }
    }

    private void RemoveCard(UIPlayerHandCard cardInHand)
    {
      cardInHand.Hide();
      cardInHand.ResetData();
      pool.Enqueue(cardInHand);
    }

    private void ReinitCardFromPool(CardStaticData card)
    {
      UIPlayerHandCard cardInHand = pool.Dequeue();
      cardInHand.SetData(card);
      cardInHand.transform.SetAsLastSibling();
      cardInHand.Show();
    }

    private void CreateCard(CardStaticData card)
    {
      UIPlayerHandCard cardInHand = assets.Instantiate(prefab, cardsParent);
      cardInHand.ForceHide();
      cardInHand.SetData(card);
      cardInHand.Show();
    }
  }
}