using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace football_tournament_maker_mvc.Migrations
{
    public partial class CreateTeamDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Point",
                table: "Teams",
                newName: "Points");

            migrationBuilder.CreateTable(
                name: "TeamDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPlayedGames = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    TotalWon = table.Column<int>(type: "int", nullable: false),
                    TotalDrawn = table.Column<int>(type: "int", nullable: false),
                    TotalLost = table.Column<int>(type: "int", nullable: false),
                    TotalGoalsFor = table.Column<int>(type: "int", nullable: false),
                    TotalGoalsAgainst = table.Column<int>(type: "int", nullable: false),
                    TotalGoalDifference = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamDetails_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamDetails_TeamId",
                table: "TeamDetails",
                column: "TeamId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamDetails");

            migrationBuilder.RenameColumn(
                name: "Points",
                table: "Teams",
                newName: "Point");
        }
    }
}
