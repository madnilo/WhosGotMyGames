using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhosGotMyGames.Data.Migrations
{
    public partial class remapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Lending",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Lending",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "FriendID",
                table: "Lending",
                newName: "FriendId");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Game",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Game",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "OwnerID",
                table: "Friend",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Friend",
                newName: "FriendId");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Lending",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Lending",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FriendId",
                table: "Lending",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Game",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Friend",
                nullable: true,
                oldClrType: typeof(int));

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
                name: "IX_Lending_FriendId",
                table: "Lending",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Lending_GameId",
                table: "Lending",
                column: "GameId");

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
                name: "FK_Lending_Friend_FriendId",
                table: "Lending",
                column: "FriendId",
                principalTable: "Friend",
                principalColumn: "FriendId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Game_GameId",
                table: "Lending",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lending_Owner_OwnerId",
                table: "Lending",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "OwnerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Owner_OwnerId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Owner_OwnerId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Friend_FriendId",
                table: "Lending");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Game_GameId",
                table: "Lending");

            migrationBuilder.DropForeignKey(
                name: "FK_Lending_Owner_OwnerId",
                table: "Lending");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropIndex(
                name: "IX_Lending_FriendId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_GameId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Lending_OwnerId",
                table: "Lending");

            migrationBuilder.DropIndex(
                name: "IX_Game_OwnerId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Friend_OwnerId",
                table: "Friend");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Lending",
                newName: "OwnerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Lending",
                newName: "GameID");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "Lending",
                newName: "FriendID");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Game",
                newName: "OwnerID");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Friend",
                newName: "OwnerID");

            migrationBuilder.RenameColumn(
                name: "FriendId",
                table: "Friend",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Lending",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameID",
                table: "Lending",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FriendID",
                table: "Lending",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Game",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerID",
                table: "Friend",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
