using System.Diagnostics;

namespace OptimizationGC
{
    internal static class Helper
    {
        public static void RunWorking(Action action)
        {
            Console.WriteLine("Start");
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);

            sw.Start();

            action.Invoke();

            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds}ms");
            Console.WriteLine($"GC Gen #2 : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1 : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0 : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");
        }
    }
}
