using RotaViagem.Domain.Entities;

namespace RotaViagem.Domain.Repositories;

public interface IRotaRepository
{
    void AdicionarRota(Rota rota);
    List<Rota> ObterRotas();
}
