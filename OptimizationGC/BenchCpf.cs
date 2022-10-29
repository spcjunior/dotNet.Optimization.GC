using BenchmarkDotNet.Attributes;
using OptimizationGC.Test;

namespace OptimizationGC
{
    [MemoryDiagnoser()]
    public class BenchCpf
    {
        [Benchmark]
        public void CpfV1()
        {
            Func<string, bool> func = Cpf.Version1.ValidarCPF;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("771.189.500-33"))
                {
                    throw new ArgumentException("Error!");
                }

                if (func("771.189.500-34"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }

        [Benchmark]
        public void CpfV2()
        {
            Func<string, bool> func = Cpf.Version2.ValidarCPF;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("771.189.500-33"))
                {
                    throw new ArgumentException("Error!");
                }

                if (func("771.189.500-34"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }

        [Benchmark]
        public void CpfV3()
        {
            Func<Cpf.Version3.Cpf, bool> func = Cpf.Version3.ValidarCPF;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("771.189.500-33"))
                {
                    throw new ArgumentException("Error!");
                }

                if (func("771.189.500-34"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }

        [Benchmark]
        public void CpfV4()
        {
            Func<Cpf.Version4.Cpf, bool> func = Cpf.Version4.ValidarCPF;
            for (int i = 0; i < 2_000_000; i++)
            {
                if (!func("771.189.500-33"))
                {
                    throw new ArgumentException("Error!");
                }

                if (func("771.189.500-34"))
                {
                    throw new ArgumentException("Error!");
                }
            }
        }
    }

}