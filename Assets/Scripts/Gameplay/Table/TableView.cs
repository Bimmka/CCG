using UnityEngine;

namespace Gameplay.Table
{
    public class TableView : MonoBehaviour
    {
      [SerializeField] private Transform startSpawnPoint;
      [SerializeField] private Transform playerDeckParent;

      public Vector3 SpawnLocalPosition => startSpawnPoint.localPosition;
      public Transform PlayerDeckParent => playerDeckParent;
    }
}
