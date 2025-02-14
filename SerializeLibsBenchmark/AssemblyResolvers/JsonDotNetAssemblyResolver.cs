using System.Reflection;
using System.Runtime.Loader;

namespace SerializeLibsBenchmark.AssemblyResolvers;

public static class JsonDotNetAssemblyResolver
{
       public static Assembly? OnAssemblyResolve(object? sender, ResolveEventArgs args)
       {
           // We only deal with Newtonsoft.Json assemblies
           if (!args.Name.Contains("Newtonsoft.Json"))
           {
               return null;
           }
   
           var assemblyName = new AssemblyName(args.Name);
           var assemblyVersion = assemblyName.Version;
   
           if (assemblyVersion == null)
           {
               return null;
           }
   
           var assemblyDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json_net_dlls");
           assemblyDirectory = Path.Combine(assemblyDirectory, assemblyVersion.Major <= 12 ? "ver_12" : "ver_13");
   
           var assemblyPath = Path.Combine(assemblyDirectory, $"{assemblyName.Name}.dll");
   
           if (File.Exists(assemblyPath))
           {
               try
               {
                   var assemblyLoadContext = new AssemblyLoadContext("JsonAssemblyContext");
                   // Load and return the assembly
                   Console.WriteLine($"Loading 'Newtonsoft.Json' assembly from path: {assemblyPath}");
                   return assemblyLoadContext.LoadFromAssemblyPath(assemblyPath);
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"Error loading assembly: {ex}");
               }
           }
   
           // Return null if the assembly could not be resolved
           return null;
       } 
}