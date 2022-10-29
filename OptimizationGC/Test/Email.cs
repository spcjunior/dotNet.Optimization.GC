namespace OptimizationGC.Test
{
    public static class Email
    {
        public static class Varsion1
        {
            public class Email
            {
                private readonly string _value;

                public readonly bool EhValido;

                private Email(string value)
                {
                    _value = value;

                    EhValido = !string.IsNullOrEmpty(value) && value.Contains('@') && value.Contains(".com");
                }

                public static implicit operator Email(string value)
                    => new(value);

                public override string ToString() => _value;
            }

            public static bool ValidarEmail(Email sourceEmail) =>
                sourceEmail.EhValido;
        }

        public static class Varsion2
        {
            public struct Email
            {
                private readonly string _value;

                public readonly bool EhValido;

                private Email(string value)
                {
                    _value = value;

                    EhValido = !string.IsNullOrEmpty(value) && value.Contains('@') && value.Contains(".com");
                }

                public static implicit operator Email(string value)
                    => new(value);

                public override string ToString() => _value;
            }

            public static bool ValidarEmail(Email sourceEmail) =>
                sourceEmail.EhValido;
        }

    }
}
