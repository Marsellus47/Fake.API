using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fake.DataAccess.Database.CountryData.Migrations
{
    public partial class CountryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostCodeRegex = table.Column<string>(nullable: true),
                    PostCodeFormat = table.Column<string>(nullable: true),
                    PhonePrefix = table.Column<string>(nullable: true),
                    TopLevelDomain = table.Column<string>(nullable: true),
                    Continent = table.Column<string>(nullable: true),
                    Area = table.Column<double>(nullable: false),
                    Capital = table.Column<string>(nullable: true),
                    Fips = table.Column<string>(nullable: true),
                    IsoNumeric = table.Column<int>(nullable: false),
                    Iso3 = table.Column<string>(nullable: true),
                    Iso = table.Column<string>(nullable: true),
                    Population = table.Column<long>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Area", "Capital", "Continent", "CurrencyId", "Fips", "Iso", "Iso3", "IsoNumeric", "Name", "PhonePrefix", "Population", "PostCodeFormat", "PostCodeRegex", "TopLevelDomain" },
                values: new object[,]
                {
                    { 1, 1580.0, "Mariehamn", "EU", 15, null, "AX", "ALA", 248, "Aland Islands", "+358-18", 0L, "#####", "^(?:FI)*(\\d{5})$", null },
                    { 61, 312685.0, "Warsaw", "EU", 33, "PL", "PL", "POL", 616, "Poland", "48", 0L, "##-###", "^\\d{2}-\\d{3}$", null },
                    { 60, 300000.0, "Manila", "AS", 31, "RP", "PH", "PHL", 608, "Philippines", "63", 0L, "####", "^(\\d{4})$", null },
                    { 59, 458.0, "Melekeok", "OC", 40, "PS", "PW", "PLW", 585, "Palau", "680", 0L, "96940", "^(96940)$", null },
                    { 58, 803940.0, "Islamabad", "AS", 32, "PK", "PK", "PAK", 586, "Pakistan", "92", 0L, "#####", "^(\\d{5})$", null },
                    { 57, 324220.0, "Oslo", "EU", 29, "NO", "NO", "NOR", 578, "Norway", "47", 0L, "####", "^(\\d{4})$", null },
                    { 56, 477.0, "Saipan", "OC", 40, "CQ", "MP", "MNP", 580, "Northern Mariana Islands", "+1-670", 0L, "#####", "^9695\\d{1}$", null },
                    { 55, 268680.0, "Wellington", "OC", 30, "NZ", "NZ", "NZL", 554, "New Zealand", "64", 0L, "####", "^(\\d{4})$", null },
                    { 54, 19060.0, "Noumea", "OC", 42, "NC", "NC", "NCL", 540, "New Caledonia", "687", 0L, "#####", "^(\\d{5})$", null },
                    { 53, 41526.0, "Amsterdam", "EU", 15, "NL", "NL", "NLD", 528, "Netherlands", "31", 0L, "#### @@", "^(\\d{4}[A-Z]{2})$", null },
                    { 52, 1.95, "Monaco", "EU", 15, "MN", "MC", "MCO", 492, "Monaco", "377", 0L, "#####", "^(\\d{5})$", null },
                    { 51, 33843.0, "Chisinau", "EU", 25, "MD", "MD", "MDA", 498, "Moldova", "373", 0L, "MD-####", "^MD-\\d{4}$", null },
                    { 50, 702.0, "Palikir", "OC", 40, "FM", "FM", "FSM", 583, "Micronesia", "691", 0L, "#####", "^(\\d{5})$", null },
                    { 49, 1972550.0, "Mexico City", "NA", 27, "MX", "MX", "MEX", 484, "Mexico", "52", 0L, "#####", "^(\\d{5})$", null },
                    { 48, 374.0, "Mamoudzou", "AF", 15, "MF", "YT", "MYT", 175, "Mayotte", "262", 0L, "#####", "^(\\d{5})$", null },
                    { 47, 1100.0, "Fort-de-France", "NA", 15, "MB", "MQ", "MTQ", 474, "Martinique", "596", 0L, "#####", "^(\\d{5})$", null },
                    { 46, 181.3, "Majuro", "OC", 40, "RM", "MH", "MHL", 584, "Marshall Islands", "692", 0L, "#####-####", "^969\\d{2}(-\\d{4})$", null },
                    { 45, 316.0, "Valletta", "EU", 15, "MT", "MT", "MLT", 470, "Malta", "356", 0L, "@@@ ####", "^[A-Z]{3}\\s?\\d{4}$", null },
                    { 62, 92391.0, "Lisbon", "EU", 15, "PO", "PT", "PRT", 620, "Portugal", "351", 0L, "####-###", "^\\d{4}-\\d{3}\\s?[a-zA-Z]{0,25}$", null },
                    { 63, 9104.0, "San Juan", "NA", 40, "RQ", "PR", "PRI", 630, "Puerto Rico", "+1-787 and 1-939", 0L, "#####-####", "^00[679]\\d{2}(?:-\\d{4})?$", null },
                    { 64, 2517.0, "Saint-Denis", "AF", 15, "RE", "RE", "REU", 638, "Reunion", "262", 0L, "#####", "^((97|98)(4|7|8)\\d{2})$", null },
                    { 65, 237500.0, "Bucharest", "EU", 34, "RO", "RO", "ROU", 642, "Romania", "40", 0L, "######", "^(\\d{6})$", null },
                    { 83, 176220.0, "Montevideo", "SA", 41, "UY", "UY", "URY", 858, "Uruguay", "598", 0L, "#####", "^(\\d{5})$", null },
                    { 82, 9629091.0, "Washington", "NA", 40, "US", "US", "USA", 840, "United States", "1", 0L, "#####-####", "^\\d{5}(-\\d{4})?$", null },
                    { 81, 244820.0, "London", "EU", 16, "UK", "GB", "GBR", 826, "United Kingdom", "44", 0L, "@# #@@|@## #@@|@@# #@@|@@## #@@|@#@ #@@|@@#@ #@@|GIR0AA", "^([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z])))) [0-9][A-Za-z]{2})$", null },
                    { 80, 603700.0, "Kyiv", "EU", 39, "UP", "UA", "UKR", 804, "Ukraine", "380", 0L, "#####", "^(\\d{5})$", null },
                    { 79, 352.0, "Charlotte Amalie", "NA", 40, "VQ", "VI", "VIR", 850, "U.S. Virgin Islands", "+1-340", 0L, "#####-####", "^008\\d{2}(?:-\\d{4})?$", null },
                    { 78, 780580.0, "Ankara", "AS", 38, "TU", "TR", "TUR", 792, "Turkey", "90", 0L, "#####", "^(\\d{5})$", null },
                    { 77, 514000.0, "Bangkok", "AS", 37, "TH", "TH", "THA", 764, "Thailand", "66", 0L, "#####", "^(\\d{5})$", null },
                    { 76, 41290.0, "Bern", "EU", 20, "SZ", "CH", "CHE", 756, "Switzerland", "41", 0L, "####", "^(\\d{4})$", null },
                    { 44, 329750.0, "Kuala Lumpur", "AS", 28, "MY", "MY", "MYS", 458, "Malaysia", "60", 0L, "#####", "^(\\d{5})$", null },
                    { 75, 449964.0, "Stockholm", "EU", 36, "SW", "SE", "SWE", 752, "Sweden", "46", 0L, "### ##", "^(?:SE)?\\d{3}\\s\\d{2}$", null },
                    { 73, 65610.0, "Colombo", "AS", 24, "CE", "LK", "LKA", 144, "Sri Lanka", "94", 0L, "#####", "^(\\d{5})$", null },
                    { 72, 504782.0, "Madrid", "EU", 15, "SP", "ES", "ESP", 724, "Spain", "34", 0L, "#####", "^(\\d{5})$", null },
                    { 71, 1219912.0, "Pretoria", "AF", 43, "SF", "ZA", "ZAF", 710, "South Africa", "27", 0L, "####", "^(\\d{4})$", null },
                    { 70, 20273.0, "Ljubljana", "EU", 15, "SI", "SI", "SVN", 705, "Slovenia", "386", 0L, "####", "^(?:SI)*(\\d{4})$", null },
                    { 69, 48845.0, "Bratislava", "EU", 15, "LO", "SK", "SVK", 703, "Slovakia", "421", 0L, "### ##", "^\\d{3}\\s?\\d{2}$", null },
                    { 68, 61.2, "San Marino", "EU", 15, "SM", "SM", "SMR", 674, "San Marino", "378", 0L, "4789#", "^(4789\\d)$", null },
                    { 67, 242.0, "Saint-Pierre", "NA", 15, "SB", "PM", "SPM", 666, "Saint Pierre and Miquelon", "508", 0L, "#####", "^(97500)$", null },
                    { 66, 17100000.0, "Moscow", "EU", 35, "RS", "RU", "RUS", 643, "Russia", "7", 0L, "######", "^(\\d{6})$", null },
                    { 74, 62049.0, "Longyearbyen", "EU", 29, "SV", "SJ", "SJM", 744, "Svalbard and Jan Mayen", "47", 0L, "####", "^(\\d{4})$", null },
                    { 84, 0.44, "Vatican City", "EU", 15, "VT", "VA", "VAT", 336, "Vatican", "379", 0L, "#####", "^(\\d{5})$", null },
                    { 43, 25333.0, "Skopje", "EU", 26, "MK", "MK", "MKD", 807, "Macedonia", "389", 0L, "####", "^(\\d{4})$", null },
                    { 41, 65200.0, "Vilnius", "EU", 15, "LH", "LT", "LTU", 440, "Lithuania", "370", 0L, "LT-#####", "^(?:LT)*(\\d{5})$", null },
                    { 18, 78866.0, "Prague", "EU", 11, "EZ", "CZ", "CZE", 203, "Czechia", "420", 0L, "### ##", "^\\d{3}\\s?\\d{2}$", null },
                    { 17, 56542.0, "Zagreb", "EU", 18, "HR", "HR", "HRV", 191, "Croatia", "385", 0L, "#####", "^(?:HR)*(\\d{5})$", null },
                    { 16, 51100.0, "San Jose", "NA", 10, "CS", "CR", "CRI", 188, "Costa Rica", "506", 0L, "#####", "^(\\d{5})$", null },
                    { 15, 1138910.0, "Bogota", "SA", 9, "CO", "CO", "COL", 170, "Colombia", "57", 0L, "######", "^(\\d{6})$", null },
                    { 14, 9984670.0, "Ottawa", "NA", 8, "CA", "CA", "CAN", 124, "Canada", "1", 0L, "@#@ #@#", "^([ABCEGHJKLMNPRSTVXY]\\d[ABCEGHJKLMNPRSTVWXYZ]) ?(\\d[ABCEGHJKLMNPRSTVWXYZ]\\d)$", null },
                    { 13, 110910.0, "Sofia", "EU", 4, "BU", "BG", "BGR", 100, "Bulgaria", "359", 0L, "####", "^(\\d{4})$", null },
                    { 12, 8511965.0, "Brasilia", "SA", 6, "BR", "BR", "BRA", 76, "Brazil", "55", 0L, "#####-###", "^\\d{5}-\\d{3}$", null },
                    { 11, 53.0, "Hamilton", "NA", 5, "BD", "BM", "BMU", 60, "Bermuda", "+1-441", 0L, "@@ ##", "^([A-Z]{2}\\d{2})$", null },
                    { 10, 30510.0, "Brussels", "EU", 15, "BE", "BE", "BEL", 56, "Belgium", "32", 0L, "####", "^(\\d{4})$", null },
                    { 9, 207600.0, "Minsk", "EU", 7, "BO", "BY", "BLR", 112, "Belarus", "375", 0L, "######", "^(\\d{6})$", null },
                    { 8, 144000.0, "Dhaka", "AS", 3, "BG", "BD", "BGD", 50, "Bangladesh", "880", 0L, "####", "^(\\d{4})$", null },
                    { 7, 83858.0, "Vienna", "EU", 15, "AU", "AT", "AUT", 40, "Austria", "43", 0L, "####", "^(\\d{4})$", null },
                    { 6, 7686850.0, "Canberra", "OC", 2, "AS", "AU", "AUS", 36, "Australia", "61", 0L, "####", "^(\\d{4})$", null },
                    { 5, 2766890.0, "Buenos Aires", "SA", 1, "AR", "AR", "ARG", 32, "Argentina", "54", 0L, "@####@@@", "^[A-Z]?\\d{4}[A-Z]{0,3}$", null },
                    { 4, 468.0, "Andorra la Vella", "EU", 15, "AN", "AD", "AND", 20, "Andorra", "376", 0L, "AD###", "^(?:AD)*(\\d{3})$", null },
                    { 3, 199.0, "Pago Pago", "OC", 40, "AQ", "AS", "ASM", 16, "American Samoa", "+1-684", 0L, "#####-####", "96799", null },
                    { 2, 2381740.0, "Algiers", "AF", 14, "AG", "DZ", "DZA", 12, "Algeria", "213", 0L, "#####", "^(\\d{5})$", null },
                    { 19, 43094.0, "Copenhagen", "EU", 12, "DA", "DK", "DNK", 208, "Denmark", "45", 0L, "####", "^(\\d{4})$", null },
                    { 20, 48730.0, "Santo Domingo", "NA", 13, "DR", "DO", "DOM", 214, "Dominican Republic", "+1-809 and 1-829", 0L, "#####", "^(\\d{5})$", null },
                    { 21, 1399.0, "Torshavn", "EU", 12, "FO", "FO", "FRO", 234, "Faroe Islands", "298", 0L, "###", "^(?:FO)*(\\d{3})$", null },
                    { 22, 337030.0, "Helsinki", "EU", 15, "FI", "FI", "FIN", 246, "Finland", "358", 0L, "#####", "^(?:FI)*(\\d{5})$", null },
                    { 40, 160.0, "Vaduz", "EU", 20, "LS", "LI", "LIE", 438, "Liechtenstein", "423", 0L, "####", "^(\\d{4})$", null },
                    { 39, 64589.0, "Riga", "EU", 15, "LG", "LV", "LVA", 428, "Latvia", "371", 0L, "LV-####", "^(?:LV)*(\\d{4})$", null },
                    { 38, 116.0, "Saint Helier", "EU", 16, "JE", "JE", "JEY", 832, "Jersey", "+44-1534", 0L, "@# #@@|@## #@@|@@# #@@|@@## #@@|@#@ #@@|@@#@ #@@|GIR0AA", "^((?:(?:[A-PR-UWYZ][A-HK-Y]\\d[ABEHMNPRV-Y0-9]|[A-PR-UWYZ]\\d[A-HJKPS-UW0-9])\\s\\d[ABD-HJLNP-UW-Z]{2})|GIR\\s?0AA)$", null },
                    { 37, 377835.0, "Tokyo", "AS", 23, "JA", "JP", "JPN", 392, "Japan", "81", 0L, "###-####", "^\\d{3}-\\d{4}$", null },
                    { 36, 301230.0, "Rome", "EU", 15, "IT", "IT", "ITA", 380, "Italy", "39", 0L, "#####", "^(\\d{5})$", null },
                    { 35, 572.0, "Douglas", "EU", 16, "IM", "IM", "IMN", 833, "Isle of Man", "+44-1624", 0L, "@# #@@|@## #@@|@@# #@@|@@## #@@|@#@ #@@|@@#@ #@@|GIR0AA", "^((?:(?:[A-PR-UWYZ][A-HK-Y]\\d[ABEHMNPRV-Y0-9]|[A-PR-UWYZ]\\d[A-HJKPS-UW0-9])\\s\\d[ABD-HJLNP-UW-Z]{2})|GIR\\s?0AA)$", null },
                    { 34, 70280.0, "Dublin", "EU", 15, "EI", "IE", "IRL", 372, "Ireland", "353", 0L, "@@@ @@@@", "^[A-Z]\\d{2}$|^[A-Z]{3}[A-Z]{4}$", null },
                    { 33, 3287590.0, "New Delhi", "AS", 21, "IN", "IN", "IND", 356, "India", "91", 0L, "######", "^(\\d{6})$", null },
                    { 42, 2586.0, "Luxembourg", "EU", 15, "LU", "LU", "LUX", 442, "Luxembourg", "352", 0L, "L-####", "^(?:L-)?\\d{4}$", null },
                    { 32, 103000.0, "Reykjavik", "EU", 22, "IC", "IS", "ISL", 352, "Iceland", "354", 0L, "###", "^(\\d{3})$", null },
                    { 30, 78.0, "St Peter Port", "EU", 16, "GK", "GG", "GGY", 831, "Guernsey", "+44-1481", 0L, "@# #@@|@## #@@|@@# #@@|@@## #@@|@#@ #@@|@@#@ #@@|GIR0AA", "^((?:(?:[A-PR-UWYZ][A-HK-Y]\\d[ABEHMNPRV-Y0-9]|[A-PR-UWYZ]\\d[A-HJKPS-UW0-9])\\s\\d[ABD-HJLNP-UW-Z]{2})|GIR\\s?0AA)$", null },
                    { 29, 108890.0, "Guatemala City", "NA", 17, "GT", "GT", "GTM", 320, "Guatemala", "502", 0L, "#####", "^(\\d{5})$", null },
                    { 28, 549.0, "Hagatna", "OC", 40, "GQ", "GU", "GUM", 316, "Guam", "+1-671", 0L, "969##", "^(969\\d{2})$", null },
                    { 27, 1780.0, "Basse-Terre", "NA", 15, "GP", "GP", "GLP", 312, "Guadeloupe", "590", 0L, "#####", "^((97|98)\\d{3})$", null },
                    { 26, 2166086.0, "Nuuk", "NA", 12, "GL", "GL", "GRL", 304, "Greenland", "299", 0L, "####", "^(\\d{4})$", null },
                    { 25, 357021.0, "Berlin", "EU", 15, "GM", "DE", "DEU", 276, "Germany", "49", 0L, "#####", "^(\\d{5})$", null },
                    { 24, 91000.0, "Cayenne", "SA", 15, "FG", "GF", "GUF", 254, "French Guiana", "594", 0L, "#####", "^((97|98)3\\d{2})$", null },
                    { 23, 547030.0, "Paris", "EU", 15, "FR", "FR", "FRA", 250, "France", "33", 0L, "#####", "^(\\d{5})$", null },
                    { 31, 93030.0, "Budapest", "EU", 19, "HU", "HU", "HUN", 348, "Hungary", "36", 0L, "####", "^(\\d{4})$", null },
                    { 85, 274.0, "Mata Utu", "OC", 42, "WF", "WF", "WLF", 876, "Wallis and Futuna", "681", 0L, "#####", "^(986\\d{2})$", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_CurrencyId",
                table: "Country",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
