using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "movie",
                columns: table => new
                {
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    movie_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    movie_genre = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    movie_duration = table.Column<int>(type: "int", nullable: false),
                    movie_budget = table.Column<float>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idMovie);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    idActor = table.Column<int>(type: "int", nullable: false),
                    actor_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    actor_birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    actor_picture = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idActor);
                    table.ForeignKey(
                        name: "Movie_Actor",
                        column: x => x.idActor,
                        principalTable: "movie",
                        principalColumn: "idMovie");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "movie");
        }
    }
}
