using Validador_Documento.Enum;

namespace Validador_Documento.Validadores
{
    public class ValidadorCpf 
        : IValidador, 
        IDocumentType
    {
        public static ValidadorCpf Init() => new();

        private static bool _documentValid;

        private static void Validated(Cpf sourceCPF) => _documentValid = sourceCPF.IsValid();

        public IDocumentType IsValid(string source)
        {
            Validated(source);
            return this;
        }

        public ETipoDocumento GetTypeDocument()
        {
            if (_documentValid)
                return ETipoDocumento.Cpf;

            return ETipoDocumento.NaoInformadoOuNaoValido;
        }
    }
}