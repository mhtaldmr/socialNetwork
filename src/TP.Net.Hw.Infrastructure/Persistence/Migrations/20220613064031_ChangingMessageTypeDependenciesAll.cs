using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw.Infrastructure.Persistence.Migrations
{
    public partial class ChangingMessageTypeDependenciesAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserMessagesArchive_MessageTypeId",
                table: "UserMessagesArchive",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessagesArchive_MessageTypeId",
                table: "GroupMessagesArchive",
                column: "MessageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_MessageTypeId",
                table: "GroupMessages",
                column: "MessageTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_MessageTypes_MessageTypeId",
                table: "GroupMessages",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessagesArchive_MessageTypes_MessageTypeId",
                table: "GroupMessagesArchive",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessagesArchive_MessageTypes_MessageTypeId",
                table: "UserMessagesArchive",
                column: "MessageTypeId",
                principalTable: "MessageTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_MessageTypes_MessageTypeId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessagesArchive_MessageTypes_MessageTypeId",
                table: "GroupMessagesArchive");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessagesArchive_MessageTypes_MessageTypeId",
                table: "UserMessagesArchive");

            migrationBuilder.DropIndex(
                name: "IX_UserMessagesArchive_MessageTypeId",
                table: "UserMessagesArchive");

            migrationBuilder.DropIndex(
                name: "IX_GroupMessagesArchive_MessageTypeId",
                table: "GroupMessagesArchive");

            migrationBuilder.DropIndex(
                name: "IX_GroupMessages_MessageTypeId",
                table: "GroupMessages");
        }
    }
}
