using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KISSG.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Welcomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstSectionColor = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    Motto = table.Column<string>(nullable: true),
                    MottoColor = table.Column<string>(nullable: true),
                    MainSectionBgColor = table.Column<string>(nullable: true),
                    MainSectionTxtColor = table.Column<string>(nullable: true),
                    MainSection = table.Column<string>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    Projects = table.Column<string>(nullable: true),
                    ContactSectionBgColor = table.Column<string>(nullable: true),
                    ContactSectionTxtColor = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Welcomes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Welcomes");
        }
    }
}
