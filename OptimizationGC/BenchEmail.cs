using BenchmarkDotNet.Attributes;
using OptimizationGC.Test;

namespace OptimizationGC
{
    [MemoryDiagnoser()]
    public class BenchEmail
    {
        [Benchmark]
        public void EmailV1()
        {
            Func<Email.Varsion1.Email, bool> func = Email.Varsion1.ValidarEmail;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("sebastiao@gmail.com"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }

        [Benchmark]
        public void EmailV2()
        {
            Func<Email.Varsion2.Email, bool> func = Email.Varsion2.ValidarEmail;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("sebastiao@gmail.com"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }
    }

}