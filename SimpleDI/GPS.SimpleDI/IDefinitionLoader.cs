using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public interface IDefinitionLoader<T> where T: IInjectable
    {
        T LoadDefintion();
    }
}
