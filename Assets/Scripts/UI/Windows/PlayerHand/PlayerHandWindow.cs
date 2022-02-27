using System;
using System.Collections.Generic;
using Gameplay.Cards.Hand;
using Services.Assets;
using Services.Random;
using StaticData.Gameplay.Cards.Elements;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Windows.PlayerHand
{
  public class PlayerHandWindow : MonoBehaviour
  {
    [SerializeField] private Button endTurnButton;
    [SerializeField] private RectTransform cardsParent;
    [SerializeField] private GameplayPlayerHand playerHand;
    [SerializeField] private UIPlayerHandCard prefab;

    private readonly List<UIPlayerHandCard> cardsInHand = new List<UIPlayerHandCard>(10);
    private readonly Queue<UIPlayerHandCard> pool = new Queue<UIPlayerHandCard>(10);
    
    private IAssetProvider assets;
    private IRandomService randomService;

    public event Action<CardStaticData> Clicked;
    public event Action EndTurnClicked;
    public event Func<bool> IsCanClicked;
    
    [Inject]
    private void Construct(IAssetProvider assetProvider, IRandomService randomService)
    {
      assets = assetProvider;
      this.randomService = randomService;
    }

    private void Awake()
    {
      playerHand.AddedCard += OnCardAdded;
      playerHand.RemovedCard += OnCardRemoved;
      endTurnButton.onClick.AddListener(NotifyAboutEndTurnClick);
    }

    private void OnDestroy()
    {
      playerHand.AddedCard -= OnCardAdded;
      playerHand.RemovedCard -= OnCardRemoved;
      endTurnButton.onClick.RemoveListener(NotifyAboutEndTurnClick);
    }

    public void ReturnCard(CardStaticData card)
    {
      Debug.Log("Returned Card");
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
      cardInHand.ResetData();
      cardInHand.transform.SetParent(transform, true);
      cardInHand.Hide(() => OnCardRemoved(cardInHand));
    }

    private void OnCardRemoved(UIPlayerHandCard cardInHand)
    {
      cardsInHand.Remove(cardInHand);
      
      pool.Enqueue(cardInHand);
    }

    private void ReinitCardFromPool(CardStaticData card)
    {
      UIPlayerHandCard cardInHand = pool.Dequeue();
      cardInHand.SetData(card);
      cardInHand.transform.SetParent(cardsParent);
      cardInHand.transform.SetAsLastSibling();
      cardInHand.Show();
      SaveInHand(cardInHand);
    }

    private void CreateCard(CardStaticData card)
    {
      UIPlayerHandCard cardInHand = assets.Instantiate(prefab, cardsParent);
      cardInHand.Construct(randomService);
      cardInHand.Clicked += OnCardClick;
      cardInHand.ForceHide();
      cardInHand.SetData(card);
      cardInHand.Show();
      SaveInHand(cardInHand);
    }

    private void SaveInHand(UIPlayerHandCard cardInHand)
    {
      cardsInHand.Add(cardInHand);
    }

    private void OnCardClick(CardStaticData card)
    {
      if (IsCanClicked.Invoke())
        Clicked?.Invoke(card);
    }

    private void NotifyAboutEndTurnClick()
    {
      EndTurnClicked?.Invoke();
    }
  }
}