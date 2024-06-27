using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Desafio.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial_values : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "id_permission", "permission_name" },
                values: new object[] { 1L, "user" });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "Email", "person_name" },
                values: new object[] { "fiap@teste.com", "fiap" });

            migrationBuilder.InsertData(
                table: "resources",
                columns: new[] { "id_resource", "resource_name", "unity_measure" },
                values: new object[] { 1L, "agua", "qualquer_medida" });

            migrationBuilder.InsertData(
                table: "resource_index",
                columns: new[] { "id_resource", "ind_maximum", "ind_minimum", "ind_normal" },
                values: new object[] { 1L, 30.0, 50.0, 20.0 });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id_user", "Enabled", "Login", "passwords", "id_person", "send_notification" },
                values: new object[] { 9999L, true, "fiap", "3333", "fiap@teste.com", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id_permission",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "resource_index",
                keyColumn: "id_resource",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id_user",
                keyValue: 9999L);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "Email",
                keyValue: "fiap@teste.com");

            migrationBuilder.DeleteData(
                table: "resources",
                keyColumn: "id_resource",
                keyValue: 1L);
        }
    }
}
