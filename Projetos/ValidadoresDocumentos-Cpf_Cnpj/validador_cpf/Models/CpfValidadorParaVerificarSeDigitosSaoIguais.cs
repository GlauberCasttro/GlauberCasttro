// See https://aka.ms/new-console-template for more information

public partial struct Cpf
{
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
}