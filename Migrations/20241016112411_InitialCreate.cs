using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Case",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CooperatorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Case", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolunteerCase",
                columns: table => new
                {
                    volunteerId = table.Column<long>(type: "bigint", nullable: false),
                    caseId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteerCase", x => new { x.volunteerId, x.caseId });
                });

            migrationBuilder.InsertData(
                table: "Case",
                columns: new[] { "Id", "Address", "CooperatorId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "789 Birch St, Gotham", 1L, "Investigation about environmental impact", "Case Alpha" },
                    { 2L, "159 Cedar St, Star City", 2L, "A study on urban development", "Case Beta" },
                    { 3L, "202 Elm St, Metropolis", 3L, "Research on traffic patterns", "Case Gamma" },
                    { 4L, "345 Oak St, Springfield", 4L, "Energy consumption analysis", "Case Delta" },
                    { 5L, "987 Maple St, Central City", 5L, "Water quality monitoring", "Case Epsilon" }
                });

            migrationBuilder.InsertData(
                table: "Report",
                columns: new[] { "Id", "Address", "Description", "Email" },
                values: new object[,]
                {
                    { 1L, "789 Birch St, Gotham", "Initial findings on air quality.", "reporter1@example.com" },
                    { 2L, "159 Cedar St, Star City", "Preliminary analysis of traffic data.", "reporter2@example.com" },
                    { 3L, "202 Elm St, Metropolis", "Research summary on congestion.", "reporter3@example.com" },
                    { 4L, "345 Oak St, Springfield", "Energy report for industrial area.", "reporter4@example.com" },
                    { 5L, "987 Maple St, Central City", "Analysis of water contaminants.", "reporter5@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "Email", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1L, "123 Elm St, Springfield", "john.doe@example.com", "John Doe", "password123", "123-456-7890", 0 },
                    { 2L, "456 Oak St, Metropolis", "jane.smith@example.com", "Jane Smith", "password456", "987-654-3210", 1 },
                    { 3L, "789 Pine St, Gotham", "alice.johnson@example.com", "Alice Johnson", "alicepwd789", "456-789-1234", 1 },
                    { 4L, "101 Maple St, Star City", "bob.williams@example.com", "Bob Williams", "bobpwd101", "789-123-4567", 2 },
                    { 5L, "202 Cedar St, Central City", "eve.davis@example.com", "Eve Davis", "evepwd202", "123-321-4567", 0 }
                });

            migrationBuilder.InsertData(
                table: "VolunteerCase",
                columns: new[] { "caseId", "volunteerId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L },
                    { 3L, 2L },
                    { 4L, 3L },
                    { 5L, 4L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Case");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VolunteerCase");
        }
    }
}
