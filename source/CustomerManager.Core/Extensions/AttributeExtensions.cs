using System;
using System.Linq;

namespace CustomerManager.Core.Extensions
{
    public static class AttributeExtensions
    {
        #region Extension Methods
        
        public static TValue GetAttribute<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> selector)
            where TAttribute : Attribute
        {
            var attr = (type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute);
            return (attr != null ? selector(attr) : default(TValue));
        }


        public static bool TryGetAttribute<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> selector, out TValue value)
            where TAttribute : Attribute
        {
            value = default(TValue);

            var attr = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            if (attr != null)
            {
                value = selector(attr);
                return true;
            }

            return false;            
        }


        #endregion
    }
}
