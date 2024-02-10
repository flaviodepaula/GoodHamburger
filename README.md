## Project: GoodHambuger
 
## Description
 
>Project developed for tests purpose on a tech company
 
## Follow the instructions below to run the project
 
```console
 
# Clone the repository
 
$ git clone <repo>
 
# open the project path on terminal/cmd
 
$ cd <folder>
 
# Execute the following docker command to run a SQL Server database
 
$ docker run -d --name goodhamburger-sqldb-local -p 1433:1433 -e "MSSQL_SA_PASSWORD=senha@123" -e "ACCEPT_EULA=Y" mcr.microsoft.com/mssql/server:2022-latest
  
# Execute the migrations - My database is hosted on Docker/WSL(Ubuntu)

$ dotnet ef database update -s .\WebApi\WebApi.csproj  -p .\Infra.Repository\ -v
 
# Run the API 
 
$  dotnet run --project .\WebApi\WebApi.csproj
 
# The application will be run on port 5000
 
 <http://localhost:5000>
 
# Swagger documentation
 
<http://localhost:5000/swagger/index.html>
 
  
# SQL script to get itens from database
 SELECT ord.[OrderId], [TotalAmount], prd.Description, prd.Value
  FROM [dbo].[Orders] ord
  inner join [dbo].[OrdersProducts] ordprd on ordprd.OrderId = ord.OrderId
  inner join [dbo].[Products] prd on prd.ProductId = ordprd.ProductId
   
 SELECT *  FROM [goodhamburger-sqldb-local].[dbo].[Products]

```
 
