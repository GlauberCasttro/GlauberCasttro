using Validador_Documento.Validadores;

namespace Validador_Documento.Factory
{
    public static class ValidadorFactory
    {
        public static IValidador Factory(string source)
        {
            if (source.Length == 11)
                return ValidadorCpf.Init();

            if (source.Length == 14)
                return ValidadorCnpj.Init();

            return DocumentoInvalido.Init();
        }
    }
}