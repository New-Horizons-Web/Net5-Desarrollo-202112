using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.BikeStore.Web.API.Infrastructure.Persistence.Migrations
{
    public partial class Add_Description_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "production",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "production",
                table: "categories");
        }
    }
}
