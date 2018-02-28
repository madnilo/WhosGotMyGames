using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhosGotMyGames.Data.Migrations
{
    public partial class remapping4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Owner_OwnerId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Owner_OwnerId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Owner_OwnerId",
                table: "Lending");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Lending_OwnerId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Game_OwnerId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Friend_OwnerId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Friend");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Lending",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Friend",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lending_ApplicationUserId",
                table: "Lending",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ApplicationUserId",
                table: "Game",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_ApplicationUserId",
                table: "Friend",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_AspNetUsers_ApplicationUserId",
                table: "Friend",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_ApplicationUserId",
                table: "Game",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_AspNetUsers_ApplicationUserId",
                table: "Lending",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_AspNetUsers_ApplicationUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_ApplicationUserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_AspNetUsers_ApplicationUserId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_ApplicationUserId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Game_ApplicationUserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Friend_ApplicationUserId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Lending");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Lending",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Friend",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owner_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lending_OwnerId",
                table: "Lending",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_OwnerId",
                table: "Game",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_OwnerId",
                table: "Friend",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_UserId",
                table: "Owner",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Owner_OwnerId",
                table: "Friend",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Owner_OwnerId",
                table: "Game",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Owner_OwnerId",
                table: "Lending",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
