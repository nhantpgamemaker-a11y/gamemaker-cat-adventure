using System;
using System.Linq;

namespace GameMaker.Core.Runtime
{
    public static class TypeUtils
    {
        public static Type[] GetAllDerivedNonAbstractTypes(Type baseType)
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => baseType.IsAssignableFrom(t)
                            && t != baseType
                            && !t.IsAbstract)
                .ToArray();
        }
    }
}