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
3. A rota será salva no banco de dados.

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