using UnityEngine;

namespace Gameplay.Table
{
    public class Field : MonoBehaviour
    {
      [SerializeField] private Transform startSpawnPoint;

      public Vector3 SpawnLocalPosition => startSpawnPoint.localPosition;
    }
}
