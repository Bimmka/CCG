using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Gameplay.Table
{
  public class Field : MonoBehaviour
  {
    private Dictionary<Vector2Int, GameObject> field = new Dictionary<Vector2Int, GameObject>(9);
    
    public Vector2Int Size { get; private set; }
    
    public void ResetField()
    {
      Size = Vector2Int.zero;
      field.Clear();
    }

    public void SetSize(Vector2Int size)
    {
      Size = size;
    }

    public void AddCell(GameObject cell, Vector2Int position)
    {
      field.Add(position, cell);
    }
  }
}