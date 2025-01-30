using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;
using RotaViagem.Domain.Services;

namespace RotaViagem.Test;

[TestClass]
public class RotaServiceTests
{
    private RotaService _rotaService;

    [TestInitialize]
    public void TestInitialize()
    {
        var rotaRepository = new RotaRepositoryMock();
        _rotaService = new RotaService(rotaRepository);

        rotaRepository.AdicionarRota(new Rota("GRU", "BRC", 10));
        rotaRepository.AdicionarRota(new Rota("BRC", "SCL", 5));
        rotaRepository.AdicionarRota(new Rota("SCL", "ORL", 20));
        rotaRepository.AdicionarRota(new Rota("ORL", "CDG", 5));
        rotaRepository.AdicionarRota(new Rota("GRU", "SCL", 20));
        rotaRepository.AdicionarRota(new Rota("GRU", "ORL", 56));
    }

    [TestMethod]
    public void ConsultarMelhorRota_DeveRetornarRotaMaisBarata()
    {
        // Arrange
        string origem = "GRU";
        string destino = "CDG";

        // Act
        var resultado = _rotaService.ConsultarMelhorRota(origem, destino);

        // Assert
        string expected = "GRU - BRC - SCL - ORL - CDG ao custo de $40";
        Assert.AreEqual(expected, resultado, "A melhor rota não foi encontrada corretamente.");
    }

    [TestMethod]
    public void ConsultarMelhorRota_NaoDeveEncontrarRotaSeNaoExistir()
    {
        // Arrange
        string origem = "GRU";
        string destino = "XXX";

        // Act
        var resultado = _rotaService.ConsultarMelhorRota(origem, destino);

        // Assert
        string expected = "Rota não encontrada!";
        Assert.AreEqual(expected, resultado, "A rota não deveria ser encontrada.");
    }

    [TestMethod]
    public void ConsultarMelhorRota_DeveRetornarRotaComMenorCusto()
    {
        // Arrange
        string origem = "GRU";
        string destino = "CDG";

        // Act
        var resultado = _rotaService.ConsultarMelhorRota(origem, destino);

        // Assert
        string expected = "GRU - BRC - SCL - ORL - CDG ao custo de $40";
        Assert.AreEqual(expected, resultado, "A melhor rota com menor custo não foi encontrada.");
    }
}

public class RotaRepositoryMock : IRotaRepository
{
    private List<Rota> _rotas = new List<Rota>();

    public void AdicionarRota(Rota rota)
    {
        _rotas.Add(rota);
    }

    public List<Rota> ObterRotas()
    {
        return _rotas;
    }
}

