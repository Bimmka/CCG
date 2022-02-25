using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Table
{
  public class Field : MonoBehaviour
  {
    private readonly Dictionary<Vector2Int, FieldCell> field = new Dictionary<Vector2Int, FieldCell>(15);
    
    public Transform FieldParent { get; private set; }
    public Vector2Int Size { get; private set; }
    
    public void SetFieldParent(Transform parent)
    {
      FieldParent = parent;
    }

    public void SetSize(Vector2Int size) => 
      Size = size;

    public void AddCell(FieldCell cell, Vector2Int position) => 
      field.Add(position, cell);

    public List<Vector3> RandomOpponentPositions()
    {
      List<Vector3> localPositions = new List<Vector3>((Size.x - 1) * (Size.y-1));
      foreach (KeyValuePair<Vector2Int,FieldCell> fieldCell in field)
      {
        if (IsPlayerCell(fieldCell.Key) == false)
          localPositions.Add(fieldCell.Value.LocalPosition);
      }

      return localPositions;
    }

    public List<Vector3> RandomTopRowPositions()
    {
      List<Vector3> localPositions = new List<Vector3>(Size.x);
      for (int i = 0; i < Size.x; i++)
      {
        localPositions.Add(field[new Vector2Int(i, 0)].LocalPosition);
      }

      return localPositions;
    }

    public bool IsPlayerCell(Vector2Int position)
    {
      return position.y == Size.y - 1;
    }


  }
  
}