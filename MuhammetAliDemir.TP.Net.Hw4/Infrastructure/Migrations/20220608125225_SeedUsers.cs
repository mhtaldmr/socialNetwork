using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuhammetAliDemir.TP.Net.Hw4.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Users(FirstName, LastName, Email, PasswordHash, RegisteredAt, IsActive) Values('Charles', 'Leclerc', 'lec@gmail', 12212, '10.10.2010', 1)");
            migrationBuilder.Sql("insert into Users(FirstName, LastName, Email, PasswordHash, RegisteredAt, IsActive) Values('Max', 'Verstappen', 'ver@gmail', 23232, '2.4.2014', 1)");
            migrationBuilder.Sql("insert into Users(FirstName, LastName, Email, PasswordHash, RegisteredAt, IsActive) Values('Lewis', 'Hamilton', 'ham@gmail', 34312, '5.1.2013', 1)");
            migrationBuilder.Sql("insert into Users(FirstName, LastName, Email, PasswordHash, RegisteredAt, IsActive) Values('Fernando', 'Alonso', 'alo@gmail', 45452, '6.4.2012', 1)");
            migrationBuilder.Sql("insert into Users(FirstName, LastName, Email, PasswordHash, RegisteredAt, IsActive) Values('Sebastian', 'Vettel', 'vet@gmail', 93232, '7.10.2001', 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete Users where FirstName = 'Charles'");
            migrationBuilder.Sql("delete Users where FirstName = 'Max'");
            migrationBuilder.Sql("delete Users where FirstName = 'Lewis'");
            migrationBuilder.Sql("delete Users where FirstName = 'Fernando'");
            migrationBuilder.Sql("delete Users where FirstName = 'Sebastian'");
        }
    }
}
