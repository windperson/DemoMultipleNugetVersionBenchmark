#Requires -Version 7
param(
    [string[]]$NetRuntimes = @('net8.0', 'net9.0'),
    [string]$BuildFramework = 'net9.0'
)

$ErrorActionPreference = "Stop"

$run_command = "dotnet run --project $PSScriptRoot\ClassLibBetaBenchmark.csproj --configuration Release --framework $BuildFramework -- --runtimes $NetRuntimes --filter 'ClassLibBetaBenchmark.JsonSerializerBenchmark.*'"

Write-Host "Running command:`n$run_command"
Invoke-Expression $run_command
exit