
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlay
{
    public class LayerControllerEditor : MonoBehaviour
    {
        [SerializeField] private SortingGroup _sortingGroup;
        public void SetSortingOrder(int order)
        {
            _sortingGroup.sortingOrder = -order;
        }
        public float GetZIndex()
        {
            return transform.position.z;
        }
        public Vector3 GetScale()
        {
            return transform.localScale;
        }
    }
}
