using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public static class SimpleDiFactory
    {
        public static IInjectable Load<T>(Type type, params object[] parameters) where T : class, IInjectable
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (type.Assembly == null) throw new ArgumentNullException(nameof(type.Assembly));
#if TRACE
            Console.WriteLine($"Type to load Assembly {type.Assembly.FullName}, Item {type.FullName}");
#endif
            if (parameters == null || parameters.Length == 0)
            {
                dynamic loader = Activator.CreateInstance(type.Assembly.FullName, type.FullName)?.Unwrap(); // as IDefinitionLoader<T>;

                if (loader == null) throw new ApplicationException("Loader is not available.");
                if (!(loader is IDefinitionLoader<T>))
                    throw new ApplicationException($"Loader is wrong type {loader.GetType().FullName}");

                return ((IDefinitionLoader<T>)loader).LoadDefintion();
            }
#if TRACE
            parameters?.ToList().ForEach(p => Console.WriteLine($"Parameter: {p}"));
#endif
            dynamic l = Activator.CreateInstance(
                type, 
                System.Reflection.BindingFlags.Public | 
                System.Reflection.BindingFlags.Instance, 
                null, 
                parameters, 
                System.Globalization.CultureInfo.CurrentCulture);

            if (l == null) throw new ApplicationException("Loader is not available.");
            if (!(l is IDefinitionLoader<T>))
                throw new ApplicationException($"Loader is wrong type {l.GetType().FullName}");

            return ((IDefinitionLoader<T>)l).LoadDefintion();
        }
    }
}
