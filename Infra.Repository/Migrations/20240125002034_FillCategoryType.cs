using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FillCategoryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = "";
            sql = " Update [dbo].[Products] SET CategoryType = Category; \r\n ";
            sql += " Update [dbo].[Products] SET CategoryType = 'Extras' WHERE CategoryType != 'Sandwich'; \r\n ";
             
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
