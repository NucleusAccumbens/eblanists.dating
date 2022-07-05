using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatingAppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: true),
                    IsNoncredist = table.Column<bool>(type: "bit", nullable: true),
                    IsChildfree = table.Column<bool>(type: "bit", nullable: true),
                    IsPansexual = table.Column<bool>(type: "bit", nullable: true),
                    IsCosmopolitan = table.Column<bool>(type: "bit", nullable: true),
                    IsBdsmLover = table.Column<bool>(type: "bit", nullable: true),
                    IsMakeupUser = table.Column<bool>(type: "bit", nullable: true),
                    IsHeelsUser = table.Column<bool>(type: "bit", nullable: true),
                    IsTattooed = table.Column<bool>(type: "bit", nullable: true),
                    IsExistLover = table.Column<bool>(type: "bit", nullable: true),
                    ShaveLegs = table.Column<bool>(type: "bit", nullable: true),
                    ShaveHead = table.Column<bool>(type: "bit", nullable: true),
                    HaveSacred = table.Column<bool>(type: "bit", nullable: true),
                    OtherInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatingAppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    AddedToAttachmentMenu = table.Column<bool>(type: "bit", nullable: true),
                    DatingAppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatingAppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoAlbums_DatingAppUsers_DatingAppUserId",
                        column: x => x.DatingAppUserId,
                        principalTable: "DatingAppUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BodyPart = table.Column<int>(type: "int", nullable: false),
                    PathToPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoAlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_PhotoAlbums_PhotoAlbumId",
                        column: x => x.PhotoAlbumId,
                        principalTable: "PhotoAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TelegramUsers",
                columns: new[] { "Id", "AddedToAttachmentMenu", "ChatId", "Created", "CreatedBy", "DatingAppUserId", "IsAdmin", "LastModified", "LastModifiedBy", "Username" },
                values: new object[] { new Guid("d4e9d94c-58d8-44d1-b5fd-f2e0f16a7f31"), null, 444343256L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "noncredistka" });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbums_DatingAppUserId",
                table: "PhotoAlbums",
                column: "DatingAppUserId",
                unique: true,
                filter: "[DatingAppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoAlbumId",
                table: "Photos",
                column: "PhotoAlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "TelegramUsers");

            migrationBuilder.DropTable(
                name: "PhotoAlbums");

            migrationBuilder.DropTable(
                name: "DatingAppUsers");
        }
    }
}
