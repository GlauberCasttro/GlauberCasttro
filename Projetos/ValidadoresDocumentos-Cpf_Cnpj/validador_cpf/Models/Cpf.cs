public partial struct Cpf
{
    private readonly string _value;

    private Cpf(string value) => _value = value;

    public static implicit operator Cpf(string value) => new(value);

    public override string ToString() => _value;

    public bool IsValid() => ValidarDigitosDoDocumento();

    private bool ValidarDigitosDoDocumento()
    {
        if (CalculaNumeroDeDigitos() != 11)
            return false;

        int totalDigitoI = 0;
        int totalDigitoII = 0;

        if (VerficarSeTodosOsDigitosSaoIdenticos())
        {
            return false;
        }

        for (int posicao = 0; posicao < 9; posicao++)
        {
            var digito = ObterDigito(posicao);
            totalDigitoI += digito * (10 - posicao);
            totalDigitoII += digito * (11 - posicao);
        }

        var modI = totalDigitoI % 11;
        if (modI < 2) { modI = 0; }
        else { modI = 11 - modI; }

        if (ObterDigito(9) != modI)
        {
            return false;
        }

        totalDigitoII += modI * 2;

        var modII = totalDigitoII % 11;
        if (modII < 2) { modII = 0; }
        else { modII = 11 - modII; }

        if (ObterDigito(10) != modII)
        {
            return false;
        }

        return true;
    }
}