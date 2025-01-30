using RotaViagem.Domain.Services;

namespace RotaViagem.Application;

public class ConsultarMelhorRotaApplication
{
    private readonly RotaService _rotaService;

    public ConsultarMelhorRotaApplication(RotaService rotaService)
    {
        _rotaService = rotaService;
    }

    public string Executar(string origem, string destino)
    {
        return _rotaService.ConsultarMelhorRota(origem, destino);
    }
}
