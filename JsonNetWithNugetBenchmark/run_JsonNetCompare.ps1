$run_command = "dotnet run --configuration Release -- --filter 'JsonNetWithNugetBenchmark.JsonNetSerializerBenchmark.ToJsonString'"

Write-Host "Running command:`n$run_command"
Invoke-Expression $run_command
exit