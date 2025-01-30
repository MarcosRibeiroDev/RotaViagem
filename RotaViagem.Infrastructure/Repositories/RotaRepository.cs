using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Infrastructure.Repositories;

public class RotaRepository : IRotaRepository
{
    private readonly string _arquivo = "rotas.txt";

    public void AdicionarRota(Rota rota)
    {
        var linha = $"{rota.Origem},{rota.Destino},{rota.Valor}";
        File.AppendAllLines(_arquivo, new[] { linha });
    }

    public List<Rota> ObterRotas()
    {
        if (!File.Exists(_arquivo))
            return new List<Rota>();

        var linhas = File.ReadAllLines(_arquivo);
        return linhas.Select(linha =>
        {
            var partes = linha.Split(',');
            return new Rota(partes[0], partes[1], int.Parse(partes[2]));
        }).ToList();
    }
}
