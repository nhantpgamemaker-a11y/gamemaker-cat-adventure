using System;
using UnityEngine;

namespace GamePlay
{
    [System.Serializable]
    public class EnvironmentLayerData
    {
        [UnityEngine.SerializeField]
        private Vector3 _scale;
        [UnityEngine.SerializeField]
        private float _zIndex;
        [UnityEngine.SerializeField]
          private int _sortingOrder;

        public Vector3 Scale { get => _scale; set => _scale = value; }
        public float ZIndex { get => _zIndex; set => _zIndex = value; }
        public int SortingOrder { get => _sortingOrder; set => _sortingOrder = value; }
        public EnvironmentLayerData( Vector3 scale, float zIndex, int sortingOrder)
        {
            _scale = scale;
            _zIndex = zIndex;
            _sortingOrder = sortingOrder;
        }

        internal int GetSortingOrder()
        {
            return _sortingOrder;
        }
    }
}