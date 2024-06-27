# Fiap Desafio API

Esta API foi desenvolvida como parte do desafio do curso da FIAP para gerenciar medidas e índices de recursos ambientais.

## Como executar a API

### Com Docker Compose

1. Certifique-se de ter o Docker instalado em sua máquina.

2. Navegue até a pasta onde está localizado o arquivo `docker-compose.yml`.

3. Execute o seguinte comando para iniciar o projeto junto com o banco MySQL:
   docker-compose up

Com Dockerfile
Certifique-se de ter o Docker instalado em sua máquina.

Construa a imagem Docker a partir do Dockerfile:


docker build -t fiap-desafio-api .

Execute o contêiner a partir da imagem criada:
docker run -p 8080:8080 fiap-desafio-api
Com .NET CLI
Certifique-se de ter o SDK .NET 6 instalado em sua máquina.

Navegue até a pasta raiz do projeto e execute o seguinte comando:
dotnet run

Com IDE
Abra o projeto em sua IDE preferida (como Visual Studio ou Rider).

Compile e execute o projeto a partir da IDE.

Executando as Migrations
Certifique-se de que o banco de dados está atualizado executando as migrations. Navegue até a pasta raiz do projeto e execute o seguinte comando:

bash
dotnet ef database update
Arquivo de Estrutura do Banco de Dados
O arquivo estrutura.sql contém detalhes sobre a estrutura do banco de dados para referência.
Detalhes do Banco de Dados
Banco de dados: MySQL
Porta: 3306
Usuário: root
Senha: 123456
Funcionalidades da API
Autenticação por Token: Use o endpoint auth para obter um token JWT para autenticação.
Cadastro de Recursos: Registre os recursos que deseja monitorar junto com seus índices de saúde.
Envio de Medidas: Envie medições em tempo real para a API, que identificará recursos acima ou abaixo da média e salvará em uma tabela de alertas.