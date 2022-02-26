using UnityEngine;

namespace UI.Displaying
{
    public class CameraSetter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private void Awake()
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
