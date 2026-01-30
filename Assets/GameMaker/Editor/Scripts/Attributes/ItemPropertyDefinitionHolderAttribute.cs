using System;

namespace GameMaker.Core.Editor
{
    public class ItemPropertyDefinitionHolderAttribute: Attribute
    {
        private Type _type;
        public Type Type => _type;
        public ItemPropertyDefinitionHolderAttribute(Type type)
        {
            _type = type;
        }
    }
}