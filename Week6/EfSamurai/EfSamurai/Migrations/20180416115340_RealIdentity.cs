using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EfSamurai.Migrations
{
    public partial class RealIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealIdentityId",
                table: "Samurais",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RealIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealIdentity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Samurais_RealIdentityId",
                table: "Samurais",
                column: "RealIdentityId",
                unique: true,
                filter: "[RealIdentityId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_RealIdentity_RealIdentityId",
                table: "Samurais",
                column: "RealIdentityId",
                principalTable: "RealIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_RealIdentity_RealIdentityId",
                table: "Samurais");

            migrationBuilder.DropTable(
                name: "RealIdentity");

            migrationBuilder.DropIndex(
                name: "IX_Samurais_RealIdentityId",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "RealIdentityId",
                table: "Samurais");
        }
    }
}
