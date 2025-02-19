using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = ManualConfig.Create(DefaultConfig.Instance)
    .AddJob(Job.Default.DontEnforcePowerPlan().WithNuGet([new NuGetReference("Newtonsoft.Json", "13.0.3")])
        .WithId("Json.NET 13.x"))
    .AddJob(Job.Default.DontEnforcePowerPlan().WithNuGet("Newtonsoft.Json", "12.0.3").WithId("Json.NET 12.x")
        .AsBaseline());
BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config);

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
