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
  
# Execute as migrations - My database is hosted on Docker/WSL(Ubuntu)

$ dotnet ef database update -s .\WebApi\WebApi.csproj  -p .\Infra.Repository\ -v
 
# Execute a api em dotnet
 
$  dotnet run --project .\WebApi\WebApi.csproj
 
# A aplicação será executada na porta 5000
 
acesse  <http://localhost:5000>
 
# Acesse a documentação swagger
 
acesse  <http://localhost:5000/swagger/index.html>
 
  
# SQL para buscar itens no banco de dados
 SELECT ord.[OrderId], [TotalAmount], prd.Description, prd.Value
  FROM [dbo].[Orders] ord
  inner join [dbo].[OrdersProducts] ordprd on ordprd.OrderId = ord.OrderId
  inner join [dbo].[Products] prd on prd.ProductId = ordprd.ProductId
   
 SELECT *  FROM [goodhamburger-sqldb-local].[dbo].[Products]

```
 
