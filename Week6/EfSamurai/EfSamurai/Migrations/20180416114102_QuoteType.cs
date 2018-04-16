using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Migrations
{
    public partial class QuoteType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuoteTypeId",
                table: "Quote",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuoteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quote_QuoteTypeId",
                table: "Quote",
                column: "QuoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quote_QuoteType_QuoteTypeId",
                table: "Quote",
                column: "QuoteTypeId",
                principalTable: "QuoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quote_QuoteType_QuoteTypeId",
                table: "Quote");

            migrationBuilder.DropTable(
                name: "QuoteType");

            migrationBuilder.DropIndex(
                name: "IX_Quote_QuoteTypeId",
                table: "Quote");

            migrationBuilder.DropColumn(
                name: "QuoteTypeId",
                table: "Quote");
        }
    }
}
