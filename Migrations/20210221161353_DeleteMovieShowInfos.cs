using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBookingSystem.Migrations
{
    public partial class DeleteMovieShowInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieShowInfos_MovieShowInfoId",
                table: "Seats");

            migrationBuilder.DropTable(
                name: "MovieShowInfos");

            migrationBuilder.RenameColumn(
                name: "MovieShowInfoId",
                table: "Seats",
                newName: "MovieShowId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_MovieShowInfoId",
                table: "Seats",
                newName: "IX_Seats_MovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_MovieShows_MovieShowId",
                table: "Seats",
                column: "MovieShowId",
                principalTable: "MovieShows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_MovieShows_MovieShowId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "MovieShowId",
                table: "Seats",
                newName: "MovieShowInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_MovieShowId",
                table: "Seats",
                newName: "IX_Seats_MovieShowInfoId");

            migrationBuilder.CreateTable(
                name: "MovieShowInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieShowId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShowInfos_MovieShows_MovieShowId",
                        column: x => x.MovieShowId,
                        principalTable: "MovieShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowInfos_MovieShowId",
                table: "MovieShowInfos",
                column: "MovieShowId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_MovieShowInfos_MovieShowInfoId",
                table: "Seats",
                column: "MovieShowInfoId",
                principalTable: "MovieShowInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
