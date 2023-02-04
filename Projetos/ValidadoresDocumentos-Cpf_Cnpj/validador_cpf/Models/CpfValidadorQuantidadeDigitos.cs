// See https://aka.ms/new-console-template for more information

public partial struct Cpf
{
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
}