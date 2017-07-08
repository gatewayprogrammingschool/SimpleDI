namespace GPS.SimpleDI.Tests
{
    public partial class SimpleDiFactoryTests
    {
        private class SampleLoader : IDefinitionLoader<SampleInjectable>
        {
            public SampleInjectable LoadDefintion()
            {
                return new SampleInjectable();
            }
        }
    }
}