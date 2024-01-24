## Projeto GoodHambuger
 
## Descri��o
 
>Projeto desenvolvido para testes solicitado em entrevista
 
## Execu��o local
 
>Para a execu��o local, siga as intru��es abaixo:
 
```console
 
# Clone o reposit�rio
 
$ git clone <repo>
 
# Acesse o projeto terminal/cmd
 
$ cd <pasta-exemplo>
 
# Execute o banco de dados (SqlServer)
 
$ docker run -d --name goodhamburger-sqldb-local -p 1433:1433 -e "MSSQL_SA_PASSWORD=senha@123" -e "ACCEPT_EULA=Y" mcr.microsoft.com/mssql/server:2022-latest
 

# Execute as migrations
 
$ dotnet ef database update -s ./WebApi/WebApi.WebApi -p ./Infra.Repository/Infra.Repository./ -v
 
# Execute a api em dotnet
 
$ dotnet run --project WebApi/WebApi.WebApi.csproj
 
# A aplica��o ser� executada na porta 5000
 
acesse  <http://localhost:5000>
 
# Acesse a documenta��o swagger
 
acesse  <http://localhost:5000/swagger/index.html>
 
 
# Execute testes automatizados
 
$ dotnet test
 
```
 