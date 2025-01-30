using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application;

public class RegistrarRotaApplication
{
    private readonly IRotaRepository _rotaRepository;

    public RegistrarRotaApplication(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public void Executar(string origem, string destino, int valor)
    {
        var rota = new Rota(origem, destino, valor);
        _rotaRepository.AdicionarRota(rota);
    }
}
