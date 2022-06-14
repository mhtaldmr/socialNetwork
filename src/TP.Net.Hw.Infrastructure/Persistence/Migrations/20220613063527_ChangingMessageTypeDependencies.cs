using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw.Infrastructure.Persistence.Migrations
{
    public partial class ChangingMessageTypeDependencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageTypes_GroupMessages_MessageTypeId",
                table: "MessageTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTypes_GroupMessagesArchive_MessageTypeId",
                table: "MessageTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTypes_UserMessages_MessageTypeId",
                table: "MessageTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageTypes_UserMessagesArchive_MessageTypeId",
                table: "MessageTypes");

            migrationBuilder.DropIndex(
                name: "IX_MessageTypes_MessageTypeId",
                table: "MessageTypes");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessages_MessageTypeId",
                table: "UserMessages",
                column: "MessageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessages_MessageTypes_MessageTypeId",
                table: "UserMessages",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessages_MessageTypes_MessageTypeId",
                table: "UserMessages");

            migrationBuilder.DropIndex(
                name: "IX_UserMessages_MessageTypeId",
                table: "UserMessages");

            migrationBuilder.CreateIndex(
                name: "IX_MessageTypes_MessageTypeId",
                table: "MessageTypes",
                column: "MessageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTypes_GroupMessages_MessageTypeId",
                table: "MessageTypes",
                column: "MessageTypeId",
                principalTable: "GroupMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTypes_GroupMessagesArchive_MessageTypeId",
                table: "MessageTypes",
                column: "MessageTypeId",
                principalTable: "GroupMessagesArchive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTypes_UserMessages_MessageTypeId",
                table: "MessageTypes",
                column: "MessageTypeId",
                principalTable: "UserMessages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageTypes_UserMessagesArchive_MessageTypeId",
                table: "MessageTypes",
                column: "MessageTypeId",
                principalTable: "UserMessagesArchive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
