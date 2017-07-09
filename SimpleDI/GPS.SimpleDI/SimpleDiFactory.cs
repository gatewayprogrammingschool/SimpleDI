using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public static class SimpleDiFactory
    {
        public static IInjectable Load(Type type, params object[] parameters) 
        {
            Trace.WriteLine($"Type to load Assembly {type.Assembly.FullName}, Item {type.FullName}");
            if (parameters.Length == 0)
            {
#if TRACE
                parameters.ToList().ForEach(p => Trace.WriteLine($"Parameter: {p}"));
#endif

                var loader = Activator.CreateInstance(type.Assembly.FullName, type.FullName)?.Unwrap() as IDefinitionLoader<IInjectable>;

                if(loader == null) throw new ApplicationException("Loader is not available.");

                return loader.LoadDefintion();
            }

            dynamic l = Activator.CreateInstance(type, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, parameters, System.Globalization.CultureInfo.CurrentCulture);

            return l.LoadDefintion();
        }
    }
}
