using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw4.Infrastructure.Persistence.Migrations
{
    public partial class SeedMessageTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MessageTypes(MessageTypeId,MessageTypeName) VALUES (1,'Text')");
            migrationBuilder.Sql("INSERT INTO MessageTypes(MessageTypeId,MessageTypeName) VALUES (2,'Image')");
            migrationBuilder.Sql("INSERT INTO MessageTypes(MessageTypeId,MessageTypeName) VALUES (3,'Video')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM MessageTypes WHERE MessageTypeId IN (1,2,3)");
        }
    }
}
