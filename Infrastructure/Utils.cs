using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Infrastructure
{
    public static class Utils
    {
        public static IEnumerable<MethodInfo> CallExtensionMethods(Assembly assemblyWithExtensionMethods, Type type)
            => assemblyWithExtensionMethods.GetTypes().Where(t => !t.IsGenericType && !t.IsNested)
                .SelectMany(t => t.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(m => m.IsDefined(typeof(ExtensionAttribute), true) && m.GetParameters()[0].ParameterType == type);

        public static TEntity CallExtensionMethod<TEntity>(Assembly assemblyWithExtensionMethods, object extendedClassObject, string methodName)
            => (TEntity)CallExtensionMethods(assemblyWithExtensionMethods, extendedClassObject.GetType())
                .FirstOrDefault(m => m.Name == methodName).Invoke(extendedClassObject, new object[] { extendedClassObject });
    }
}
