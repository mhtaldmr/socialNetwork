using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw4.Infrastructure.Persistence.Migrations
{
    public partial class SeedCommentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CommentTypes(CommentTypeId,CommentTypeName) VALUES (1,'Text')");
            migrationBuilder.Sql("INSERT INTO CommentTypes(CommentTypeId,CommentTypeName) VALUES (2,'Image')");
            migrationBuilder.Sql("INSERT INTO CommentTypes(CommentTypeId,CommentTypeName) VALUES (3,'Video')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM CommentTypes WHERE CommentTypeId IN (1,2,3)");
        }
    }
}
