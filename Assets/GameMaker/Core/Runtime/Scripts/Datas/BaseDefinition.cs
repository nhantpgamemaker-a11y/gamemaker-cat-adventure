using System;
using Newtonsoft.Json;
using UnityEngine;


namespace GameMaker.Core.Runtime
{
    [System.Serializable]
    public abstract class BaseDefinition : IDefinition,
                                    ITitle,
                                    IIcon,
                                    IDescription,
                                    IMetaData,
                                    ICloneable, IEquatable<BaseDefinition>
    {
        [SerializeField]
        private string _id;
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _title;

        [SerializeField] 
        private Sprite _icon;

        [SerializeField]
        private string _description;

        [SerializeField]
        private BaseMetaData _metaData;

        protected BaseDefinition() : base()
        {
            _id = Guid.NewGuid().ToString();
            _name = "";
            _title = "";
        }

        public BaseDefinition(string id, string name, string title, string description, Sprite icon)
        {
            this._id = id;
            this._name = name;
            this._title = title;
            _description = description;
            _icon = icon;
        }
        
        public string GetID()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public abstract object Clone();
        
        public bool Equals(BaseDefinition other)
        {
            return other.GetID() == _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public Sprite GetIcon()
        {
            return _icon;
        }


        public string GetDescription()
        {
            return _description;
        }

        public BaseMetaData GetMetaData()
        {
            return _metaData;
        }
    }
}
