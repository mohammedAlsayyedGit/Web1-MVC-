using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class f1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tblcatagories",
                columns: table => new
                {
                    IDCata = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    catagoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tblcatagories", x => x.IDCata);
                });

            migrationBuilder.CreateTable(
                name: "TblPoducts",
                columns: table => new
                {
                    PCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatagoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPoducts", x => x.PCode);
                    table.ForeignKey(
                        name: "FK_TblPoducts_Tblcatagories_CatagoryId",
                        column: x => x.CatagoryId,
                        principalTable: "Tblcatagories",
                        principalColumn: "IDCata",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblPoducts_CatagoryId",
                table: "TblPoducts",
                column: "CatagoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPoducts");

            migrationBuilder.DropTable(
                name: "Tblcatagories");
        }
    }
}
