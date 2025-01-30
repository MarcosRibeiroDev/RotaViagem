# Sistema de Rota de Viagem

Este projeto é uma aplicação para calcular a melhor rota de viagem entre dois pontos, levando em consideração o custo total das rotas, mesmo que haja conexões entre diferentes cidades. O objetivo é encontrar a rota mais barata, independentemente do número de conexões.

## Funcionalidades

1. **Registrar novas rotas**: O usuário pode registrar rotas entre diferentes cidades com o custo associado.
2. **Consultar melhor rota**: O sistema calcula a melhor rota entre dois pontos, considerando o custo total das rotas e conexões.

### Requisitos

- **.NET SDK**: Este projeto foi desenvolvido com o .NET SDK 8.0.
- **Editor de código**: Recomendamos o Visual Studio ou Visual Studio Code.

### Estrutura de persistência
**Arquivo TXT**: Está sendo usado um arquivo .txt para persistência de dados. 

### Passos para Execução

1. **Instalar o .NET SDK**:
   - Certifique-se de ter o .NET SDK instalado. Você pode baixá-lo [aqui](https://dotnet.microsoft.com/download).

2. **Clonar o repositório**:
   - Clone o repositório do projeto para a sua máquina local:
   ```bash
   git clone https://github.com/MarcosRibeiroDev/RotaViagem.git
   
3. Compile o projeto:
   ```bash
   dotnet build
   ```
4. Execute o programa:
   ```bash
   dotnet run --project RotaViagem.UI
   ```
   
## Como Usar o Sistema

### Registrar Nova Rota
1. Escolha a opção **1. Registrar nova rota** no menu principal.
2. Insira os dados solicitados:
   - Ponto de origem (ex: GRU)
   - Ponto de destino (ex: CDG)
   - Custo da rota (ex: 40)
3. A rota será salva no arquivo .txt

### Consultar Melhor Rota
1. Escolha a opção **2. Consultar melhor rota** no menu principal.
2. Insira os pontos de origem e destino no formato `ORIGEM-DESTINO` (ex: GRU-CDG).
3. O sistema calculará a rota com o menor custo e exibirá o resultado no formato:
   ```
   Melhor Rota: GRU -> BRC -> SCL -> ORL -> CDG ao custo de $40
   ```

## Exemplo de Uso
Dado o seguinte cenário de rotas:
1. GRU - BRC - SCL - ORL - CDG ao custo de $40
2. GRU - ORL - CDG ao custo de $61
3. GRU - CDG ao custo de $75
4. GRU - SCL - ORL - CDG ao custo de $45

Ao consultar a melhor rota de **GRU** para **CDG**, o sistema exibiria:
```
Melhor Rota: GRU -> BRC -> SCL -> ORL -> CDG ao custo de $40
```

## Estrutura do Projeto
  **RotaViagem.UI**              # UI
   -  Program                      # Interface de linha de comando para interação com o usuário.
  **RotaViagem.Domain**          # Lógica de domínio (Entidades, Serviços, Repositórios)
   -  Entities                    # Entidades do domínio (Rota.cs)
   -  Services                    # Serviços do domínio (RotaService.cs)
   -  Repositories                # Interfaces de repositórios (IRotaRepository.cs)
  **RotaViagem.Application**     # Casos de uso
   -  Application                 # Casos de uso (RegistrarRotaApplication.cs, ConsultarMelhorRotaApplication.cs)
  **RotaViagem.Infrastructure**  # Implementações concretas
   -  Repositories                # Implementações do repositório (RotaRepository.cs)
  **RotaViagem.Tests**           # Testes unitários
   -  RotaServiceTests.cs         # Testes do serviço de rota
  
## Explicação das Camadas:
Core: Contém a lógica de domínio, incluindo entidades como Rota, serviços como RotaService e interfaces de repositório.
Application: Define os casos de uso, como registrar rotas e consultar a melhor rota.
Infrastructure: Implementação concreta do repositório, que manipula a persistência de dados (aqui, uma simples lista em memória).
Tests: Contém testes unitários para garantir que os serviços e a lógica de negócios funcionem corretamente.

## Decisões de Design
1. Domain-Driven Design (DDD):
Seguindo o padrão de Domain-Driven Design (DDD), a aplicação foi dividida em camadas:
Domain contém a lógica de domínio e regras de negócio.
Application lida com os casos de uso (fluxos da aplicação).
Infrastructure contém a implementação do repositório.
Esta separação facilita a manutenção, o teste e a evolução do sistema.
2. Testes Unitários:
A aplicação foi projetada para ser facilmente testável. Os testes unitários são isolados e rápidos, utilizando mocks para simular a persistência de dados.
Os testes foram implementados usando o framework MSTest.
3. Princípio da Responsabilidade Única (SRP):
Cada classe e módulo possui uma única responsabilidade. Por exemplo, a classe RotaService lida apenas com a lógica de cálculo da melhor rota, enquanto a classe RotaRepository lida apenas com o armazenamento e recuperação das rotas.
4. Uso de Repositórios:
O repositório de rotas segue o princípio da abstração. A interface IRotaRepository permite que o código de domínio (em Domain) não se preocupe com os detalhes de persistência, tornando o sistema flexível e fácil de testar.