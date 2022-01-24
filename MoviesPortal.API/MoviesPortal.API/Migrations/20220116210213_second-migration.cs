using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesPortal.API.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRating_Users_UserId",
                table: "MovieRating");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "MovieRating",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRating_Users_UserId",
                table: "MovieRating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieRating_Users_UserId",
                table: "MovieRating");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "MovieRating",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieRating_Users_UserId",
                table: "MovieRating",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
