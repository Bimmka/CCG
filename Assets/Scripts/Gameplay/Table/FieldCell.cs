﻿using Gameplay.Cards.CardsElement.Base;
using UnityEngine;

namespace Gameplay.Table
{
  [RequireComponent(typeof(BoxCollider))]
  public class FieldCell : MonoBehaviour
  {
    public Card CurrentCard { get; private set; }
    public Vector2Int GridPosition { get; private set; }
    public Vector3 LocalPosition => transform.localPosition;

    public void SetGridPosition(Vector2Int position)
    {
      GridPosition = position;
    }

    public void SetCard(Card card)
    {
      CurrentCard = card;
    }

    public void RemoveCard()
    {
      CurrentCard = null;
    }
  }
}