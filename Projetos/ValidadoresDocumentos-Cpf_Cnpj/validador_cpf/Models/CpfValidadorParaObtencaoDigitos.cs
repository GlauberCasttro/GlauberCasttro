// See https://aka.ms/new-console-template for more information

public partial struct Cpf
{
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
}