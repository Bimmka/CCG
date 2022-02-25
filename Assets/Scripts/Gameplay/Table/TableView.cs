using UnityEngine;

namespace Gameplay.Table
{
    public class TableView : MonoBehaviour
    {
      [SerializeField] private Transform startSpawnPoint;

      public Vector3 SpawnLocalPosition => startSpawnPoint.localPosition;
    }
}
