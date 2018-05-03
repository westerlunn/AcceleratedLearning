using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Checkpoint05.Migrations
{
    public partial class Ravioli2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ravioli",
                table: "Ravioli");

            migrationBuilder.RenameTable(
                name: "Ravioli",
                newName: "Raviolis");

            migrationBuilder.RenameIndex(
                name: "IX_Ravioli_SpaceshipId",
                table: "Raviolis",
                newName: "IX_Raviolis_SpaceshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Raviolis",
                table: "Raviolis",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Raviolis_Spaceships_SpaceshipId",
                table: "Raviolis",
                column: "SpaceshipId",
                principalTable: "Spaceships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Raviolis_Spaceships_SpaceshipId",
                table: "Raviolis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Raviolis",
                table: "Raviolis");

            migrationBuilder.RenameTable(
                name: "Raviolis",
                newName: "Ravioli");

            migrationBuilder.RenameIndex(
                name: "IX_Raviolis_SpaceshipId",
                table: "Ravioli",
                newName: "IX_Ravioli_SpaceshipId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ravioli",
                table: "Ravioli",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli",
                column: "SpaceshipId",
                principalTable: "Spaceships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
