using System;
using System.Collections.Generic;
using System.Linq;

namespace GameMaker.Core.Runtime
{
    public static class TypeUtils
    {
        public static IReadOnlyList<Type> GetAllDerivedNonAbstractTypes(Type baseType)
        {
            return TypeCache.Instance.GetAllDerivedNonAbstractTypes(baseType);
        }
         /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// Not include param type
        /// <returns></returns>
        public static IReadOnlyList<Type> GetAllConcreteDerivedTypes(Type baseType)
        {
            return TypeCache.Instance.GetAllConcreteDerivedTypes(baseType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// <returns></returns> <summary>
        /// 
        /// </summary>
        /// <param name="baseType"></param>
        /// Include param type if not abstract
        /// <returns></returns>
        public static IReadOnlyList<Type> GetAllConcreteAssignableTypes(Type baseType)
        {
            return TypeCache.Instance.GetAllConcreteAssignableTypes(baseType);
        }
    }
}