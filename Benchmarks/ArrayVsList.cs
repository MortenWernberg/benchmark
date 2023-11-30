using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
    public class ArrayVsList
    {
        [GlobalSetup]
        public void GlobalSetup()
        {

        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
        }

        [Benchmark(Baseline = true)]
        public void List()
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < 100000; i++) { strings.Add(((char)i).ToString()); }
        }

        [Benchmark]
        public void Array()
        {
            string[] strings = new string[100000];
            for (int i = 0; i < 100000; i++) { strings[i] = ((char)i).ToString(); }
        }
    }
}
