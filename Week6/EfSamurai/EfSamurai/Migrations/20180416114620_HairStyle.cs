using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Migrations
{
    public partial class HairStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HairStyleId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HairStyle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairStyle", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_HairStyleId",
                table: "Samurais",
                column: "HairStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_HairStyle_HairStyleId",
                table: "Samurais",
                column: "HairStyleId",
                principalTable: "HairStyle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_HairStyle_HairStyleId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "HairStyle");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_HairStyleId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "HairStyleId",
                table: "Samurais");
        }
    }
}
