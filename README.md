<h1 align="center">Crud com DDD</h1>

<p align="center">Padrões de Projeto Utilizados: Incorporamos alguns padrões de projeto, como o Repository Pattern e o Dependency Injection, para promover a modularidade, reutilização de código e melhor organização do código-fonte. Além disso, adotamos o uso de DTOs (Data Transfer Objects) para a transferência de dados entre camadas, aumentando a segurança e a eficiência das operações. Utilizamos o Entity Framework, um ORM (Object-Relational Mapping), para facilitar o acesso aos dados de forma mais intuitiva.</p>


### Features

- [x] Cadastrar o cliente informando o nome completo, e-mail e uma lista de telefones informando o DDD, número e o tipo [fixo ou celular];
- [x] Permitir consultar todos os clientes com seus respectivos e-mails e telefones;
- [x] Permitir a consulta de um cliente através do DDD e número;
- [x] Permitir a atualização do e-mail do cliente cadastrado;
- [x] Permitir a atualização do telefone do cliente cadastrado;
- [x] Permitir a exclusão de um cliente através do e-mail.

Requisitos técnicos:

1 - Desenvolver em .Net 6.0;
2 - Utilizar base de dados local;
3 - Criar testes de unidade;
4 - Documentar a WebApi via Swagger.

Tecnologias utilizadas:

1 - Git: Utilizado para versionamento de código e clonagem de repositórios do GitHub para a máquina local.

2 - GitHub: Plataforma de hospedagem de código-fonte que permite colaboração e controle de versão usando o Git.

3 - Terminal (PowerShell, Git Bash ou Terminal): Ferramenta de linha de comando para interação com o sistema operacional, utilizada para navegar entre diretórios e executar comandos.

4 - Docker Desktop: Plataforma de contêineres que simplifica o processo de desenvolvimento, distribuição e execução de aplicativos em contêineres.

5 - Visual Studio 2022: IDE (Integrated Development Environment) utilizada para o desenvolvimento de aplicativos em diversas linguagens de programação, incluindo C#, .NET, e outras.

Essas tecnologias serão empregadas para clonar o projeto do GitHub, configurar o ambiente com Docker Desktop e Visual Studio 2022, e iniciar o desenvolvimento localmente.

### Pré-requisitos

# Clone este repositório
$ git clone git@github.com:diegopires1992/crud-ddd.git

# Acesse a pasta do projeto no terminal/cmd
$ cd API_DDD

Depois do Docker instalado podemos executar o docker compose para iniciar o banco de dados sqlserver:

![docker](https://github.com/diegopires1992/crud-ddd/assets/66563440/293e90b4-cc50-431c-97f9-e7f46a5c8fc1)

Agora executar o comando para fazer o migração para banco:

![migrations](https://github.com/diegopires1992/crud-ddd/assets/66563440/ea61921f-5c2d-4567-ac8c-af8a5a17b905)

Depois disso vamos usar o visual studio para executar:

![start](https://github.com/diegopires1992/crud-ddd/assets/66563440/99a3450f-8b12-4c62-89ce-288fa2dae780)

Depois de executar vamos tem acesso Swagger:


![Swagger](https://github.com/diegopires1992/crud-ddd/assets/66563440/5ce00a4c-d452-47b9-8cf8-a33ae5ac3a5c)




