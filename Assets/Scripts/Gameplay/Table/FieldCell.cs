using ConstantsValue;
using Gameplay.Cards.CardsElement.Base;
using UnityEngine;

namespace Gameplay.Table
{
  [RequireComponent(typeof(BoxCollider))]
  public class FieldCell : MonoBehaviour
  {
    private int lockTurnsCount;
    
    public Card CurrentCard { get; private set; }
    public Vector2Int GridPosition { get; private set; }
    public PlayingZoneType Type { get; private set; }
    public bool IsLocking => lockTurnsCount > 0;
    public Vector3 OffsetedYLocalPosition => transform.localPosition + Vector3.up * Constants.YOffset;
    public bool IsFill => CurrentCard != null;

    public void SetCellType(PlayingZoneType type) => 
      Type = type;

    public void SetGridPosition(Vector2Int position) => 
      GridPosition = position;

    public void SetCard(Card card) => 
      CurrentCard = card;

    public void RemoveCard() => 
      CurrentCard = null;

    public void LockForNextTurn()
    {
      lockTurnsCount++;
    }

    public void Unlock()
    {
      if (lockTurnsCount > 0)
        lockTurnsCount--;
    }

    public void SetUnlockView()
    {
      
    }

    public void SetLockedView()
    {
      
    }
  }
}