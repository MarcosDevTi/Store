namespace Store.Application.Automapper
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            AutoMapperConfigurator.LoadMapsFromCallerAndReferencedAssemblies();
        }
    }
}
