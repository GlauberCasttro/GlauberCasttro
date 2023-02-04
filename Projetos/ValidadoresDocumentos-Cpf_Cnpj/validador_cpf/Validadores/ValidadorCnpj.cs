using Validador_Documento.Enum;

namespace Validador_Documento.Validadores
{
    public class ValidadorCnpj : IValidador, IDocumentType
    {
        public static ValidadorCnpj Init() => new();

        private static bool _documentValid;

        private static void Validated(Cnpj sourceCnpj) => _documentValid = sourceCnpj.IsValid();

        public IDocumentType IsValid(string source)
        {
            Validated(source);
            return this;
        }

        public ETipoDocumento GetTypeDocument()
        {
            if (_documentValid)
                return ETipoDocumento.Cnpj;

            return ETipoDocumento.NaoInformadoOuNaoValido;
        }
    }
}