using Microsoft.EntityFrameworkCore.Migrations;

namespace Niculae_Ana_Maria_Pagina_Web.Data.Migrations
{
    public partial class AngajatTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    WorkTime = table.Column<string>(nullable: true),
                    MyShopId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Angajat_Shop_MyShopId",
                        column: x => x.MyShopId,
                        principalTable: "Shop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajat_MyShopId",
                table: "Angajat",
                column: "MyShopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
