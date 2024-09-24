using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqPerformance9;

[MemoryDiagnoser(false)]
[SimpleJob(RuntimeMoniker.Net80, baseline:true)]
[SimpleJob(RuntimeMoniker.Net90)]
[HideColumns("Job", "Error", "StdDev", "Median", "RatioSD")]

public class Benchmark
{
    private IEnumerable<int> _list = Enumerable.Range(1, 1000).ToList();
    [Benchmark] public bool Any() => _list.Any(i => i == 1000);
    [Benchmark] public bool All() => _list.All(i => i >= 0);
    [Benchmark] public int Count() => _list.Count(i => i >= 0);
    [Benchmark] public int First() => _list.First(i => i == 999);
    [Benchmark] public int FirstOrDefault() => _list.FirstOrDefault(i => i == 999);
}