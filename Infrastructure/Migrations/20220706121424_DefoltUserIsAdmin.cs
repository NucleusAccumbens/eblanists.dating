using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class DefoltUserIsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelegramUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e197ef4-aa5c-483c-ad0c-41328cc51482"));

            migrationBuilder.InsertData(
                table: "TelegramUsers",
                columns: new[] { "Id", "AddedToAttachmentMenu", "ChatId", "Created", "CreatedBy", "DatingAppUserId", "IsAdmin", "LastModified", "LastModifiedBy", "Username" },
                values: new object[] { new Guid("78ce1053-5ce4-4512-8074-2417be65d19e"), null, 444343256L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, null, null, "noncredistka" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelegramUsers",
                keyColumn: "Id",
                keyValue: new Guid("78ce1053-5ce4-4512-8074-2417be65d19e"));

            migrationBuilder.InsertData(
                table: "TelegramUsers",
                columns: new[] { "Id", "AddedToAttachmentMenu", "ChatId", "Created", "CreatedBy", "DatingAppUserId", "IsAdmin", "LastModified", "LastModifiedBy", "Username" },
                values: new object[] { new Guid("5e197ef4-aa5c-483c-ad0c-41328cc51482"), null, 444343256L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, false, null, null, "noncredistka" });
        }
    }
}
