using UnityEngine;

namespace GamePlay
{
    public class PositionControllerEditor : MonoBehaviour
    {
        public Vector2 GetPosition()
        {
            return transform.position;
        }
        public Vector3 GetScale()
        {
            return transform.localScale;
        }
        public LayerControllerEditor GetLayerControllerEditor()
        {
            return gameObject.GetComponentInParent<LayerControllerEditor>();
        }
    }
}
