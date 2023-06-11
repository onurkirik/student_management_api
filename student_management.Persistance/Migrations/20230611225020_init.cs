using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace student_management.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicalAdress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostalAdress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Adress_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adress",
                columns: new[] { "Id", "PhysicalAdress", "PostalAdress" },
                values: new object[] { new Guid("b8bf0b78-0202-4883-ab4d-6d57832a1046"), "Altındağ/Ankara", "Türkiye" });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("41607d57-e74e-40c4-afbf-bed0476c3ba8"), "Erkek" },
                    { new Guid("e4a62a5f-1222-4f9d-9404-c6e691d7a4bf"), "Kadın" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AdressId", "BirthDate", "Email", "FirstName", "GenderId", "LastName", "Phone", "ProfileImageUrl" },
                values: new object[] { new Guid("9650103c-8f99-4a39-83da-70459bff90ba"), new Guid("b8bf0b78-0202-4883-ab4d-6d57832a1046"), new DateTime(2023, 6, 12, 1, 50, 20, 384, DateTimeKind.Local).AddTicks(3796), "kirikonurr@gmail.com", "Onur", new Guid("41607d57-e74e-40c4-afbf-bed0476c3ba8"), "KIRIK", "5423815262", "fjdksajf" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_AdressId",
                table: "Student",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GenderId",
                table: "Student",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
