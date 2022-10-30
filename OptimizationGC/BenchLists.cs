using BenchmarkDotNet.Attributes;

namespace OptimizationGC
{
    [MemoryDiagnoser]
    public class BenchLists
    {
        private static IEnumerable<int> _listBase = Enumerable.Range(1, 500_000);

        [Benchmark]
        public void ListsV1()
        {
            var result = _listBase.Select(a => (a, "maria")).ToList();
        }

        [Benchmark]
        public void ListsV2()
        {
            var result = _listBase.Select(a => (a, "maria"));
        }
    }
}