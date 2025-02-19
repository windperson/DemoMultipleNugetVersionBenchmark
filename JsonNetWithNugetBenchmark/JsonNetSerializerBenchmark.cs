using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace JsonNetWithNugetBenchmark;

[HideColumns("Job", "StdDev", "Error", "RatioSD")]
//[NotTouchPowerPlanSimpleJobAttributeWithNuget("Newtonsoft.Json", "13.0.3")]
//[NotTouchPowerPlanSimpleJobAttributeWithNuget("Newtonsoft.Json", "12.0.3")]
public class JsonNetSerializerBenchmark
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

    [Benchmark(Description = "Json.NET")]
    public string ToJsonString()
    {
        return JsonConvert.SerializeObject(_obj, Formatting.Indented);
    }
}