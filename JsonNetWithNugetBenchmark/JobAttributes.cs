using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace JsonNetWithNugetBenchmark;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly)]
public class NotTouchPowerPlanSimpleJobAttribute : Attribute, IConfigSource
{
    public IConfig Config { get; }

    public NotTouchPowerPlanSimpleJobAttribute()
    {
        var job = new Job("NotTouchPowerPlanSimpleJob");
        Config = ManualConfig.Create(DefaultConfig.Instance).AddJob(job.DontEnforcePowerPlan());
    }
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = true)]
public class NotTouchPowerPlanSimpleJobAttributeWithNuget : Attribute, IConfigSource
{
    
    public IConfig Config { get; }

    public NotTouchPowerPlanSimpleJobAttributeWithNuget(string nugetName, string nugetVersion)
    {
        var job = new Job("NotTouchPowerPlanSimpleJobWithNuget");
        Config = ManualConfig.Create(DefaultConfig.Instance).AddJob(job.DontEnforcePowerPlan().WithNuGet(nugetName, nugetVersion));
    }
}