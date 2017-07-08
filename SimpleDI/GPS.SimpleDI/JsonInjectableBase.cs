using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public class JsonInjectableBase : IInjectable
    {
        public virtual string TypeNamespace { get; set; }
        public virtual string TypeName { get; set; }
        public virtual List<List<Parameter>> Constructors { get; set; }
        public virtual List<Method> Methods { get; set; }

        public object MakeObject()
        {
            object obj = Activator.CreateInstance(
                TypeNamespace, TypeName).Unwrap();

            return obj;
        }

        public object MakeObject(List<Parameter> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
