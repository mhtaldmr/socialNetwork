using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw.Infrastructure.Persistence.Migrations
{
    public partial class ChangingTypeDependenciesAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentTypes_UserPostsComments_CommentTypeId",
                table: "CommentTypes");

            migrationBuilder.DropIndex(
                name: "IX_CommentTypes_CommentTypeId",
                table: "CommentTypes");

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "UserPosts");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "UserPostsComments",
                newName: "CommentBody");

            migrationBuilder.RenameColumn(
                name: "Post",
                table: "UserPosts",
                newName: "PostTitle");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserPostsComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserPostsComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "UserPostsComments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostBody",
                table: "UserPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserMessagesArchive",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "UserMessagesArchive",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GroupMessagesArchive",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "GroupMessagesArchive",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserPostsComments_CommentTypeId",
                table: "UserPostsComments",
                column: "CommentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPostsComments_CommentTypes_CommentTypeId",
                table: "UserPostsComments",
                column: "CommentTypeId",
                principalTable: "CommentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPostsComments_CommentTypes_CommentTypeId",
                table: "UserPostsComments");

            migrationBuilder.DropIndex(
                name: "IX_UserPostsComments_CommentTypeId",
                table: "UserPostsComments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserPostsComments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserPostsComments");

            migrationBuilder.DropColumn(
                name: "PostBody",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "UserMessagesArchive");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "GroupMessagesArchive");

            migrationBuilder.RenameColumn(
                name: "CommentBody",
                table: "UserPostsComments",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "PostTitle",
                table: "UserPosts",
                newName: "Post");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserPostsComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PostType",
                table: "UserPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserMessagesArchive",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GroupMessagesArchive",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTypes_CommentTypeId",
                table: "CommentTypes",
                column: "CommentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentTypes_UserPostsComments_CommentTypeId",
                table: "CommentTypes",
                column: "CommentTypeId",
                principalTable: "UserPostsComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
