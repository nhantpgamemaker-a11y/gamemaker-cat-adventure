using System;

namespace GameMaker.Core.Editor
{
    public class TypeHolderAttribute: Attribute
    {
        private Type _type;
        public Type Type => _type;
        public TypeHolderAttribute(Type type)
        {
            _type = type;
        }
    }
}