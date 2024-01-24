## Projeto GoodHambuger
 
## Descrição
 
>Projeto desenvolvido para testes solicitado em entrevista
 
## Execução local
 
>Para a execução local, siga as intruções abaixo:
 
```console
 
# Clone o repositório
 
$ git clone <repo>
 
# Acesse o projeto terminal/cmd
 
$ cd <pasta-exemplo>
 
# Execute o banco de dados (SqlServer)
 
$ docker run -d --name goodhamburger-sqldb-local -p 1433:1433 -e "MSSQL_SA_PASSWORD=senha@123" -e "ACCEPT_EULA=Y" mcr.microsoft.com/mssql/server:2022-latest
 

# Execute as migrations
 
$ dotnet ef database update -s ./WebApi/WebApi.WebApi -p ./Infra.Repository/Infra.Repository./ -v
 
# Execute a api em dotnet
 
$ dotnet run --project WebApi/WebApi.WebApi.csproj
 
# A aplicação será executada na porta 5000
 
acesse  <http://localhost:5000>
 
# Acesse a documentação swagger
 
acesse  <http://localhost:5000/swagger/index.html>
 
 
# Execute testes automatizados
 
$ dotnet test
 
```
 