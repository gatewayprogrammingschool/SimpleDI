using System;
using System.Collections.Generic;

namespace GPS.SimpleDI.Tests
{
    public partial class SimpleDiFactoryTests
    {
        private class SampleInjectable : IInjectable
        {
            public string TypeNamespace { get; set; } = "Test";
            public string TypeName { get; set; } = "Test.Test";
            public List<List<Parameter>> Constructors { get; set; } = new List<List<Parameter>> { { new List<Parameter> { new Parameter { Name = "value", TypeName = "System.String", TypeNamespace = "mscorlib " } } } };
            public List<Method> Methods { get; set; } =
                new List<Method> { new Method { Name = "Method", ReturnType = "void", Parameters = new List<Parameter> { } } };

            public object MakeObject(List<Parameter> parameters)
            {
                var assm = System.Reflection.Assembly.Load(TypeNamespace);

                var itype = System.Type.GetType(TypeName,
                    null,
                    (assembly, name, b) =>
                        assm.GetType(name, true, b),
                    true, false);


                var passm = System.Reflection.Assembly.Load(parameters[0].TypeNamespace);

                var ptype = System.Type.GetType(
                    parameters[0].TypeName,
                    null,
                    (assembly, name, b) =>
                        passm.GetType(name, true, b),
                    true,
                    false);

                var param1 = Activator.CreateInstance(
                            ptype,
                            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance,
                            null,
                            new[] { (parameters[0].Value as string).ToCharArray() },
                            System.Globalization.CultureInfo.CurrentCulture
                        );

                var obj = Activator.CreateInstance(
                    itype, 
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, 
                    null,
                    new[] { param1 },
                    System.Globalization.CultureInfo.CurrentCulture);

                return obj;
            }

            public object MakeObject()
            {
                throw new ApplicationException("No Default Constructor for this type.");
            }
        }
    }
}