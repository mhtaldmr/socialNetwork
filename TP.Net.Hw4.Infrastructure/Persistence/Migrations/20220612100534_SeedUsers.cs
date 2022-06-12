using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw4.Infrastructure.Persistence.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users(FirstName,LastName,UserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,PasswordHash,RegisteredAt,IsActive,AccessFailedCount) VALUES ('Carles','Leclerc','cleclerc','cleclerc@xyz.com',1,1,1,0,'343434','05.05.2012',1,0)");
            migrationBuilder.Sql("INSERT INTO Users(FirstName,LastName,UserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,PasswordHash,RegisteredAt,IsActive,AccessFailedCount) VALUES ('Sebastian','Vettet','seb','sebvettel@xyz.com',1,1,1,0,'2454546','01.11.2011',1,0)");
            migrationBuilder.Sql("INSERT INTO Users(FirstName,LastName,UserName,Email,EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled,PasswordHash,RegisteredAt,IsActive,AccessFailedCount) VALUES ('Lewis','Hamilton','lhamilton','lhamilton@xyz.com',1,1,1,0,'565678','03.02.2018',1,0)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Email IN ('cleclerc@xyz.com', 'sebvettel@xyz.com', 'lhamilton@xyz.com')");
        }
    }
}
