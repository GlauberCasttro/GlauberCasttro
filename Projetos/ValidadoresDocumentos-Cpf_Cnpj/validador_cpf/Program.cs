// See https://aka.ms/new-console-template for more information
using System;
using Validador_Documento.Enum;
using Validador_Documento.Factory;

Console.WriteLine("Hello, World!");

var tipoDocumento = "10742473619".ValidarDocumento();
var tipoDocumento2 = "10742473617".ValidarDocumento();
var tipoDocumento3 = "88117535000198".ValidarDocumento();

Console.WriteLine(tipoDocumento);
Console.WriteLine(tipoDocumento2);
Console.WriteLine(tipoDocumento3);

public static class ValidadorDocumento
{
    public static ETipoDocumento ValidarDocumento(this string source)
    {
        if (string.IsNullOrEmpty(source)) throw new ArgumentNullException(nameof(source));
        ETipoDocumento documento = ETipoDocumento.NaoInformadoOuNaoValido;

        documento = ValidadorFactory
            .Factory(source)
            .IsValid(source)
            .GetTypeDocument();

        return documento;
    }
}