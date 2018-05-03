using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Checkpoint05.Migrations
{
    public partial class Ravioli : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceshipId",
                table: "Ravioli",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli",
                column: "SpaceshipId",
                principalTable: "Spaceships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli");

            migrationBuilder.AlterColumn<int>(
                name: "SpaceshipId",
                table: "Ravioli",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ravioli_Spaceships_SpaceshipId",
                table: "Ravioli",
                column: "SpaceshipId",
                principalTable: "Spaceships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
