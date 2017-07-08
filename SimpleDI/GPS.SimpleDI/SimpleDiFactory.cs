using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public static class SimpleDiFactory
    {
        public static IInjectable Load<T>(T loader) 
            where T: IDefinitionLoader<IInjectable>
        {
            return loader.LoadDefintion();
        }
    }
}
