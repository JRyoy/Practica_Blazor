using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorApp.Persistencia.Migraciones
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formulario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulario", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Formulario",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 11, "Hola", "Messi@Gmail.com" },
                    { 12, "Holaxd", "Messixd@Gmail.com" },
                    { 13, "Holaxdxd", "Messi2xdxd@Gmail.com" },
                    { 14, "Holaxdxdxd", "Messi2xdxdxd@Gmail.com" },
                    { 15, "Holaxdxdxdxd", "Messi2xdxdxdxd@Gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formulario");
        }
    }
}
