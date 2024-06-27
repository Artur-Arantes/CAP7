using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Desafio.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id_permission = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    permission_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id_permission);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    person_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.Email);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    id_resource = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    resource_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    unity_measure = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id_record", x => x.id_resource);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    passwords = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    send_notification = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_person = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id_user);
                    table.ForeignKey(
                        name: "id_person",
                        column: x => x.id_person,
                        principalTable: "person",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "record_measurements",
                columns: table => new
                {
                    id_record = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    measure = table.Column<double>(type: "double", nullable: false),
                    date_time = table.Column<string>(type: "longtext", nullable: false),
                    id_resource = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_record);
                    table.ForeignKey(
                        name: "FK_record_measurements_resources_id_resource",
                        column: x => x.id_resource,
                        principalTable: "resources",
                        principalColumn: "id_resource",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "resource_index",
                columns: table => new
                {
                    id_resource = table.Column<long>(type: "bigint", nullable: false),
                    ind_minimum = table.Column<double>(type: "double", nullable: false),
                    ind_normal = table.Column<double>(type: "double", nullable: false),
                    ind_maximum = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id_resource);
                    table.ForeignKey(
                        name: "FK_resource_index_resources_id_resource",
                        column: x => x.id_resource,
                        principalTable: "resources",
                        principalColumn: "id_resource",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_permission",
                columns: table => new
                {
                    id_user = table.Column<long>(type: "bigint", nullable: false),
                    id_permission = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_permission", x => new { x.id_user, x.id_permission });
                    table.ForeignKey(
                        name: "FK_user_permission_permission_id_permission",
                        column: x => x.id_permission,
                        principalTable: "permission",
                        principalColumn: "id_permission",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_permission_users_id_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "alert_status",
                columns: table => new
                {
                    id_alert = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    alert_description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    date_time_alert = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    send_notification = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    alert_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    id_record = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alert_status", x => x.id_alert);
                    table.ForeignKey(
                        name: "FK_alert_status_record_measurements",
                        column: x => x.id_record,
                        principalTable: "record_measurements",
                        principalColumn: "id_record",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_alert_status_id_record",
                table: "alert_status",
                column: "id_record");

            migrationBuilder.CreateIndex(
                name: "IX_record_measurements_id_resource",
                table: "record_measurements",
                column: "id_resource");

            migrationBuilder.CreateIndex(
                name: "IX_user_permission_id_permission",
                table: "user_permission",
                column: "id_permission");

            migrationBuilder.CreateIndex(
                name: "IX_users_id_person",
                table: "users",
                column: "id_person",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alert_status");

            migrationBuilder.DropTable(
                name: "resource_index");

            migrationBuilder.DropTable(
                name: "user_permission");

            migrationBuilder.DropTable(
                name: "record_measurements");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
