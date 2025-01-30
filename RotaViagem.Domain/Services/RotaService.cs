using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Domain.Services;

public class RotaService
{
    private readonly IRotaRepository _rotaRepository;

    public RotaService(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public string ConsultarMelhorRota(string origem, string destino)
    {
        var rotas = _rotaRepository.ObterRotas();
        var melhoresRotas = new List<List<Rota>>();

        var caminhoAtual = new List<Rota>();
        EncontrarRotas(origem, destino, rotas, caminhoAtual, melhoresRotas);

        if (melhoresRotas.Any())
        {
            var melhorRota = melhoresRotas
                .OrderBy(r => r.Sum(x => x.Valor))
                .FirstOrDefault();

            string descricaoCaminho = string.Empty;

            if (melhorRota.Count > 1)
            {
                descricaoCaminho = string.Join(" - ", melhorRota.Select(r => r.Origem)) + " - " + melhorRota.Select(l => l.Destino).Last() + " ao custo de $" + melhorRota.Sum(r => r.Valor);
            }
            else
            {
                descricaoCaminho = melhorRota[0].Origem + "-" + melhorRota[0].Destino + " ao custo de $" + melhorRota.Sum(r => r.Valor);
            }

            return descricaoCaminho;
        }

        return "Rota não encontrada!";
    }

    private void EncontrarRotas(string origem, string destino, List<Rota> rotas, List<Rota> caminhoAtual, List<List<Rota>> melhoresRotas)
    {
        if (origem == destino)
        {
            melhoresRotas.Add(new List<Rota>(caminhoAtual));
            return;
        }

        var rotasDisponiveis = rotas.Where(r => r.Origem == origem).ToList();

        foreach (var rota in rotasDisponiveis)
        {
            if (!caminhoAtual.Contains(rota))
            {
                caminhoAtual.Add(rota);

                EncontrarRotas(rota.Destino, destino, rotas, caminhoAtual, melhoresRotas);

                caminhoAtual.RemoveAt(caminhoAtual.Count - 1);
            }
        }
    }
}
