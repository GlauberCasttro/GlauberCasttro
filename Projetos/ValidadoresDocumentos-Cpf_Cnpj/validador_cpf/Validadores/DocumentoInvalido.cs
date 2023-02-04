using Validador_Documento.Enum;

namespace Validador_Documento.Validadores
{
    public class DocumentoInvalido : IValidador, IDocumentType
    {
        public static DocumentoInvalido Init() => new();

        public ETipoDocumento GetTypeDocument() => ETipoDocumento.NaoInformadoOuNaoValido;

        public IDocumentType IsValid(string source)
        {
            return this;
        }
    }
}