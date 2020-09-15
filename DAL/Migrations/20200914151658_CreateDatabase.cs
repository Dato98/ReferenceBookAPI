using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameGeo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NameEng = table.Column<string>(maxLength: 50, nullable: false),
                    SurnameGeo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SurnameEng = table.Column<string>(maxLength: 60, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", maxLength: 60, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Thumb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Information = table.Column<string>(maxLength: 100, nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInformation_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkedPeople",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LinkTypeId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkedPeople_LinkTypes_LinkTypeId",
                        column: x => x.LinkTypeId,
                        principalTable: "LinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkedPeople_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LinkTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "თანამშრომელი" },
                    { 2, "ნათესავი" },
                    { 3, "ნაცნობი" },
                    { 4, "სხვა" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_PersonId",
                table: "ContactInformation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedPeople_LinkTypeId",
                table: "LinkedPeople",
                column: "LinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedPeople_PersonId",
                table: "LinkedPeople",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "LinkedPeople");

            migrationBuilder.DropTable(
                name: "LinkTypes");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
