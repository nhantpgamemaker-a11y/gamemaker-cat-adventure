using System;
using GameMaker.Core.Runtime;
using UnityEngine;

namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public abstract class PropertyActionData : BaseActionData
    {
        private string _propertyId;
        public string PropertyId { get => _propertyId; }
        public  PropertyActionData():base(){}
        public PropertyActionData(string propertyId, IExtendData extendData) : base(extendData)
        {
            _propertyId = propertyId;
        }
        public override bool Equals(BaseActionData other)
        {
            if (other == null)
                return false;

            if (GetType() != other.GetType())
                return false;

            if (other is not PropertyActionData o)
                return false;

            return _propertyId == o._propertyId;
        }
    }
}