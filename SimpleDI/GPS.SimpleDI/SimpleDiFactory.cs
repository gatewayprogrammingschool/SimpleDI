using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public static class SimpleDiFactory
    {
        public static IInjectable Load(Type type, params object[] parameters) 
        {
            if (parameters.Length == 0)
            {
                var loader = Activator.CreateInstance(type.Assembly.FullName, type.FullName).Unwrap() as IDefinitionLoader<IInjectable>;

                //dynamic loader = type.GetConstructor(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, new Type[0], null).Invoke(parameters);

                return loader.LoadDefintion() as IInjectable;
            }

            dynamic l = Activator.CreateInstance(type, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance, null, parameters, System.Globalization.CultureInfo.CurrentCulture);

            return l.LoadDefintion();
        }
    }
}
