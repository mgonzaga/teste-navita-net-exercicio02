# Gerenciador de patrimônios
API Rest para gerenciamento de patrônios de uma empresa.
## Tecnologias utilizadas:
- ASP .NET Core 3.1.3
- Banco de dados SQL Server
- Autênticação por Token
  
## Bibliotecas utlizadas para desenvolvimento
- Entity Framework Core 3.1.3
- Swagger (Swashbuckle.AspNetCore 5.2.1)
- AutoMapper 9.0

Para esta aplicação, utilizei os seguintes padrões de desenvolvimento:
### 1. MVC
Padrão de projetos mais utilizado no mundo
### 3. Inversão de controle
Nenhum objeto é instânciado diretamente dentro dos métodos, todos os objetos são injetados diretamente no construtor da classe.
### 2. Injeção de Dependência
Framework de injeção de dependência nativo do ASP .NET Core.
### 3. Code First
As Domains models são criadas diretamente no projeto "Domain" e posteriormente são criadas no banco de dados utilizando a ferramenta de Migration.
## Guia de instalação
1. Fazer o Download do .NET Core 3.1 ([Clique Aqui](https://download.visualstudio.microsoft.com/download/pr/56131147-65ea-47d6-a945-b0296c86e510/44b43b7cb27d55081e650b9a4188a419/dotnet-sdk-3.1.201-win-x64.exe "Clique Aqui"))
2. Fazer a instalação no computador.
3. Criar banco de dados no SQL Server utilizado o arquivo de Scripts "BancoDeDados.SQL".
3. Abrir o projeto no Visual Studio 2019
4. Clicar com o Botão direito do mouse no projeto WebAPI e selecionar a Opção "Manage User Secrets". 
5. Colar o JSON Abaixo dentro da secrets, substituindo [Servidor], [NomeDoBanco], [Usuário], [Senha] pelas informações do Seu banco de dados.
> {
  "DatabaseConnectionString": "Data Source=[Servidor];Initial Catalog=[NomeDoBanco];Integrated Security=false;User Id=[Usuário];password=[Senha]"
}
6. Executar o projeto.
