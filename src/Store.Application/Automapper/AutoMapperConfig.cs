using System;
using System.Reflection;

namespace Store.Application.Automapper
{
    public static class AutoMapperConfig
    {
        public static void Configure(Func<AssemblyName, bool> assemblyFilter = null)
        {
            AutoMapperConfigurator.LoadMapsFromCallerAndReferencedAssemblies(assemblyFilter);
        }
    }
}
