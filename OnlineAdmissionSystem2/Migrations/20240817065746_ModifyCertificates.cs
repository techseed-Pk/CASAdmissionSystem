﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineAdmissionSystem2.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCertificates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Users_UserId",
                table: "Certificate");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Certificate",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Users_UserId",
                table: "Certificate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_Users_UserId",
                table: "Certificate");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Certificate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_Users_UserId",
                table: "Certificate",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
