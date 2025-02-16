#Requires -Version 7

$ErrorActionPreference = "Stop"
& $PSScriptRoot\..\libs\clean_global-packages.ps1
& $PSScriptRoot\..\libs\build_libs.ps1

$run_command = "dotnet run --configuration Release --framework net9.0 -- --filter 'SerializeLibsBenchmark.JsonSerializerBenchmarks.*'"

Write-Host "Running command:`n$run_command"
Invoke-Expression $run_command
exit