using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
  public class LastVsIndexVsRange
  {
    private readonly List<string> _characters = new List<string>();

    [GlobalSetup]
    public void GlobalSetup()
    {
      for (int i = 0; i < 100000; i++) { _characters.Add(((char)i).ToString()); }
    }

    [GlobalCleanup]
    public void GlobalCleanup()
    {
    }

    [Benchmark(Baseline = true)]
    public string EnumerableLast()
    {
      return _characters.Last();
    }

    [Benchmark]
    public string IndexFromEnd()
    {
      return _characters[^1];
    }

    [Benchmark]
    public string Index()
    {
      return _characters[_characters.Count - 1];
    }
  }
}
