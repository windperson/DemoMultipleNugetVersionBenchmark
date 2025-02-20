using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;

namespace ClassLibAlphaBenchmark;

[HideColumns("Job", "StdDev", "Error")]
[Orderer(SummaryOrderPolicy.Declared)]
//[SimpleJob(runtimeMoniker: RuntimeMoniker.Net80)]
//[SimpleJob(runtimeMoniker: RuntimeMoniker.Net90)]
public class JsonSerializerBenchmark
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
    }

    [Benchmark(Description = "Json.NET v12.x")]
    public string Lib_Alpha_ToJSON()
    {
        return ClassLibAlpha.SerializeTool.ToJSON(_obj);
    }
}