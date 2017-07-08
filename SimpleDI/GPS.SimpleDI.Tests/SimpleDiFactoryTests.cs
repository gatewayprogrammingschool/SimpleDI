using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GPS.SimpleDI.Tests
{
    [TestClass]
    public partial class SimpleDiFactoryTests
    {
        [TestMethod]
        public void JsonLoadTestDefaultConstructor()
        {
            JsonDependencyLoader loader = new JsonDependencyLoader();

            var jsonInjectableBase = loader.LoadDefintion();

            Assert.IsNotNull(jsonInjectableBase, "Loader returned null.");
            Assert.IsInstanceOfType(jsonInjectableBase, typeof(JsonInjectableBase),
                "Returned object is not of type JsonInjectableBase");

            Assert.AreEqual("GPS.SimpleDI", jsonInjectableBase.TypeNamespace);

            var instance = jsonInjectableBase.MakeObject();

            Assert.IsNotNull(instance, "Could not create instance of JsonInjectableBase.");
            Assert.IsInstanceOfType(instance, typeof(JsonInjectableBase));
        }

        [TestMethod]
        public void LoadSample()
        {
            var loader = new SampleLoader();

            var sampleInjectable = loader.LoadDefintion();

            Assert.IsNotNull(sampleInjectable, "Loader returned null.");
            Assert.IsInstanceOfType(sampleInjectable, typeof(SampleInjectable));

            var instance = sampleInjectable.MakeObject(new List<Parameter>
            { new Parameter {
                TypeNamespace = "mscorlib",
                TypeName = "System.String",
                Name = "value",
                Value ="Created!" } }) as Test.Test;

            Assert.IsNotNull(instance, "Could not create instance of JsonInjectableBase.");
            Assert.IsInstanceOfType(instance, typeof(Test.Test));
            Assert.AreEqual("Created!", instance.value);
        }
    }
}