using BenchmarkDotNet.Running;

namespace OptimizationGC
{
    internal static partial class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<BenchEmail>();
            //BenchmarkRunner.Run<BenchCpf>();            
            //BenchmarkRunner.Run<BenchSplitString>();
            BenchmarkRunner.Run<BenchLists>();
        }
    }

}