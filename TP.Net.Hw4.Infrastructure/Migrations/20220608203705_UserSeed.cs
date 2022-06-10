using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Net.Hw4.Migrations
{
    public partial class UserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Users(UserName,IsActive,UserSurName,RegisteredAt, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES ('ahmet1',1,'yılmaz','10.10.2010', 'ahmet1', 'ahmetyilmaz1@xyz.com', 'ahmetyilmaz1@xyz.com', 1, '123456', '0', '1', '053500000001', 1, 0, '01.01.2022', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Users(UserName,IsActive,UserSurName,RegisteredAt, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES ('ahmet2',1,'yılmaz','10.10.2010', 'ahmet2', 'ahmetyilmaz2@xyz.com', 'ahmetyilmaz2@xyz.com', 1, '123456', '0', '1', '053500000002', 1, 0, '01.01.2022', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Users(UserName,IsActive,UserSurName,RegisteredAt, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES ('ahmet3',1,'yılmaz','10.10.2010', 'ahmet3', 'ahmetyilmaz3@xyz.com', 'ahmetyilmaz3@xyz.com', 1, '123456', '0', '1', '053500000003', 1, 0, '01.01.2022', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Users(UserName,IsActive,UserSurName,RegisteredAt, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES ('ahmet4',1,'yılmaz','10.10.2010', 'ahmet4', 'ahmetyilmaz4@xyz.com', 'ahmetyilmaz4@xyz.com', 1, '123456', '0', '1', '053500000004', 1, 0, '01.01.2022', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Users(UserName,IsActive,UserSurName,RegisteredAt, NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount) VALUES ('ahmet5',1,'yılmaz','10.10.2010', 'ahmet5', 'ahmetyilmaz5@xyz.com', 'ahmetyilmaz5@xyz.com', 1, '123456', '0', '1', '053500000005', 1, 0, '01.01.2022', 0, 1)");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete Users where UserName = 'Charles'");
            migrationBuilder.Sql("delete Users where UserName = 'Max'");
            migrationBuilder.Sql("delete Users where UserName = 'Lewis'");
            migrationBuilder.Sql("delete Users where UserName = 'Fernando'");
            migrationBuilder.Sql("delete Users where UserName = 'Sebastian'");
        }


    }
}
