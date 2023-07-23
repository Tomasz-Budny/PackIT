using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackIT.Infrastructure.EF.Migrations
{
    public partial class Init_Read : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "packing");

            migrationBuilder.CreateTable(
                name: "PackingList",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingItems",
                schema: "packing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    IsPacked = table.Column<bool>(type: "bit", nullable: false),
                    PackingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackingItems_PackingList_PackingListId",
                        column: x => x.PackingListId,
                        principalSchema: "packing",
                        principalTable: "PackingList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackingItems_PackingListId",
                schema: "packing",
                table: "PackingItems",
                column: "PackingListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackingItems",
                schema: "packing");

            migrationBuilder.DropTable(
                name: "PackingList",
                schema: "packing");
        }
    }
}
