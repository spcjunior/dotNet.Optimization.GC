using BenchmarkDotNet.Running;

namespace OptimizationGC
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<BenchEmail>();
            BenchmarkRunner.Run<BenchCpf>();
        }
    }

}