using RotaViagem.Application;
using RotaViagem.Domain.Services;
using RotaViagem.Infrastructure.Repositories;

namespace RotaViagem.UI
{
    class Program
    {
        static string caminhoArquivo = "rotas.txt";

        static void Main(string[] args)
        {
            if (!File.Exists(caminhoArquivo))
            {
                AdicionarRotasIniciais();
            }

            var rotaRepository = new RotaRepository();
            var rotaService = new RotaService(rotaRepository);
            var registrarRotaUseCase = new RegistrarRotaApplication(rotaRepository);
            var consultarMelhorRotaUseCase = new ConsultarMelhorRotaApplication(rotaService);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao sistema de rotas!");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Registrar nova rota");
                Console.WriteLine("2 - Consultar melhor rota");
                Console.WriteLine("3 - Sair");

                var comando = Console.ReadLine();

                switch (comando)
                {
                    case "1":
                        RegistrarRota(registrarRotaUseCase);
                        break;
                    case "2":
                        ConsultarMelhorRota(consultarMelhorRotaUseCase);
                        break;
                    case "3":
                        Console.WriteLine("Obrigado por usar o sistema de rotas!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarRota(RegistrarRotaApplication registrarRotaUseCase)
        {
            Console.WriteLine("Registro de uma nova rota:");

            Console.WriteLine("Digite a origem:");
            var origem = Console.ReadLine()?.Trim().ToUpper();

            Console.WriteLine("Digite o destino:");
            var destino = Console.ReadLine()?.Trim().ToUpper();

            Console.WriteLine("Digite o valor da rota:");

            if (!decimal.TryParse(Console.ReadLine(), out var valor))
            {
                Console.WriteLine("Valor inválido. A operação foi cancelada.");
                Console.ReadKey();
                return;
            }

            if (string.IsNullOrWhiteSpace(origem) || string.IsNullOrWhiteSpace(destino))
            {
                Console.WriteLine("Origem ou destino inválido. A operação foi cancelada.");
                Console.ReadKey();
                return;
            }

            registrarRotaUseCase.Executar(origem, destino, (int)valor);
            Console.WriteLine("Rota registrada!");
        }

        private static void ConsultarMelhorRota(ConsultarMelhorRotaApplication consultarMelhorRotaUseCase)
        {
            Console.WriteLine("Consulta de melhor rota:");

            Console.Write("Digite a rota nesse exemplo 'ORIGEM-DESTINO' (ex: GRU-CDG): ");
            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                var pontos = input.Split('-');

                if (pontos.Length == 2)
                {
                    var origem = pontos[0].Trim().ToUpper();
                    var destino = pontos[1].Trim().ToUpper();

                    try
                    {
                        var resultado = consultarMelhorRotaUseCase.Executar(origem, destino);

                        if (!string.IsNullOrEmpty(resultado))
                        {
                            Console.WriteLine($"Melhor Rota: {resultado}");
                        }
                        else
                        {
                            Console.WriteLine("Nenhuma rota encontrada para os pontos fornecidos.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao buscar a rota: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Formato inválido. Por favor, use o formato 'ORIGEM-DESTINO'.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar.");
            Console.ReadKey();
        }

        static void AdicionarRotasIniciais()
        {
            string[] rotasIniciais = new string[]
            {
            "GRU,BRC,10",
            "BRC,SCL,5",
            "GRU,CDG,75",
            "GRU,SCL,20",
            "GRU,ORL,56",
            "ORL,CDG,5",
            "SCL,ORL,20"
            };

            try
            {
                File.WriteAllLines(caminhoArquivo, rotasIniciais);
                Console.WriteLine("Rotas iniciais adicionadas ao arquivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar rotas iniciais: {ex.Message}");
            }
        }
    }
}