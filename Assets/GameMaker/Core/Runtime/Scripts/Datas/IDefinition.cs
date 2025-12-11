using UnityEngine;

namespace GameMaker.Core.Runtime
{
    public interface IDefinition
    {
        public string GetID();

        public void SetID(string id);
        public string GetName();

        public void SetName(string name);
    }
}
