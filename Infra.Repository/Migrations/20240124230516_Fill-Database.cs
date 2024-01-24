using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Repository.Migrations
{
    public partial class FillDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = "";
            sql = " INSERT INTO [dbo].[Products] ([ProductId],[Description],[Value],[Category]) VALUES(NEWID() , 'X Burger', 5, 'Sandwich'); \r\n ";
            sql += " INSERT INTO [dbo].[Products] ([ProductId],[Description],[Value],[Category]) VALUES(NEWID() , 'X Egg', 4.5, 'Sandwich'); \r\n ";
            sql += " INSERT INTO [dbo].[Products] ([ProductId],[Description],[Value],[Category]) VALUES(NEWID() , 'X Bacon', 7, 'Sandwich'); \r\n ";
            sql += " INSERT INTO [dbo].[Products] ([ProductId],[Description],[Value],[Category]) VALUES(NEWID() , 'Fries', 2, 'Fries'); \r\n ";
            sql += " INSERT INTO [dbo].[Products] ([ProductId],[Description],[Value],[Category]) VALUES(NEWID() , 'Soft Drink', 2.5, 'Soft Drink'); \r\n ";

            migrationBuilder.Sql(sql);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = " DELETE FROM  [dbo].[Products] ";

            migrationBuilder.Sql(sql);
        }
    }
}
