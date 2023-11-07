using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguroVeiculo.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class v03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FimVigencia",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "InicioVigencia",
                table: "Seguro");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Veiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da criação.");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Veiculo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da última atualização.");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Seguro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da criação.");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Seguro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da última atualização.");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Segurado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da criação.");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Segurado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data/Hora da última atualização.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Segurado");

            migrationBuilder.AddColumn<DateTime>(
                name: "FimVigencia",
                table: "Seguro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "InicioVigencia",
                table: "Seguro",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
