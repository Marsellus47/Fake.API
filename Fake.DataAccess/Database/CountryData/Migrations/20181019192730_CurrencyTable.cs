using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fake.DataAccess.Database.CountryData.Migrations
{
    public partial class CurrencyTable : Migration
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
                    { 1, "ARS", "Peso" },
                    { 24, "LKR", "Rupee" },
                    { 25, "MDL", "Leu" },
                    { 26, "MKD", "Denar" },
                    { 27, "MXN", "Peso" },
                    { 28, "MYR", "Ringgit" },
                    { 29, "NOK", "Krone" },
                    { 30, "NZD", "Dollar" },
                    { 31, "PHP", "Peso" },
                    { 23, "JPY", "Yen" },
                    { 32, "PKR", "Rupee" },
                    { 34, "RON", "Leu" },
                    { 35, "RUB", "Ruble" },
                    { 36, "SEK", "Krona" },
                    { 37, "THB", "Baht" },
                    { 38, "TRY", "Lira" },
                    { 39, "UAH", "Hryvnia" },
                    { 40, "USD", "Dollar" },
                    { 41, "UYU", "Peso" },
                    { 33, "PLN", "Zloty" },
                    { 42, "XPF", "Franc" },
                    { 22, "ISK", "Krona" },
                    { 20, "CHF", "Franc" },
                    { 2, "AUD", "Dollar" },
                    { 3, "BDT", "Taka" },
                    { 4, "BGN", "Lev" },
                    { 5, "BMD", "Dollar" },
                    { 6, "BRL", "Real" },
                    { 7, "BYN", "Belarusian ruble" },
                    { 8, "CAD", "Dollar" },
                    { 9, "COP", "Peso" },
                    { 21, "INR", "Rupee" },
                    { 10, "CRC", "Colon" },
                    { 12, "DKK", "Krone" },
                    { 13, "DOP", "Peso" },
                    { 14, "DZD", "Dinar" },
                    { 15, "EUR", "Euro" },
                    { 16, "GBP", "Pound" },
                    { 17, "GTQ", "Quetzal" },
                    { 18, "HRK", "Kuna" },
                    { 19, "HUF", "Forint" },
                    { 11, "CZK", "Koruna" },
                    { 43, "ZAR", "Rand" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
