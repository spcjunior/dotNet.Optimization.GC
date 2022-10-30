using BenchmarkDotNet.Attributes;

namespace OptimizationGC
{
    [MemoryDiagnoser]
    public class BenchSplitString
    {
        private static readonly string _date = "30 10 2022";

        [Benchmark]
        public (int day, int month, int year) SplitV1()
        {
            var dayAsText = _date.Substring(0, 2);
            var monthAsText = _date.Substring(3, 2);
            var yearAsText = _date.Substring(6);

            int day = int.Parse(dayAsText);
            int month = int.Parse(monthAsText);
            int year = int.Parse(yearAsText);

            return (day, month, year);
        }

        [Benchmark]
        public (int day, int month, int year) SplitV2()
        {
            ReadOnlySpan<char> dataAsText = _date;
            var dayAsText = dataAsText.Slice(0, 2);
            var monthAsText = dataAsText.Slice(3, 2);
            var yearAsText = dataAsText.Slice(6);            

            int day = int.Parse(dayAsText);
            int month = int.Parse(monthAsText);
            int year = int.Parse(yearAsText);

            return (day, month, year);
        }
    }

}