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
                                    ICloneable, IEquatable<BaseDefinition>
    {
        [SerializeField]
        protected string id;
        [SerializeField]
        protected string name;
        [SerializeField]
        protected string title;

        [SerializeField] protected Sprite icon;

        [SerializeField]
        protected string description;

        protected BaseDefinition() : base()
        {
            id = Guid.NewGuid().ToString();
            name = "";
            title = "";
        }

        public BaseDefinition(string id, string name, string title)
        {
            this.id = id;
            this.name = name;
            this.title = title;
        }
        
        public string GetID()
        {
            return id;
        }

        public string GetName()
        {
            return name;
        }

        internal void SetID(string id)
        {
            this.id = id;
        }

        internal void SetName(string name)
        {
            this.name = name;
        }
        public abstract object Clone();
        
        public bool Equals(BaseDefinition other)
        {
            return other.GetID() == id;
        }

        public string GetTitle()
        {
            return title;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public Sprite GetIcon()
        {
            return icon;
        }

        public void SetIcon(Sprite sprite)
        {
            this.icon = sprite;
        }

        public string GetDescription()
        {
            return description;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        void IDefinition.SetID(string id)
        {
            SetID(id);
        }

        void IDefinition.SetName(string name)
        {
            SetName(name);
        }
    }
}
