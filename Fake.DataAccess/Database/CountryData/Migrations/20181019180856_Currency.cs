using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fake.DataAccess.Database.CountryData.Migrations
{
    public partial class Currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "MKD", "Denar" },
                    { 24, "ISK", "Krona" },
                    { 25, "THB", "Baht" },
                    { 26, "ZAR", "Rand" },
                    { 27, "MXN", "Peso" },
                    { 28, "PLN", "Zloty" },
                    { 29, "COP", "Peso" },
                    { 30, "CRC", "Colon" },
                    { 31, "BMD", "Dollar" },
                    { 23, "UYU", "Peso" },
                    { 32, "DOP", "Peso" },
                    { 34, "BYN", "Belarusian ruble" },
                    { 35, "TRY", "Lira" },
                    { 36, "AUD", "Dollar" },
                    { 37, "ARS", "Peso" },
                    { 38, "JPY", "Yen" },
                    { 39, "CHF", "Franc" },
                    { 40, "HRK", "Kuna" },
                    { 41, "PKR", "Rupee" },
                    { 33, "NOK", "Krone" },
                    { 42, "UAH", "Hryvnia" },
                    { 22, "RON", "Leu" },
                    { 20, "DZD", "Dinar" },
                    { 2, "SEK", "Krona" },
                    { 3, "EUR", "Euro" },
                    { 4, "USD", "Dollar" },
                    { 5, "PHP", "Peso" },
                    { 6, "NZD", "Dollar" },
                    { 7, "GBP", "Pound" },
                    { 8, "XPF", "Franc" },
                    { 9, "BRL", "Real" },
                    { 21, "MYR", "Ringgit" },
                    { 10, "CAD", "Dollar" },
                    { 12, "RUB", "Ruble" },
                    { 13, "MDL", "Leu" },
                    { 14, "GTQ", "Quetzal" },
                    { 15, "DKK", "Krone" },
                    { 16, "BGN", "Lev" },
                    { 17, "LKR", "Rupee" },
                    { 18, "BDT", "Taka" },
                    { 19, "CZK", "Koruna" },
                    { 11, "HUF", "Forint" },
                    { 43, "INR", "Rupee" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
