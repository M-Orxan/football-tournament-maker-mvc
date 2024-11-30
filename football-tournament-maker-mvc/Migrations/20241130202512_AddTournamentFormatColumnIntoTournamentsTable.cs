using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace football_tournament_maker_mvc.Migrations
{
    public partial class AddTournamentFormatColumnIntoTournamentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TournamentFormat",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TournamentFormat",
                table: "Tournaments");
        }
    }
}
