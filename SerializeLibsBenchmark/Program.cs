﻿using BenchmarkDotNet.Running;

namespace SerializeLibsBenchmark;

class Program
{
    static void Main(string[] args)
    {
        BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}