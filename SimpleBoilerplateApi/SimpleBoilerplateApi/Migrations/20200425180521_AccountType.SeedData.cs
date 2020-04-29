using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleBoilerplateApi.Migrations
{
    public partial class AccountTypeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    AccountTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeCode = table.Column<string>(maxLength: 10, nullable: false),
                    AccountTypeDescription = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.AccountTypeId);
                });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "AccountTypeId", "AccountTypeCode", "AccountTypeDescription" },
                values: new object[] { 1L, "CA", "Current Account" });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "AccountTypeId", "AccountTypeCode", "AccountTypeDescription" },
                values: new object[] { 2L, "SA", "Saving Account" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountType");
        }
    }
}
