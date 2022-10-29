using System.Runtime.CompilerServices;

namespace OptimizationGC.Test
{
    public static class Cpf
    {
        public static class Version1
        {
            public static bool ValidarCPF(string sourceCPF)
            {
                if (string.IsNullOrWhiteSpace(sourceCPF))
                    return false;

                string clearCPF;
                clearCPF = sourceCPF.Trim();
                clearCPF = clearCPF.Replace("-", "");
                clearCPF = clearCPF.Replace(".", "");

                if (clearCPF.Length != 11)
                {
                    return false;
                }

                int[] cpfArray;
                int totalDigitoI = 0;
                int totalDigitoII = 0;
                int modI;
                int modII;

                if (clearCPF.Equals("00000000000") ||
                    clearCPF.Equals("11111111111") ||
                    clearCPF.Equals("22222222222") ||
                    clearCPF.Equals("33333333333") ||
                    clearCPF.Equals("44444444444") ||
                    clearCPF.Equals("55555555555") ||
                    clearCPF.Equals("66666666666") ||
                    clearCPF.Equals("77777777777") ||
                    clearCPF.Equals("88888888888") ||
                    clearCPF.Equals("99999999999"))
                {
                    return false;
                }

                foreach (char c in clearCPF)
                {
                    if (!char.IsNumber(c))
                    {
                        return false;
                    }
                }

                cpfArray = new int[11];
                for (int i = 0; i < clearCPF.Length; i++)
                {
                    cpfArray[i] = int.Parse(clearCPF[i].ToString());
                }

                for (int posicao = 0; posicao < cpfArray.Length - 2; posicao++)
                {
                    totalDigitoI += cpfArray[posicao] * (10 - posicao);
                    totalDigitoII += cpfArray[posicao] * (11 - posicao);
                }

                modI = totalDigitoI % 11;
                if (modI < 2) { modI = 0; }
                else { modI = 11 - modI; }

                if (cpfArray[9] != modI)
                {
                    return false;
                }

                totalDigitoII += modI * 2;

                modII = totalDigitoII % 11;
                if (modII < 2) { modII = 0; }
                else { modII = 11 - modII; }
                if (cpfArray[10] != modII)
                {
                    return false;
                }
                // CPF Válido!
                return true;
            }
        }

        public static class Version2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int ObterDigito(string value, int pos) => value[pos] - '0';

            public static bool ValidarCPF(string sourceCPF)
            {
                if (string.IsNullOrWhiteSpace(sourceCPF))
                    return false;

                var clearCPF = sourceCPF.Trim();
                clearCPF = clearCPF.Replace("-", "");
                clearCPF = clearCPF.Replace(".", "");

                if (clearCPF.Length != 11)
                {
                    return false;
                }

                int totalDigitoI = 0;
                int totalDigitoII = 0;

                if (clearCPF.Equals("00000000000") ||
                    clearCPF.Equals("11111111111") ||
                    clearCPF.Equals("22222222222") ||
                    clearCPF.Equals("33333333333") ||
                    clearCPF.Equals("44444444444") ||
                    clearCPF.Equals("55555555555") ||
                    clearCPF.Equals("66666666666") ||
                    clearCPF.Equals("77777777777") ||
                    clearCPF.Equals("88888888888") ||
                    clearCPF.Equals("99999999999"))
                {
                    return false;
                }

                foreach (char c in clearCPF)
                {
                    if (!char.IsNumber(c))
                    {
                        return false;
                    }
                }
                for (int posicao = 0; posicao < clearCPF.Length - 2; posicao++)
                {
                    totalDigitoI += ObterDigito(clearCPF, posicao) * (10 - posicao);
                    totalDigitoII += ObterDigito(clearCPF, posicao) * (11 - posicao);
                }

                var modI = totalDigitoI % 11;
                if (modI < 2) { modI = 0; }
                else { modI = 11 - modI; }

                if (ObterDigito(clearCPF, 9) != modI)
                {
                    return false;
                }

                totalDigitoII += modI * 2;
                var modII = totalDigitoII % 11;
                if (modII < 2) { modII = 0; }
                else { modII = 11 - modII; }

                if (ObterDigito(clearCPF, 10) != modII)
                {
                    return false;
                }
                return true;
            }
        }

        public static class Version3
        {
            public struct Cpf
            {
                private readonly string _value;

                private Cpf(string value)
                {
                    _value = value;

                }

                public int CalculaNumeroDeDigitos()
                {
                    if (_value == null)
                    {
                        return 0;
                    }

                    var result = 0;
                    for (var i = 0; i < _value.Length; i++)
                    {
                        if (char.IsDigit(_value[i]))
                        {
                            result++;
                        }
                    }

                    return result;
                }

                public bool VerficarSeTodosOsDigitosSaoIdenticos()
                {
                    var previous = -1;
                    for (var i = 0; i < _value.Length; i++)
                    {
                        if (char.IsDigit(_value[i]))
                        {
                            var digito = _value[i] - '0';
                            if (previous == -1)
                            {
                                previous = digito;
                            }
                            else
                            {
                                if (previous != digito)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    return true;
                }

                public int ObterDigito(int posicao)
                {
                    int count = 0;
                    for (int i = 0; i < _value.Length; i++)
                    {
                        if (char.IsDigit(_value[i]))
                        {
                            if (count == posicao)
                            {
                                return _value[i] - '0';
                            }
                            count++;
                        }
                    }

                    return 0;
                }

                public static implicit operator Cpf(string value)
                    => new(value);

                public override string ToString() => _value;
            }

            public static bool ValidarCPF(Cpf sourceCPF)
            {
                if (sourceCPF.CalculaNumeroDeDigitos() != 11)
                {
                    return false;
                }

                int totalDigitoI = 0;
                int totalDigitoII = 0;

                if (sourceCPF.VerficarSeTodosOsDigitosSaoIdenticos())
                {
                    return false;
                }

                for (int posicao = 0; posicao < 9; posicao++)
                {
                    var digito = sourceCPF.ObterDigito(posicao);
                    totalDigitoI += digito * (10 - posicao);
                    totalDigitoII += digito * (11 - posicao);
                }

                var modI = totalDigitoI % 11;
                if (modI < 2) { modI = 0; }
                else { modI = 11 - modI; }

                if (sourceCPF.ObterDigito(9) != modI)
                {
                    return false;
                }

                totalDigitoII += modI * 2;

                var modII = totalDigitoII % 11;
                if (modII < 2) { modII = 0; }
                else { modII = 11 - modII; }

                if (sourceCPF.ObterDigito(10) != modII)
                {
                    return false;
                }

                return true;
            }
        }

        public static class Version4
        {
            public struct Cpf
            {
                private readonly string _value;

                public readonly bool EhValido;
                private Cpf(string value)
                {
                    _value = value;

                    if (value == null)
                    {
                        EhValido = false;
                        return;
                    }

                    var posicao = 0;
                    var totalDigito1 = 0;
                    var totalDigito2 = 0;
                    var dv1 = 0;
                    var dv2 = 0;

                    bool digitosIdenticos = true;
                    var ultimoDigito = -1;

                    foreach (var c in value)
                    {
                        if (char.IsDigit(c))
                        {
                            var digito = c - '0';
                            if (posicao != 0 && ultimoDigito != digito)
                            {
                                digitosIdenticos = false;
                            }

                            ultimoDigito = digito;
                            if (posicao < 9)
                            {
                                totalDigito1 += digito * (10 - posicao);
                                totalDigito2 += digito * (11 - posicao);
                            }
                            else if (posicao == 9)
                            {
                                dv1 = digito;
                            }
                            else if (posicao == 10)
                            {
                                dv2 = digito;
                            }

                            posicao++;
                        }
                    }

                    if (posicao > 11)
                    {
                        EhValido = false;
                        return;
                    }

                    if (digitosIdenticos)
                    {
                        EhValido = false;
                        return;
                    }

                    var digito1 = totalDigito1 % 11;
                    digito1 = digito1 < 2
                        ? 0
                        : 11 - digito1;

                    if (dv1 != digito1)
                    {
                        EhValido = false;
                        return;
                    }

                    totalDigito2 += digito1 * 2;
                    var digito2 = totalDigito2 % 11;
                    digito2 = digito2 < 2
                        ? 0
                        : 11 - digito2;

                    EhValido = dv2 == digito2;
                }

                public static implicit operator Cpf(string value)
                    => new(value);

                public override string ToString() => _value;
            }

            public static bool ValidarCPF(Cpf sourceCPF) =>
                sourceCPF.EhValido;
        }
    }
}
