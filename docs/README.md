# Simple Dependency Injection
### Copyright 2017 - Gateway Programming School, Inc.

## What is it?
SimpleDI is a new dependency injection system that is highly extensible.  It currently ships with an Injector and Loader for JSON-based objects.

## How to use it...
First, create an instance of IInjectable.  This class will then be used as the target of a class implementing IDefintionLoader<IInjectable>.

##Example:
First you need to define the injectable.

    public class Sample : IInjectable {
        string TypeName {get;set;} = "MyNamespace.MyType";
        string TypeNamespace {get;set;} = "MyNamespace";
        public List<List<Parameter>> Constructors { get; set; } = new List<List<Parameter>>();
        public List<Method> Methods { get; set; } =
                new List<Method> { new Method { Name = "Method", ReturnType = "void", Parameters = new List<Parameter> { } } };

        public object MakeObject()
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

            var obj = Activator.CreateInstance(
                itype, 
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public, 
                null,
                new object[0],
                System.Globalization.CultureInfo.CurrentCulture);

            return obj;
        }

        public object MakeObject(List<Parameter> parameters)
        {
            throw new ApplicationException("No Parameterized Constructor for this type.");
        }
    }

Next you define the loader.

    public class SampleLoader : IDefintionLoader<Sample>
    {
        public SampleLoader() { }

        public Sample LoadDefintion()
        {
            return new Sample();
        }
    }

Now you can call the Factory to get your injector:

    var obj = SimpleDiFactory.Load(typeof(Sample));

Finally, you call the injector to get your object:

    var myClass = obj.MakeObject();

Of course, you can hold on to the instance of the loader if
the constructor of your target class takes parameters.  In that
case you would call.

    var myClass = obj.MakeObject(a, b, c);

Where a, b, and c are parameters to the constructor.