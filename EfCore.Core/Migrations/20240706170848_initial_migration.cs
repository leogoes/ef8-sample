using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCore.Core.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dreams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Theme = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CanPunch = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dreams", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Peoples",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DreamId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Peoples_Dreams_DreamId",
                        column: x => x.DreamId,
                        principalTable: "Dreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sleeps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PersonId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SleptAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    WokeupAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Noise_HasNoiseAtKitchen = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleeps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sleeps_Peoples_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sheep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SleepId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SheepName = table.Column<uint>(type: "int unsigned", nullable: false),
                    SheepNumber = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sheep_Sleeps_SleepId",
                        column: x => x.SleepId,
                        principalTable: "Sleeps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_DreamId",
                table: "Peoples",
                column: "DreamId");

            migrationBuilder.CreateIndex(
                name: "IX_Sheep_SleepId",
                table: "Sheep",
                column: "SleepId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleeps_PersonId",
                table: "Sleeps",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sheep");

            migrationBuilder.DropTable(
                name: "Sleeps");

            migrationBuilder.DropTable(
                name: "Peoples");

            migrationBuilder.DropTable(
                name: "Dreams");
        }
    }
}
