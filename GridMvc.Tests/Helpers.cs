using System;
using System.Linq;
using System.Reflection;

namespace GridMvc.Tests
{
    static class Helpers
    {
        public static T GetAttribute<T>(this PropertyInfo pi)
        {
            return (T)pi.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }

        public static T GetAttribute<T>(this Type type)
        {
            return (T)type.GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }
    }
}
