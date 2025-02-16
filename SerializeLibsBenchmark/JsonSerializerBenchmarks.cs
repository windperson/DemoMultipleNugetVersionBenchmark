using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using SerializeLibsBenchmark.AssemblyResolvers;

namespace SerializeLibsBenchmark;

[HideColumns("Job", "StdDev", "Error")]
[Orderer(SummaryOrderPolicy.Declared)]
[RankColumn]
[ReturnValueValidator(failOnError: true)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
[SimpleJob(runtimeMoniker: RuntimeMoniker.Net90)]
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

    [Benchmark(Description = "Json.NET v13.x")]
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