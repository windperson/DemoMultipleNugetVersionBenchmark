using BenchmarkDotNet.Attributes;
using SerializeLibsBenchmark.AssemblyResolvers;

namespace SerializeLibsBenchmark;

[MemoryDiagnoser(displayGenColumns: true)]
[HideColumns("StdDev", "Error", "RatioSD")]
[ReturnValueValidator(failOnError: true)]
public class JsonSerializerBenchmarks
{
    private object _obj = null!;

    [GlobalSetup]
    public void Setup()
    {
        _obj = new
        {
            Name = "John Doe",
            Age = 30,
            Address = "123 Main",
            City = "Anytown",
            IsCitizen = true
        };
        AppDomain.CurrentDomain.AssemblyResolve += JsonDotNetAssemblyResolver.OnAssemblyResolve;
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        AppDomain.CurrentDomain.AssemblyResolve -= JsonDotNetAssemblyResolver.OnAssemblyResolve;
    }

    [Benchmark(Description = "Json.NET v12.x")]
    public string Lib_Alpha_ToJSON()
    {
        return ClassLibAlpha.SerializeTool.ToJSON(_obj);
    }

    [Benchmark(Description = "Json.NET v13.x", Baseline = true)]
    public string Lib_Beta_ToJSON()
    {
        return ClassLibBeta.SerializeTool.ToJSON(_obj);
    }

    [Benchmark(Description = "System.Text.Json")]
    public string Lib_Gamma_ToJSON()
    {
        return ClassLibGamma.SerializeTool.ToJSON(_obj);
    }
}