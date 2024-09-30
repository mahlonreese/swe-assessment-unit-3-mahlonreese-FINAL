using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCoreAssess.Migrations
{
    /// <inheritdoc />
    public partial class createModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "humans",
                columns: table => new
                {
                    human_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fname = table.Column<string>(type: "varchar(25)", nullable: false),
                    lname = table.Column<string>(type: "varchar(25)", nullable: false),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    animal = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_humans", x => x.human_id);
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    animal_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: false),
                    animal_species = table.Column<string>(type: "varchar(25)", nullable: false),
                    birth_year = table.Column<int>(type: "integer", nullable: true),
                    human_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.animal_id);
                    table.ForeignKey(
                        name: "FK_animals_humans_human_id",
                        column: x => x.human_id,
                        principalTable: "humans",
                        principalColumn: "human_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animals_human_id",
                table: "animals",
                column: "human_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "humans");
        }
    }
}
