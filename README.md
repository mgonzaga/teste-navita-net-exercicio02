# Gerenciador de patrim�nios
API Rest para gerenciamento de patr�nios de uma empresa.
## Tecnologias utilizadas:
- ASP .NET Core 3.0 WebAPI
- Banco de dados SQL Server
- Aut�ntica��o por Token JWT (Expira��o em 8 horas)
  
## Bibliotecas utlizadas para desenvolvimento
- Entity Framework Core 3.1.3
- Swagger (Swashbuckle.AspNetCore 5.2.1)
- AutoMapper 9.0

Para esta aplica��o, utilizei os seguintes padr�es de desenvolvimento:
### 1. MVC
### 2. Invers�o de controle
Nenhum objeto � inst�nciado diretamente dentro dos m�todos, todos os objetos s�o injetados diretamente no construtor da classe.
### 3. Inje��o de Depend�ncia
Framework de inje��o de depend�ncia nativo do ASP .NET Core.
### 4. Code First
As Domains models s�o criadas diretamente no projeto "Domain" e posteriormente s�o criadas no banco de dados utilizando a ferramenta de Migration.
## Guia de instala��o
1. Fazer o Download do .NET Core 3.0 ([Clique Aqui](https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral "Clique Aqui"))
2. Fazer a instala��o no computador.
3. Criar banco de dados no SQL Server utilizado o arquivo de Scripts "BancoDeDados.SQL".
3. Abrir o projeto no Visual Studio 2019
4. Clicar com o Bot�o direito do mouse no projeto WebAPI e selecionar a Op��o "Manage User Secrets". 
5. Colar o JSON Abaixo dentro da secrets, substituindo [Servidor], [NomeDoBanco], [Usu�rio], [Senha] pelas informa��es do Seu banco de dados.
> {
  "DatabaseConnectionString": "Data Source=[Servidor];Initial Catalog=[NomeDoBanco];Integrated Security=false;User Id=[Usu�rio];password=[Senha]"
}
6. Executar o projeto.
