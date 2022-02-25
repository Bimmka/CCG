using Gameplay.Table;
using UnityEngine;

namespace StaticData.Gameplay.Table
{
  [CreateAssetMenu(fileName = "FieldCreateStaticData", menuName = "Static Data / GamePlay / Field Creating", order = 52)]
  public class FieldCreateStaticData : ScriptableObject
  {
    public Vector3 TableSpawnPosition;
    public Vector2Int FieldSize = new Vector2Int(3,4);
    public Vector2 ElementsOffset;
    public TableView TablePrefab;
    public FieldCell MapCellPrefab;
  }
}