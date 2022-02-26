using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Table
{
  public class Field : MonoBehaviour
  {
    private readonly Dictionary<Vector2Int, FieldCell> field = new Dictionary<Vector2Int, FieldCell>(15);

    public Transform FieldParent { get; private set; }
    public Transform PlayerDeckParent { get; private set; }
    public Vector2Int Size { get; private set; }
    public int FirstCommonRow => Size.y - PlayerRows - 2;
    public int PlayerRows { get; private set; }
    public IEnumerable<FieldCell> PlayerRow => field.Values.Where(x => x.GridPosition.y == Size.y - PlayerRows);
    public IEnumerable<FieldCell> OpponentDownRow => field.Values.Where(x => x.GridPosition.y == Size.y - PlayerRows - 1);

    public void SetFieldParent(Transform parent) => 
      FieldParent = parent;
    public void SetPlayerDeckParent(Transform parent) => 
      PlayerDeckParent = parent;

    public void SetSize(Vector2Int size) => 
      Size = size;

    public void SetPlayerRowsCount(int playerRows) => 
      this.PlayerRows = playerRows;

    public void AddCell(FieldCell cell, Vector2Int position) => 
      field.Add(position, cell);

    public List<FieldCell> OpponentPositions()
    {
      List<FieldCell> cells = new List<FieldCell>((Size.x - 1) * (Size.y-1));
      foreach (KeyValuePair<Vector2Int,FieldCell> fieldCell in field)
      {
        if (IsPlayerCell(fieldCell.Key) == false)
          cells.Add(fieldCell.Value);
      }

      return cells;
    }

    public List<FieldCell> TopRowPositions()
    {
      List<FieldCell> cells = new List<FieldCell>(Size.x);
      for (int i = 0; i < Size.x; i++)
      {
        cells.Add(field[new Vector2Int(i, 0)]);
      }

      return cells;
    }

    public bool IsPlayerCell(Vector2Int position)
    {
      return position.y == Size.y - PlayerRows;
    }

    public bool IsHaveCardInRow(int rowIndex)
    {
      for (int i = 0; i < Size.x; i++)
      {
        if (field[new Vector2Int(i, rowIndex)].IsFill)
          return true;
      }

      return false;
    }

    public void MoveCardInRowDown(int rowIndex)
    {
      FieldCell cell;
      FieldCell finishCell;
      for (int i = 0; i < Size.x; i++)
      {
        cell = field[new Vector2Int(i, rowIndex)];
        finishCell = field[new Vector2Int(i, rowIndex + 1)];
        if (cell.IsFill)
        {
          cell.CurrentCard.Mover.MoveTo(finishCell.OffsetedYLocalPosition);
          finishCell.SetCard(cell.CurrentCard);
          cell.RemoveCard();
        }
      }
      
    }

    public FieldCell Cell(Vector2Int gridPosition)
    {
      if (field.ContainsKey(gridPosition))
        return field[gridPosition];

      return null;
    }

    public void UnlockCells()
    {
      foreach (KeyValuePair<Vector2Int,FieldCell> fieldCell in field)
      {
        fieldCell.Value.Unlock();
      }
    }
  }
  
}