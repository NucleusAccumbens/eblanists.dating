using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class PhotoAlbumIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelegramUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4e9d94c-58d8-44d1-b5fd-f2e0f16a7f31"));

            migrationBuilder.InsertData(
                table: "TelegramUsers",
                columns: new[] { "Id", "AddedToAttachmentMenu", "ChatId", "Created", "CreatedBy", "DatingAppUserId", "IsAdmin", "LastModified", "LastModifiedBy", "Username" },
                values: new object[] { new Guid("0b509923-6b5f-4880-a46f-09dac8683773"), null, 444343256L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "noncredistka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelegramUsers",
                keyColumn: "Id",
                keyValue: new Guid("0b509923-6b5f-4880-a46f-09dac8683773"));

            migrationBuilder.InsertData(
                table: "TelegramUsers",
                columns: new[] { "Id", "AddedToAttachmentMenu", "ChatId", "Created", "CreatedBy", "DatingAppUserId", "IsAdmin", "LastModified", "LastModifiedBy", "Username" },
                values: new object[] { new Guid("d4e9d94c-58d8-44d1-b5fd-f2e0f16a7f31"), null, 444343256L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "noncredistka" });
        }
    }
}
