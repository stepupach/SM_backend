using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init_auction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Exhibits_ExhibitId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ExhibitId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ExhibitId",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Exhibits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exhibits_ArtistId",
                table: "Exhibits",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exhibits_Artists_ArtistId",
                table: "Exhibits",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exhibits_Artists_ArtistId",
                table: "Exhibits");

            migrationBuilder.DropIndex(
                name: "IX_Exhibits_ArtistId",
                table: "Exhibits");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Exhibits");

            migrationBuilder.AddColumn<int>(
                name: "ExhibitId",
                table: "Artists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ExhibitId",
                table: "Artists",
                column: "ExhibitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Exhibits_ExhibitId",
                table: "Artists",
                column: "ExhibitId",
                principalTable: "Exhibits",
                principalColumn: "Id");
        }
    }
}
