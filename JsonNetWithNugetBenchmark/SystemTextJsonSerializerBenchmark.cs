using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Environments;

namespace JsonNetWithNugetBenchmark;

[HideColumns("Job", "StdDev", "Error", "RatioSD")]
//[NotTouchPowerPlanSimpleJob]
public class SystemTextJsonSerializerBenchmark
{
    private static readonly JsonSerializerOptions Options = new() { WriteIndented = true };
    
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
    
    [Benchmark(Description = "System.Text.Json")]
    public string ToJson()
    {
        return JsonSerializer.Serialize(_obj, Options);
    }
}