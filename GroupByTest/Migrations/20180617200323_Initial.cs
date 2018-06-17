using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupByTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowShows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ShowId = table.Column<int>(nullable: false),
                    Followed = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowShows_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Friends" });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Game of Thrones" });

            migrationBuilder.InsertData(
                table: "FollowShows",
                columns: new[] { "Id", "Followed", "ShowId" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 6, 17, 22, 3, 23, 526, DateTimeKind.Local), 1 },
                    { 2, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 1 },
                    { 3, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 1 },
                    { 4, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 1 },
                    { 5, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 1 },
                    { 6, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 2 },
                    { 7, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 2 },
                    { 8, new DateTime(2018, 6, 17, 22, 3, 23, 527, DateTimeKind.Local), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowShows_ShowId",
                table: "FollowShows",
                column: "ShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowShows");

            migrationBuilder.DropTable(
                name: "Shows");
        }
    }
}
