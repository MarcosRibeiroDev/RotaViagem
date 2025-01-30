namespace RotaViagem.Domain.Entities;

public class Rota
{
    public string Origem { get; private set; }
    public string Destino { get; private set; }
    public int Valor { get; private set; }

    public Rota(string origem, string destino, int valor)
    {
        Origem = origem;
        Destino = destino;
        Valor = valor;
    }
}
