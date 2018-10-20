using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fake.DataAccess.Database.CountryData.Migrations
{
    public partial class StateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "TopLevelDomain",
                value: ".ax");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "TopLevelDomain",
                value: ".dz");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "TopLevelDomain",
                value: ".as");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "TopLevelDomain",
                value: ".ad");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "TopLevelDomain",
                value: ".ar");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "TopLevelDomain",
                value: ".au");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "TopLevelDomain",
                value: ".at");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8,
                column: "TopLevelDomain",
                value: ".bd");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9,
                column: "TopLevelDomain",
                value: ".by");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10,
                column: "TopLevelDomain",
                value: ".be");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11,
                column: "TopLevelDomain",
                value: ".bm");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 12,
                column: "TopLevelDomain",
                value: ".br");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 13,
                column: "TopLevelDomain",
                value: ".bg");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 14,
                column: "TopLevelDomain",
                value: ".ca");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 15,
                column: "TopLevelDomain",
                value: ".co");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 16,
                column: "TopLevelDomain",
                value: ".cr");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 17,
                column: "TopLevelDomain",
                value: ".hr");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 18,
                column: "TopLevelDomain",
                value: ".cz");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 19,
                column: "TopLevelDomain",
                value: ".dk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 20,
                column: "TopLevelDomain",
                value: ".do");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 21,
                column: "TopLevelDomain",
                value: ".fo");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 22,
                column: "TopLevelDomain",
                value: ".fi");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 23,
                column: "TopLevelDomain",
                value: ".fr");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 24,
                column: "TopLevelDomain",
                value: ".gf");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 25,
                column: "TopLevelDomain",
                value: ".de");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 26,
                column: "TopLevelDomain",
                value: ".gl");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 27,
                column: "TopLevelDomain",
                value: ".gp");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 28,
                column: "TopLevelDomain",
                value: ".gu");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 29,
                column: "TopLevelDomain",
                value: ".gt");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 30,
                column: "TopLevelDomain",
                value: ".gg");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 31,
                column: "TopLevelDomain",
                value: ".hu");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 32,
                column: "TopLevelDomain",
                value: ".is");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 33,
                column: "TopLevelDomain",
                value: ".in");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 34,
                column: "TopLevelDomain",
                value: ".ie");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 35,
                column: "TopLevelDomain",
                value: ".im");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 36,
                column: "TopLevelDomain",
                value: ".it");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 37,
                column: "TopLevelDomain",
                value: ".jp");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 38,
                column: "TopLevelDomain",
                value: ".je");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 39,
                column: "TopLevelDomain",
                value: ".lv");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 40,
                column: "TopLevelDomain",
                value: ".li");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 41,
                column: "TopLevelDomain",
                value: ".lt");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 42,
                column: "TopLevelDomain",
                value: ".lu");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 43,
                column: "TopLevelDomain",
                value: ".mk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 44,
                column: "TopLevelDomain",
                value: ".my");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 45,
                column: "TopLevelDomain",
                value: ".mt");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 46,
                column: "TopLevelDomain",
                value: ".mh");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 47,
                column: "TopLevelDomain",
                value: ".mq");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 48,
                column: "TopLevelDomain",
                value: ".yt");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 49,
                column: "TopLevelDomain",
                value: ".mx");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 50,
                column: "TopLevelDomain",
                value: ".fm");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 51,
                column: "TopLevelDomain",
                value: ".md");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 52,
                column: "TopLevelDomain",
                value: ".mc");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 53,
                column: "TopLevelDomain",
                value: ".nl");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 54,
                column: "TopLevelDomain",
                value: ".nc");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 55,
                column: "TopLevelDomain",
                value: ".nz");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 56,
                column: "TopLevelDomain",
                value: ".mp");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 57,
                column: "TopLevelDomain",
                value: ".no");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 58,
                column: "TopLevelDomain",
                value: ".pk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 59,
                column: "TopLevelDomain",
                value: ".pw");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 60,
                column: "TopLevelDomain",
                value: ".ph");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 61,
                column: "TopLevelDomain",
                value: ".pl");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 62,
                column: "TopLevelDomain",
                value: ".pt");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 63,
                column: "TopLevelDomain",
                value: ".pr");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 64,
                column: "TopLevelDomain",
                value: ".re");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 65,
                column: "TopLevelDomain",
                value: ".ro");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 66,
                column: "TopLevelDomain",
                value: ".ru");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 67,
                column: "TopLevelDomain",
                value: ".pm");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 68,
                column: "TopLevelDomain",
                value: ".sm");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 69,
                column: "TopLevelDomain",
                value: ".sk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 70,
                column: "TopLevelDomain",
                value: ".si");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 71,
                column: "TopLevelDomain",
                value: ".za");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 72,
                column: "TopLevelDomain",
                value: ".es");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 73,
                column: "TopLevelDomain",
                value: ".lk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 74,
                column: "TopLevelDomain",
                value: ".sj");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 75,
                column: "TopLevelDomain",
                value: ".se");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 76,
                column: "TopLevelDomain",
                value: ".ch");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 77,
                column: "TopLevelDomain",
                value: ".th");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 78,
                column: "TopLevelDomain",
                value: ".tr");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 79,
                column: "TopLevelDomain",
                value: ".vi");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 80,
                column: "TopLevelDomain",
                value: ".ua");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 81,
                column: "TopLevelDomain",
                value: ".uk");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 82,
                column: "TopLevelDomain",
                value: ".us");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 83,
                column: "TopLevelDomain",
                value: ".uy");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 84,
                column: "TopLevelDomain",
                value: ".va");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 85,
                column: "TopLevelDomain",
                value: ".wf");

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { 872, "82", 77, "Phang Nga" },
                    { 932, "B1", 39, "Raunas nov." },
                    { 931, "70", 77, "Ratchaburi" },
                    { 930, "85", 77, "Ranong" },
                    { 929, "87", 8, "Rangpur Division" },
                    { 928, "83", 8, "Rājshāhi Division" },
                    { 927, "24", 33, "Rajasthan" },
                    { 926, "ROO", 49, "Quintana Roo" },
                    { 925, "23", 15, "Quindio" },
                    { 924, "QUE", 49, "Querétaro" },
                    { 923, "QLD", 6, "Queensland" },
                    { 922, "115", 63, "Quebradillas" },
                    { 921, "QC", 14, "Quebec" },
                    { 920, "43", 45, "Qormi" },
                    { 919, "22", 15, "Putumayo" },
                    { 918, "PJY", 44, "Putrajaya" },
                    { 917, "23", 33, "Punjab" },
                    { 916, "PNG", 44, "Pulau Pinang" },
                    { 933, "21", 77, "Rayong" },
                    { 934, "RD", 42, "Redange" },
                    { 935, "84", 19, "Region Hovedstaden" },
                    { 936, "82", 19, "Region Midtjylland" },
                    { 954, "23", 12, "Rio Grande do Sul" },
                    { 953, "22", 12, "Rio Grande do Norte" },
                    { 952, "119", 63, "Rio Grande" },
                    { 951, "21", 12, "Rio de Janeiro" },
                    { 950, "117", 63, "Rincon" },
                    { 949, "B3", 39, "Riebiņu nov." },
                    { 948, null, 51, "Ribnita Tr." },
                    { 947, "RI", 82, "Rhode Island" },
                    { 915, "PU", 36, "Puglia" },
                    { 946, "RP", 25, "Rheinland-Pfalz" },
                    { 944, "24", 39, "Rēzeknes nov." },
                    { 943, "00", 64, "Reunion (general)" },
                    { 942, "RE", 64, "Réunion" },
                    { 941, "RM", 42, "Remich" },
                    { 940, "48", 2, "Relizane" },
                    { 939, "83", 19, "Region Syddanmark" },
                    { 938, "85", 19, "Region Sjælland" },
                    { 937, "81", 19, "Region Nordjylland" },
                    { 945, null, 51, "Rezina" },
                    { 955, "R", 5, "Rio Negro" },
                    { 914, "PUE", 49, "Puebla" },
                    { 912, "07", 16, "Provincia de Puntarenas" },
                    { 889, "82", 61, "Pomerania" },
                    { 888, "18", 80, "Poltavska" },
                    { 887, "81", 61, "Podlasie" },
                    { 886, "A6", 39, "Pļaviņu nov." },
                    { 885, "7006", 40, "Planken" },
                    { 884, "06", 22, "Pirkanmaa" },
                    { 883, "PM", 36, "Piemonte" },
                    { 882, "20", 12, "Piaui" },
                    { 881, "83", 77, "Phuket" },
                    { 880, "14", 77, "Phranakhon Si Ayutthaya" },
                    { 879, "54", 77, "Phrae" },
                    { 878, "65", 77, "Phitsanulok" },
                    { 877, "66", 77, "Phichit" },
                    { 876, "76", 77, "Phetchaburi" },
                    { 875, "76", 77, "Phetchabun" },
                    { 874, "56", 77, "Phayao" },
                    { 873, "93", 77, "Phatthalung" },
                    { 890, "113", 63, "Ponce" },
                    { 891, "22", 33, "Pondicherry" },
                    { 892, "16", 62, "Portalegre" },
                    { 893, "17", 62, "Porto" },
                    { 911, "06", 16, "Provincia de Limón" },
                    { 910, "04", 16, "Provincia de Heredia" },
                    { 909, "03", 16, "Provincia de Guanacaste" },
                    { 908, "02", 16, "Provincia de Cartago" },
                    { 907, "01", 16, "Provincia de Alajuela" },
                    { 906, "02", 54, "Province Sud" },
                    { 905, "01", 54, "Province Nord" },
                    { 904, "93", 23, "Provence-Alpes-Côte d'Azur" },
                    { 913, "08", 16, "Provincia de San José" },
                    { 903, "PE", 14, "Prince Edward Island" },
                    { 901, "A9", 39, "Priekuļu nov." },
                    { 900, "A8", 39, "Priekules nov." },
                    { 899, "PV", 69, "Prešovský kraj" },
                    { 898, "22", 39, "Preiļu nov." },
                    { 897, "77", 77, "Prachuap Khirikhan" },
                    { 896, "25", 77, "Prachinburi" },
                    { 895, "30", 65, "Prahova" },
                    { 894, null, 17, "Požeško-Slavonska" },
                    { 902, null, 17, "Primorsko-Goranska" },
                    { 956, "12", 83, "Rio Negro" },
                    { 998, "31", 65, "Sălaj" },
                    { 958, null, 51, "Riscani" },
                    { 1019, "63", 78, "Şanliurfa" },
                    { 1018, "08", 11, "Sandys Parish" },
                    { 1017, "131", 63, "San Sebastian" },
                    { 1016, "SLP", 49, "San Luis Potosí" },
                    { 1015, "D", 5, "San Luis" },
                    { 1014, "129", 63, "San Lorenzo" },
                    { 1013, "127", 63, "San Juan" },
                    { 1012, "J", 5, "San Juan" },
                    { 1011, "16", 83, "San Jose" },
                    { 1010, "125", 63, "San German" },
                    { 1009, "75", 77, "Samut Songkhram" },
                    { 1008, "74", 77, "Samut Sakhon" },
                    { 1007, "11", 77, "Samut Prakan" },
                    { 1006, "55", 78, "Samsun" },
                    { 1005, "05", 7, "Salzburg" },
                    { 1004, "15", 83, "Salto" },
                    { 1003, "A", 5, "Salta" },
                    { 1020, "54", 45, "Sannat" },
                    { 1021, "26", 12, "Santa Catarina" },
                    { 1022, "Z", 5, "Santa Cruz" },
                    { 1023, "S", 5, "Santa Fe" },
                    { 1041, "19", 2, "Setif" },
                    { 1040, "28", 12, "Sergipe" },
                    { 1039, "SGR", 44, "Selangor" },
                    { 1038, "C6", 39, "Sējas nov." },
                    { 1037, "SCT", 81, "Scotland" },
                    { 1036, "C5", 39, "Saulkrastu nov." },
                    { 1035, "91", 77, "Satun" },
                    { 1034, "32", 65, "Satu Mare" },
                    { 1002, "123", 63, "Salinas" },
                    { 1033, "04", 22, "Satakunta" },
                    { 1031, "SD", 36, "Sardegna" },
                    { 1030, "SRW", 44, "Sarawak" },
                    { 1029, "19", 77, "Saraburi" },
                    { 1028, "27", 12, "Sao Paulo" },
                    { 1027, "G", 5, "Santiago Del Estero" },
                    { 1026, "18", 62, "Santarém" },
                    { 1025, "26", 15, "Santander" },
                    { 1024, "133", 63, "Santa Isabel" },
                    { 1032, "SK", 14, "Saskatchewan" },
                    { 1001, "27", 39, "Saldus nov." },
                    { 1000, "C3", 39, "Salaspils nov." },
                    { 999, "C2", 39, "Salas nov." },
                    { 976, "SL", 25, "Saarland" },
                    { 975, "27", 77, "Sa Kaeo" },
                    { 974, "B9", 39, "Rundāles nov." },
                    { 973, "B8", 39, "Rūjienas nov." },
                    { 972, "7010", 40, "Ruggell" },
                    { 971, "B7", 39, "Rugāju nov." },
                    { 970, "B6", 39, "Rucavas nov." },
                    { 969, "100", 56, "Rota" },
                    { 977, "SBH", 44, "Sabah" },
                    { 968, "25", 12, "Roraima" },
                    { 966, "24", 12, "Rondonia" },
                    { 965, "B4", 39, "Rojas nov." },
                    { 964, "45", 77, "Roi Et" },
                    { 963, "14", 83, "Rocha" },
                    { 962, "11", 57, "Rogaland" },
                    { 961, "53", 78, "Rize" },
                    { 960, "19", 80, "Rivnenska" },
                    { 959, "13", 83, "Rivera" },
                    { 967, "B5", 39, "Ropažu nov." },
                    { 957, "24", 15, "Risaralda" },
                    { 978, "121", 63, "Sabana Grande" },
                    { 980, "47", 45, "Safi" },
                    { 871, "PE", 31, "Pest" },
                    { 997, "47", 77, "Sakon Nakhon" },
                    { 996, "54", 78, "Sakarya" },
                    { 995, "34", 37, "Saitama Ken" },
                    { 994, "110", 56, "Saipan" },
                    { 993, "97502", 67, "Saint-Pierre" },
                    { 992, "53", 45, "Saint Venera" },
                    { 991, "52", 45, "Saint Paul’s Bay" },
                    { 979, "97616", 48, "Sada" },
                    { 990, "51", 45, "Saint Lucia" },
                    { 988, "49", 45, "Saint Julian's" },
                    { 987, "48", 45, "Saint John" },
                    { 986, "07", 11, "Saint George’s Parish" },
                    { 985, "06", 11, "Saint George" },
                    { 984, "20", 2, "Saida" },
                    { 983, "ST", 25, "Sachsen-Anhalt" },
                    { 982, "SN", 25, "Sachsen" },
                    { 981, "33", 37, "Saga Ken" },
                    { 989, "50", 45, "Saint Lawrence" },
                    { 870, "30", 12, "Pernambuco" },
                    { 828, "79", 61, "Opole Voivodeship" },
                    { 868, "PRK", 44, "Perak" },
                    { 758, "55", 77, "Nan" },
                    { 757, "80", 77, "Nakhon Sie Thammarat" },
                    { 756, "60", 77, "Nakhon Sawan" },
                    { 755, "30", 77, "Nakhon Ratchasima" },
                    { 754, "48", 77, "Nakhon Phanom" },
                    { 753, "73", 77, "Nakhon Pathom" },
                    { 752, "26", 77, "Nakhon Nayok" },
                    { 751, "103", 63, "Naguabo" },
                    { 750, "27", 37, "Nagasaki Ken" },
                    { 749, "26", 37, "Nagano Ken" },
                    { 748, "20", 33, "Nagaland" },
                    { 747, "45", 2, "Naama" },
                    { 746, null, 77, "Na Tan" },
                    { 745, "16", 80, "Mykolaivska" },
                    { 744, "49", 78, "Muş" },
                    { 743, "27", 65, "Mureş" },
                    { 742, "MC", 72, "Murcia" },
                    { 759, "28", 37, "Nara Ken" },
                    { 760, "105", 63, "Naranjito" },
                    { 761, "96", 77, "Narathiwat" },
                    { 762, "20", 15, "Nariño" },
                    { 780, "NL", 14, "Newfoundland and Labrador" },
                    { 779, "NY", 82, "New York" },
                    { 778, "NSW", 6, "New South Wales" },
                    { 777, "NM", 82, "New Mexico" },
                    { 776, "NJ", 82, "New Jersey" },
                    { 775, "NH", 82, "New Hampshire" },
                    { 774, "NB", 14, "New Brunswick" },
                    { 773, "50", 78, "Nevşehir" },
                    { 741, null, 51, "Mun.Chisinau" },
                    { 772, "NV", 82, "Nevada" },
                    { 770, "NE", 76, "Neuchâtel" },
                    { 769, "98", 39, "Neretas nov." },
                    { 768, "NSN", 44, "Negeri Sembilan" },
                    { 767, "NE", 82, "Nebraska" },
                    { 766, "28", 65, "Neamţ" },
                    { 765, "NAY", 49, "Nayarit" },
                    { 764, "NC", 72, "Navarra" },
                    { 763, "97", 39, "Naukšēnu nov." },
                    { 771, "Q", 5, "Neuquen" },
                    { 740, null, 51, "Mun.Balti" },
                    { 739, "49", 77, "Mukdahan" },
                    { 738, "48", 78, "Muğla" },
                    { 715, "MN", 82, "Minnesota" },
                    { 714, "15", 12, "Minas Gerais" },
                    { 713, "43", 2, "Mila" },
                    { 712, "MIC", 49, "Michoacán de Ocampo" },
                    { 711, "MI", 82, "Michigan" },
                    { 710, "23", 37, "Mie Ken" },
                    { 709, "68", 46, "Mh" },
                    { 708, "MEX", 49, "México" },
                    { 716, null, 9, "Minsk" },
                    { 707, "19", 15, "Meta" },
                    { 705, "32", 78, "Mersin(İçel)" },
                    { 704, "ME", 42, "Mersch" },
                    { 703, "M", 5, "Mendoza" },
                    { 702, "ML", 72, "Melilla" },
                    { 701, "MLK", 44, "Melaka" },
                    { 700, "26", 65, "Mehedinţi" },
                    { 699, "18", 33, "Meghalaya" },
                    { 698, null, 17, "Međimurska" },
                    { 706, "F1", 39, "Mērsraga nov." },
                    { 781, "99", 39, "Nīcas nov." },
                    { 717, "97501", 67, "Miquelon-Langlade" },
                    { 719, "MS", 82, "Mississippi" },
                    { 737, "97613", 48, "M'Tsangamouji" },
                    { 736, "97612", 48, "Mtsamboro" },
                    { 735, "28", 2, "M'Sila" },
                    { 734, "27", 2, "Mostaganem" },
                    { 733, "101", 63, "Morovis" },
                    { 732, "MOR", 49, "Morelos" },
                    { 731, "15", 57, "Møre og Romsdal" },
                    { 730, "10", 83, "Montevideo" },
                    { 718, "N", 5, "Misiones" },
                    { 729, "MT", 82, "Montana" },
                    { 727, "ML", 36, "Molise" },
                    { 726, null, 9, "Mogholev" },
                    { 725, null, 9, "Moghilev" },
                    { 724, "099", 63, "Moca" },
                    { 723, "31", 33, "Mizoram" },
                    { 722, "25", 37, "Miyazaki Ken" },
                    { 721, "24", 37, "Miyagi Ken" },
                    { 720, "MO", 82, "Missouri" },
                    { 728, "01", 52, "Monaco" },
                    { 869, "PLS", 44, "Perlis" },
                    { 782, "03", 7, "Niederösterreich" },
                    { 784, "73", 78, "Niğde" },
                    { 845, "04", 2, "Oum-El-Bouaghi" },
                    { 844, "30", 2, "Ouargla" },
                    { 843, "97614", 48, "Ouangani" },
                    { 842, "15", 22, "Ostrobothnia Region" },
                    { 841, "01", 57, "Østfold" },
                    { 840, "E", 75, "Östergötland" },
                    { 839, "91", 78, "Osmaniye" },
                    { 838, "03", 57, "Oslo" },
                    { 837, null, 17, "Osječko-Baranjska" },
                    { 836, "32", 37, "Osaka Fu" },
                    { 835, "107", 63, "Orocovis" },
                    { 834, null, 51, "Orhei" },
                    { 833, "OR", 82, "Oregon" },
                    { 832, "T", 75, "Örebro" },
                    { 831, "52", 78, "Ordu" },
                    { 830, "31", 2, "Oran" },
                    { 829, "05", 57, "Oppland" },
                    { 846, "15", 53, "Overijssel" },
                    { 847, "A3", 39, "Ozolnieku nov." },
                    { 848, "04", 11, "Paget Parish" },
                    { 849, "PHG", 44, "Pahang" },
                    { 867, "111", 63, "Penuelas" },
                    { 866, "PA", 82, "Pennsylvania" },
                    { 865, "05", 11, "Pembroke Parish" },
                    { 864, "40", 45, "Pembroke" },
                    { 863, "07", 22, "Päijänne Tavastia" },
                    { 862, "11", 83, "Paysandu" },
                    { 861, "52", 23, "Pays de la Loire" },
                    { 860, "A5", 39, "Pāvilostas nov." },
                    { 1042, "19", 62, "Setúbal" },
                    { 859, "94", 77, "Pattani" },
                    { 857, "13", 77, "Pathum Thani" },
                    { 856, "A4", 39, "Pārgaujas nov." },
                    { 855, "18", 12, "Parana" },
                    { 854, "17", 12, "Paraiba" },
                    { 853, "16", 12, "Para" },
                    { 852, "39", 45, "Paola" },
                    { 851, "97615", 48, "Pamandzi" },
                    { 850, "PV", 72, "Pais Vasco" },
                    { 858, "109", 63, "Patillas" },
                    { 827, "ON", 14, "Ontario" },
                    { 826, "29", 65, "Olt" },
                    { 825, "A2", 39, "Olaines nov." },
                    { 802, "12", 22, "North Karelia" },
                    { 801, "ND", 82, "North Dakota" },
                    { 800, "NC", 82, "North Carolina" },
                    { 799, "21", 15, "Norte De Santander" },
                    { 798, "BD", 75, "Norrbotten" },
                    { 797, "28", 23, "Normandie" },
                    { 796, null, 58, "Norhern Punajb Rawalpindi" },
                    { 795, "NW", 25, "Nordrhein-Westfalen" },
                    { 803, "17", 22, "North Ostrobothnia Region" },
                    { 794, "18", 57, "Nordland" },
                    { 792, "06", 53, "Noord-Brabant" },
                    { 791, "12", 77, "Nonthaburi" },
                    { 790, "43", 77, "Nong Khai" },
                    { 789, "39", 77, "Non Bua Lam Phu" },
                    { 788, "NO", 31, "Nógrád" },
                    { 787, "NI", 69, "Nitriansky kraj" },
                    { 786, null, 51, "Nisporeni" },
                    { 785, "29", 37, "Niigata Ken" },
                    { 793, "07", 53, "Noord-Holland" },
                    { 783, "NI", 25, "Niedersachsen" },
                    { 804, "NIR", 81, "Northern Ireland" },
                    { 806, "NT", 6, "Northern Territory" },
                    { 824, "OK", 82, "Oklahoma" },
                    { 823, "47", 37, "Okinawa Ken" },
                    { 822, "31", 37, "Okayama Ken" },
                    { 821, "30", 37, "Oita Ken" },
                    { 820, "OH", 82, "Ohio" },
                    { 819, "21", 39, "Ogres nov." },
                    { 818, "21", 33, "Odisha" },
                    { 817, "17", 80, "Odeska" },
                    { 805, "11", 22, "Northern Savo" },
                    { 816, null, 51, "Ocnita" },
                    { 814, "04", 7, "Oberösterreich" },
                    { 813, "OAX", 49, "Oaxaca" },
                    { 812, null, 58, "NWFP Peshawar" },
                    { 811, "NU", 14, "Nunavut Territory" },
                    { 810, "NLE", 49, "Nuevo León" },
                    { 809, "NS", 14, "Nova Scotia" },
                    { 808, "75", 23, "Nouvelle-Aquitaine" },
                    { 807, "NT", 14, "Northwest Territory" },
                    { 815, "76", 23, "Occitanie" },
                    { 1043, "35", 37, "Shiga Ken" },
                    { 1085, "14", 22, "South Ostrobothnia Region" },
                    { 1045, "37", 37, "Shizuoka Ken" },
                    { 1280, "27", 80, "Zhytomyrska" },
                    { 1279, "10", 53, "Zeeland" },
                    { 1278, "26", 80, "Zaporizka" },
                    { 1277, "ZA", 31, "Zala" },
                    { 1276, "25", 80, "Zakarpatska" },
                    { 1275, null, 17, "Zagrebačka" },
                    { 1274, null, 17, "Zadarska" },
                    { 1273, "ZAC", 49, "Zacatecas" },
                    { 1272, "YT", 14, "Yukon" },
                    { 1271, "YUC", 49, "Yucatán" },
                    { 1270, "66", 78, "Yozgat" },
                    { 1269, "153", 63, "Yauco" },
                    { 1268, "35", 77, "Yasothon" },
                    { 1267, "46", 37, "Yamanashi Ken" },
                    { 1266, "45", 37, "Yamaguchi Ken" },
                    { 1265, "44", 37, "Yamagata Ken" },
                    { 1264, "92", 78, "Yalova" },
                    { 1281, "E9", 39, "Zilupes nov." },
                    { 1282, "85", 78, "Zonguldak" },
                    { 1283, "11", 53, "Zuid-Holland" },
                    { 1284, "ZI", 69, "Žilinský kraj" },
                    { 1302, "84", 66, "Волгоградская Область" },
                    { 1301, "83", 66, "Владимирская Область" },
                    { 1300, "VID", 13, "Видин / Vidin" },
                    { 1299, "VTR", 13, "Велико Търново / Veliko Turnovo" },
                    { 1298, "VAR", 13, "Варна / Varna" },
                    { 1297, "11", 66, "Бурятия Республика" },
                    { 1296, "BGS", 13, "Бургас / Burgas" },
                    { 1295, "10", 66, "Брянская Область" },
                    { 1263, "95", 77, "Yala" },
                    { 1294, "BLG", 13, "Благоевград / Blagoevgrad" },
                    { 1292, "08", 66, "Башкортостан Республика" },
                    { 1291, "08", 66, "Байконур" },
                    { 1290, "07", 66, "Астраханская Область" },
                    { 1289, "06", 66, "Архангельская Область" },
                    { 1288, "05", 66, "Амурская Область" },
                    { 1287, "04", 66, "Алтайский Край" },
                    { 1286, "03", 66, "Алтай Республика" },
                    { 1285, "01", 66, "Адыгея Республика" },
                    { 1293, "09", 66, "Белгородская Область" },
                    { 1262, "151", 63, "Yabucoa" },
                    { 1261, "WY", 82, "Wyoming" },
                    { 1260, "WI", 82, "Wisconsin" },
                    { 1237, "23", 80, "Vinnytska" },
                    { 1236, "149", 63, "Villalba" },
                    { 1235, "E8", 39, "Viļānu nov." },
                    { 1234, "E7", 39, "Viļakas nov." },
                    { 1233, "21", 62, "Vila Real" },
                    { 1232, "31", 15, "Vichada" },
                    { 1231, "E6", 39, "Viesītes nov." },
                    { 1230, "147", 63, "Vieques" },
                    { 1238, "VA", 82, "Virginia" },
                    { 1229, "46", 45, "Victoria" },
                    { 1227, "VD", 42, "Vianden" },
                    { 1226, "20", 62, "Viana do Castelo" },
                    { 1225, "78", 79, "Vi" },
                    { 1224, "VE", 31, "Veszprém" },
                    { 1223, "07", 57, "Vestfold" },
                    { 1222, "10", 57, "Vest-Agder" },
                    { 1221, "VT", 82, "Vermont" },
                    { 1220, "VER", 49, "Veracruz de Ignacio de la Llave" },
                    { 1228, "VIC", 6, "Victoria" },
                    { 1303, "85", 66, "Вологодская Область" },
                    { 1239, null, 17, "Virovitičko-Podravska" },
                    { 1241, null, 9, "Vitebk" },
                    { 1259, "WI", 42, "Wiltz" },
                    { 1258, "09", 7, "Wien" },
                    { 1257, "WA", 6, "Western Australia" },
                    { 1256, "WV", 82, "West Virginia" },
                    { 1255, "87", 61, "West Pomerania" },
                    { 1254, "28", 33, "West Bengal" },
                    { 1253, "WA", 82, "Washington" },
                    { 1252, "11", 11, "Warwick Parish" },
                    { 1240, "22", 62, "Viseu" },
                    { 1251, "85", 61, "Warmia-Masuria" },
                    { 1249, "WLS", 81, "Wales" },
                    { 1248, "43", 37, "Wakayama Ken" },
                    { 1247, null, 17, "Vukovarsko-Srijemska" },
                    { 1246, "40", 65, "Vrancea" },
                    { 1245, "08", 7, "Vorarlberg" },
                    { 1244, "24", 80, "Volynska" },
                    { 1243, "VLG", 10, "Vlaanderen" },
                    { 1242, null, 9, "Vitebsk" },
                    { 1250, "WAL", 10, "Wallonie" },
                    { 1219, "33", 39, "Ventspils nov." },
                    { 1304, "86", 66, "Воронежская Область" },
                    { 1306, "GAB", 13, "Габрово / Gabrovo" },
                    { 1367, "SML", 13, "Смолян / Smoljan" },
                    { 1366, "69", 66, "Смоленская Область" },
                    { 1365, "SLV", 13, "Сливен / Sliven" },
                    { 1364, "SLS", 13, "Силистра / Silistra" },
                    { 1363, "68", 66, "Северная Осетия-Алания Республика" },
                    { 1362, "71", 66, "Свердловская Область" },
                    { 1361, "64", 66, "Сахалинская Область" },
                    { 1360, "63", 66, "Саха (Якутия) Республика" },
                    { 1359, "67", 66, "Саратовская Область" },
                    { 1358, "66", 66, "Санкт-Петербург" },
                    { 1357, "65", 66, "Самарская Область" },
                    { 1356, "62", 66, "Рязанская Область" },
                    { 1355, "RSE", 13, "Русе / Ruse" },
                    { 1354, "61", 66, "Ростовская Область" },
                    { 1353, "RAZ", 13, "Разград / Razgrad" },
                    { 1352, "60", 66, "Псковская Область" },
                    { 1351, "59", 66, "Приморский Край" },
                    { 1368, "SOF", 13, "София (столица) / Sofija (stolica)" },
                    { 1369, "SFO", 13, "София / Sofija" },
                    { 1370, "70", 66, "Ставропольский Край" },
                    { 1371, "SZR", 13, "Стара Загора / Stara Zagora" },
                    { 1389, "SHU", 13, "Шумен / Shumen" },
                    { 1388, "16", 66, "Чувашская Республика" },
                    { 1387, null, 66, "Читинская Область" },
                    { 1386, "12", 66, "Чеченская Республика" },
                    { 1385, "13", 66, "Челябинская Область" },
                    { 1384, "HKV", 13, "Хасково / Khaskovo" },
                    { 1383, "31", 66, "Хакасия Республика" },
                    { 1382, "30", 66, "Хабаровский Край" },
                    { 1350, "PDV", 13, "Пловдив / Plovdiv" },
                    { 1381, "81", 66, "Ульяновская Область" },
                    { 1379, "78", 66, "Тюменская Область" },
                    { 1378, "79", 66, "Тыва Республика" },
                    { 1377, "TGV", 13, "Търговище / Turgovishhe" },
                    { 1376, "76", 66, "Тульская Область" },
                    { 1375, "75", 66, "Томская Область" },
                    { 1374, "77", 66, "Тверская Область" },
                    { 1373, "73", 66, "Татарстан Республика" },
                    { 1372, "72", 66, "Тамбовская Область" },
                    { 1380, "80", 66, "Удмуртская Республика" },
                    { 1349, "PVN", 13, "Плевен / Pleven" },
                    { 1348, "PER", 13, "Перник / Pernik" },
                    { 1347, "90", 66, "Пермский Край" },
                    { 1324, "91", 66, "Красноярский Край" },
                    { 1323, "38", 66, "Краснодарский Край" },
                    { 1322, "37", 66, "Костромская Область" },
                    { 1321, "34", 66, "Коми Республика" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1320, "33", 66, "Кировская Область" },
                    { 1319, "29", 66, "Кемеровская Область" },
                    { 1318, "28", 66, "Карелия Республика" },
                    { 1317, "27", 66, "Карачаево-Черкесская Республика" },
                    { 1325, "40", 66, "Курганская Область" },
                    { 1316, "92", 66, "Камчатская Область" },
                    { 1314, "24", 66, "Калмыкия Республика" },
                    { 1313, "23", 66, "Калининградская Область" },
                    { 1312, "22", 66, "Кабардино-Балкарская Республика" },
                    { 1311, "20", 66, "Иркутская Область" },
                    { 1310, "19", 66, "Ингушетия Республика" },
                    { 1309, "21", 66, "Ивановская Область" },
                    { 1308, "DOB", 13, "Добрич / Dobrich" },
                    { 1307, "17", 66, "Дагестан Республика" },
                    { 1315, "25", 66, "Калужская Область" },
                    { 1305, "VRC", 13, "Враца / Vraca" },
                    { 1326, "41", 66, "Курская Область" },
                    { 1328, "KNL", 13, "Кюстендил / Kjustendil" },
                    { 1346, "57", 66, "Пензенская Область" },
                    { 1345, "PAZ", 13, "Пазарджик / Pazardzhik" },
                    { 1344, "56", 66, "Орловская Область" },
                    { 1343, "55", 66, "Оренбургская Область" },
                    { 1342, "54", 66, "Омская Область" },
                    { 1341, "53", 66, "Новосибирская Область" },
                    { 1340, "52", 66, "Новгородская Область" },
                    { 1339, "51", 66, "Нижегородская Область" },
                    { 1327, "KRZ", 13, "Кърджали / Kurdzhali" },
                    { 1338, "49", 66, "Мурманская Область" },
                    { 1336, "48", 66, "Москва" },
                    { 1335, "46", 66, "Мордовия Республика" },
                    { 1334, "MON", 13, "Монтана / Montana" },
                    { 1333, "45", 66, "Марий Эл Республика" },
                    { 1332, "44", 66, "Магаданская Область" },
                    { 1331, "LOV", 13, "Ловеч / Lovech" },
                    { 1330, "43", 66, "Липецкая Область" },
                    { 1329, "42", 66, "Ленинградская Область" },
                    { 1337, "47", 66, "Московская Область" },
                    { 1044, "36", 37, "Shimane Ken" },
                    { 1218, "VN", 36, "Veneto" },
                    { 1216, "143", 63, "Vega Alta" },
                    { 1106, "84", 77, "Surat Thani" },
                    { 1105, "72", 77, "Suphanburi" },
                    { 1104, "21", 80, "Sumska" },
                    { 1103, "64", 77, "Sukhothai" },
                    { 1102, "27", 15, "Sucre" },
                    { 1101, "34", 65, "Suceava" },
                    { 1100, "80", 61, "Subcarpathian Voivodeship" },
                    { 1099, "D3", 39, "Strenču nov." },
                    { 1098, null, 51, "Straseni" },
                    { 1097, "D2", 39, "Stopiņu nov." },
                    { 1096, "AB", 75, "Stockholm" },
                    { 1095, "06", 7, "Steiermark" },
                    { 1094, null, 51, "Stefan-Voda" },
                    { 1093, "04", 50, "State of Yap" },
                    { 1092, "02", 50, "State of Pohnpei" },
                    { 1091, "01", 50, "State of Kosrae" },
                    { 1090, "03", 50, "State of Chuuk" },
                    { 1107, "21", 74, "Svalbard" },
                    { 1108, "84", 61, "Świętokrzyskie" },
                    { 1109, "86", 8, "Sylhet Division" },
                    { 1110, "SZ", 31, "Szabolcs-Szatmár-Bereg" },
                    { 1128, "40", 33, "Telangana" },
                    { 1127, "59", 78, "Tekirdağ" },
                    { 1126, "12", 2, "Tebessa" },
                    { 1125, "56", 45, "Tas-Sliema" },
                    { 1124, "TAS", 6, "Tasmania" },
                    { 1123, "58", 45, "Tarxien" },
                    { 1122, null, 51, "Taraclia" },
                    { 1121, "25", 33, "Tamil Nadu" },
                    { 1089, null, 17, "Splitsko-Dalmatinska" },
                    { 1120, "TAM", 49, "Tamaulipas" },
                    { 1118, "28", 39, "Talsu nov." },
                    { 1117, "41", 45, "Tal-Pietà" },
                    { 1116, "63", 77, "Tak" },
                    { 1115, "18", 83, "Tacuarembo" },
                    { 1114, "TAB", 49, "Tabasco" },
                    { 1113, "59", 45, "Ta’ Xbiex" },
                    { 1112, "27", 45, "Ta’ Kerċem" },
                    { 1111, null, 17, "Šibensko-Kninska" },
                    { 1119, "11", 2, "Tamanrasset" },
                    { 1088, "02", 22, "Southwest Finland" },
                    { 1087, "10", 22, "Southern Savonia" },
                    { 1086, "10", 11, "Southampton Parish" },
                    { 1063, "58", 78, "Sivas" },
                    { 1062, "33", 77, "Sisaket" },
                    { 1061, null, 17, "Sisačko-Moslavačka" },
                    { 1060, "80", 78, "Şirnak" },
                    { 1059, "57", 78, "Sinop" },
                    { 1058, null, 51, "Singerei" },
                    { 1057, "17", 77, "Singburi" },
                    { 1056, "SIN", 49, "Sinaloa" },
                    { 1064, "M", 75, "Skåne" },
                    { 1055, "83", 61, "Silesia" },
                    { 1053, "74", 78, "Siirt" },
                    { 1052, "C7", 39, "Siguldas nov." },
                    { 1051, "22", 2, "Sidi-Bel-Abbes" },
                    { 1050, "SC", 36, "Sicilia" },
                    { 1049, "33", 65, "Sibiu" },
                    { 1048, "SH", 25, "Schleswig-Holstein" },
                    { 1047, "7011", 40, "Schellenberg" },
                    { 1046, "7005", 40, "Schaan" },
                    { 1054, "29", 33, "Sikkim" },
                    { 1129, "08", 57, "Telemark" },
                    { 1065, "21", 2, "Skikda" },
                    { 1067, "C9", 39, "Skrundas nov." },
                    { 697, "26", 2, "Medea" },
                    { 1084, "09", 22, "South Karelia" },
                    { 1083, "SD", 82, "South Dakota" },
                    { 1082, "SC", 82, "South Carolina" },
                    { 1081, "SA", 6, "South Australia" },
                    { 1080, "41", 2, "Souk-Ahras" },
                    { 1079, null, 58, "Souhern Punajb Mulan" },
                    { 1078, null, 51, "Soroca" },
                    { 1066, "C8", 39, "Skrīveru nov." },
                    { 1077, "17", 83, "Soriano" },
                    { 1075, "90", 77, "Songkhla" },
                    { 1074, "SO", 31, "Somogy" },
                    { 1073, null, 51, "Soldanesti" },
                    { 1072, "14", 57, "Sogn og Fjordane" },
                    { 1071, "D", 75, "Södermanland" },
                    { 1070, "09", 11, "Smith’s Parish" },
                    { 1069, "D1", 39, "Smiltenes nov." },
                    { 1068, null, 51, "Slobozia Tr." },
                    { 1076, "SON", 49, "Sonora" },
                    { 1217, "145", 63, "Vega Baja" },
                    { 1130, null, 51, "Telenesti" },
                    { 1132, "TN", 82, "Tennessee" },
                    { 1193, "39", 33, "Uttarakhand" },
                    { 1192, "53", 77, "Uttaradit" },
                    { 1191, "36", 33, "Uttar Pradesh" },
                    { 1190, "09", 53, "Utrecht" },
                    { 1189, "61", 77, "Uthai Thani" },
                    { 1188, "UT", 82, "Utah" },
                    { 1187, "64", 78, "Uşak" },
                    { 1186, "C", 75, "Uppsala" },
                    { 1185, null, 51, "Ungheni" },
                    { 1184, "UM", 36, "Umbria" },
                    { 1183, null, 51, "Uhnheni" },
                    { 1182, "41", 77, "Udon Thani" },
                    { 1181, "34", 77, "Ubon Ratchathani" },
                    { 1180, "62", 78, "Tunceli" },
                    { 1179, "37", 65, "Tulcea" },
                    { 1178, "29", 39, "Tukuma nov." },
                    { 1177, "T", 5, "Tucuman" },
                    { 1194, "141", 63, "Utuado" },
                    { 1195, "01", 22, "Uusimaa" },
                    { 1196, "7001", 40, "Vaduz" },
                    { 1197, "D7", 39, "Vaiņodes nov." },
                    { 1215, "E4", 39, "Vecumnieku nov." },
                    { 1214, "E3", 39, "Vecpiebalgas nov." },
                    { 1213, "O", 75, "Västra Götaland" },
                    { 1212, "U", 75, "Västmanland" },
                    { 1211, "Y", 75, "Västernorrland" },
                    { 1210, "AC", 75, "Västerbotten" },
                    { 1209, "S", 75, "Värmland" },
                    { 1208, "30", 15, "Vaupes" },
                    { 1176, "97617", 48, "Tsingoni" },
                    { 1207, "38", 65, "Vaslui" },
                    { 1205, "E2", 39, "Vārkavas nov." },
                    { 1204, null, 17, "Varaždinska" },
                    { 1203, "E1", 39, "Varakļānu nov." },
                    { 1202, "65", 78, "Van" },
                    { 1201, "29", 15, "Valle Del Cauca" },
                    { 1200, "VD", 36, "Valle D'Aosta" },
                    { 1199, "30", 39, "Valkas nov." },
                    { 1198, "39", 65, "Vâlcea" },
                    { 1206, "VA", 31, "Vas" },
                    { 1175, "139", 63, "Trujillo Alto" },
                    { 1174, "50", 57, "Trøndelag" },
                    { 1173, "19", 57, "Troms" },
                    { 1150, "13", 2, "Tlemcen" },
                    { 1149, "TLA", 49, "Tlaxcala" },
                    { 1148, "15", 2, "Tizi-Ouzou" },
                    { 1147, "38", 2, "Tissemsilt" },
                    { 1146, "07", 7, "Tirol" },
                    { 1145, null, 51, "Tiraspol Tr." },
                    { 1144, "42", 2, "Tipaza" },
                    { 1143, "120", 56, "Tinian" },
                    { 1151, "135", 63, "Toa Alta" },
                    { 1142, "37", 2, "Tindouf" },
                    { 1140, "V", 5, "Tierra Del Fuego" },
                    { 1139, "TI", 76, "Ticino" },
                    { 1138, "14", 2, "Tiaret" },
                    { 1137, "TH", 25, "Thüringen" },
                    { 1136, "TX", 82, "Texas" },
                    { 1135, "D5", 39, "Tērvetes nov." },
                    { 1134, "22", 80, "Ternopilska" },
                    { 1133, "TRG", 44, "Terengganu" },
                    { 1141, "36", 65, "Timiş" },
                    { 1131, "35", 65, "Teleorman" },
                    { 1152, "137", 63, "Toa Baja" },
                    { 1154, "38", 37, "Tochigi Ken" },
                    { 1172, "TA", 69, "Trnavský kraj" },
                    { 1171, "26", 33, "Tripura" },
                    { 1170, "7004", 40, "Triesenberg" },
                    { 1169, "7002", 40, "Triesen" },
                    { 1168, "TT", 36, "Trentino-Alto Adige" },
                    { 1167, "TC", 69, "Trenčiansky kraj" },
                    { 1166, "19", 83, "Treinta y Tres" },
                    { 1165, "23", 77, "Trat" },
                    { 1153, "31", 12, "Tocantins" },
                    { 1164, "92", 77, "Trang" },
                    { 1162, "42", 37, "Toyama Ken" },
                    { 1161, "41", 37, "Tottori Ken" },
                    { 1160, "TC", 36, "Toscana" },
                    { 1159, "TO", 31, "Tolna" },
                    { 1158, "28", 15, "Tolima" },
                    { 1157, "40", 37, "Tokyo To" },
                    { 1156, "39", 37, "Tokushima Ken" },
                    { 1155, "60", 78, "Tokat" },
                    { 1163, "61", 78, "Trabzon" },
                    { 696, "MV", 25, "Mecklenburg-Vorpommern" },
                    { 653, "14", 80, "Luhanska" },
                    { 694, "78", 61, "Mazovia" },
                    { 235, "CO", 82, "Colorado" },
                    { 234, "04", 83, "Colonia" },
                    { 233, "COL", 49, "Colima" },
                    { 232, "07", 62, "Coimbra" },
                    { 231, "043", 63, "Coamo" },
                    { 230, "COA", 49, "Coahuila de Zaragoza" },
                    { 229, "13", 65, "Cluj" },
                    { 228, "CL", 42, "Clervaux" },
                    { 227, "DIF", 49, "Ciudad de México" },
                    { 226, "07", 29, "Ciudad de Guatemala" },
                    { 225, "98613", 85, "Circonscription d'Uvéa" },
                    { 224, "98612", 85, "Circonscription de Sigave" },
                    { 223, "98611", 85, "Circonscription d'Alo" },
                    { 222, null, 51, "Cimislia" },
                    { 221, "041", 63, "Cidra" },
                    { 220, "56", 39, "Ciblas nov." },
                    { 219, "039", 63, "Ciales" },
                    { 236, "045", 63, "Comerio" },
                    { 237, null, 51, "Comrat" },
                    { 238, "VC", 72, "Comunidad Valenciana" },
                    { 239, "CT", 82, "Connecticut" },
                    { 257, "57", 39, "Dagdas nov." },
                    { 256, "06", 33, "Dadra & Nagar Haveli" },
                    { 255, "33", 15, "Cundinamarca" },
                    { 254, "049", 63, "Culebra" },
                    { 253, "CS", 31, "Csongrád" },
                    { 252, null, 51, "Criulenii-Dub." },
                    { 251, null, 51, "Criuleni-Dub." },
                    { 250, null, 51, "Criuleni- Dub." },
                    { 218, "CE", 72, "Ceuta" },
                    { 249, null, 51, "Criuleni" },
                    { 247, "19", 78, "Çorum" },
                    { 246, "94", 23, "Corse" },
                    { 245, "W", 5, "Corrientes" },
                    { 244, "047", 63, "Corozal" },
                    { 243, "12", 15, "Cordoba" },
                    { 242, "X", 5, "Cordoba" },
                    { 241, "25", 2, "Constantine" },
                    { 240, "14", 65, "Constanţa" },
                    { 248, "15", 65, "Covasna" },
                    { 217, "55", 39, "Cesvaines nov." },
                    { 216, "05", 39, "Cēsu nov." },
                    { 215, "10", 15, "Cesar" },
                    { 192, null, 51, "Cantrmir" },
                    { 191, "VS", 76, "Canton du Valais" },
                    { 190, "ES", 42, "Canton d'Esch-sur-Alzette" },
                    { 189, "EC", 42, "Canton d'Echternach" },
                    { 188, "VD", 76, "Canton de Vaud" },
                    { 187, "FR", 76, "Canton de Fribourg" },
                    { 186, "BE", 76, "Canton de Berne" },
                    { 185, null, 51, "Cantemir" },
                    { 193, null, 51, "Canul" },
                    { 184, "CB", 72, "Cantabria" },
                    { 182, "82", 78, "Çankiri" },
                    { 181, "02", 83, "Canelones" },
                    { 180, "CN", 72, "Canarias" },
                    { 179, "17", 78, "Çanakkale" },
                    { 178, "027", 63, "Camuy" },
                    { 177, "CAM", 49, "Campeche" },
                    { 176, "CM", 36, "Campania" },
                    { 175, null, 51, "Camenca Tr." },
                    { 183, "029", 63, "Canovanas" },
                    { 258, "W", 75, "Dalarna" },
                    { 194, "CA", 42, "Capellen" },
                    { 196, "12", 65, "Caraş-Severin" },
                    { 214, "03", 83, "Cerro Largo" },
                    { 213, "24", 23, "Centre" },
                    { 212, "16", 22, "Central Ostrobothnia Region" },
                    { 211, "13", 22, "Central Finland Region" },
                    { 210, "037", 63, "Ceiba" },
                    { 209, "06", 12, "Ceara" },
                    { 208, "035", 63, "Cayey" },
                    { 207, null, 51, "Causeni" },
                    { 195, "08", 15, "Caqueta" },
                    { 206, "09", 15, "Cauca" },
                    { 204, "K", 5, "Catamarca" },
                    { 203, "CT", 72, "Cataluna" },
                    { 202, "CL", 72, "Castilla - Leon" },
                    { 201, "CM", 72, "Castilla - La Mancha" },
                    { 200, "06", 62, "Castelo Branco" },
                    { 199, "32", 15, "Casanare" },
                    { 198, "031", 63, "Carolina" },
                    { 197, "53", 39, "Carnikavas nov." },
                    { 205, "033", 63, "Catano" },
                    { 174, "CA", 82, "California" },
                    { 259, "32", 33, "Daman & Diu" },
                    { 261, "07", 39, "Daugavpils nov." },
                    { 322, "62", 39, "Engures nov." },
                    { 321, "ENG", 81, "England" },
                    { 320, "ER", 36, "Emilia-Romagna" },
                    { 319, "36", 2, "El-Taref" },
                    { 318, "39", 2, "El-Oued" },
                    { 317, "32", 2, "El-Bayadh" },
                    { 316, "23", 78, "Elaziğ" },
                    { 315, "05", 37, "Ehime Ken" },
                    { 314, "22", 78, "Edirne" },
                    { 313, null, 51, "Edinet" },
                    { 312, "97608", 48, "Dzaoudzi" },
                    { 311, "93", 78, "Düzce" },
                    { 310, "61", 39, "Durbes nov." },
                    { 309, "05", 83, "Durazno" },
                    { 308, "DUR", 49, "Durango" },
                    { 307, "60", 39, "Dundagas nov." },
                    { 306, null, 17, "Dubrovačko-Neretvanska" },
                    { 323, "E", 5, "Entre Rios" },
                    { 324, "63", 39, "Ērgļu nov." },
                    { 325, "24", 78, "Erzincan" },
                    { 326, "25", 78, "Erzurum" },
                    { 344, "P", 5, "Formosa" },
                    { 343, "07", 83, "Florida" },
                    { 342, "FL", 82, "Florida" },
                    { 341, "054", 63, "Florida" },
                    { 340, null, 51, "Floresti" },
                    { 339, "06", 83, "Flores" },
                    { 338, "16", 53, "Flevoland" },
                    { 337, "20", 57, "Finnmark" },
                    { 305, null, 51, "Dubasari Tr." },
                    { 336, "FE", 31, "Fejér" },
                    { 334, "09", 62, "Faro" },
                    { 333, null, 51, "Falesti" },
                    { 332, "053", 63, "Fajardo" },
                    { 331, "EX", 72, "Extremadura" },
                    { 330, "08", 62, "Évora" },
                    { 329, "08", 12, "Espirito Santo" },
                    { 328, "26", 78, "Eskişehir" },
                    { 327, "7007", 40, "Eschen" },
                    { 335, null, 58, "Federal Capial &AJK" },
                    { 304, null, 51, "Dubasari Cr." },
                    { 303, null, 51, "Drochia" },
                    { 302, "01", 53, "Drenthe" },
                    { 279, "15", 29, "DEPTO DE RETALHULEU" },
                    { 278, "13", 29, "DEPTO DE QUETZALTENANGO" },
                    { 277, "12", 29, "DEPTO DE PETEN" },
                    { 276, "11", 29, "DEPTO DE JUTIAPA" },
                    { 275, "10", 29, "DEPTO DE JALAPA" },
                    { 274, "09", 29, "DEPTO DE IZABAL" },
                    { 273, "04", 29, "DEPTO DE CHIQUIMULA" },
                    { 272, "03", 29, "DEPTO DE CHIMALTENANGO" },
                    { 280, "16", 29, "DEPTO DE SACATEPEQUEZ" },
                    { 271, "08", 29, "DEPTO DE HUEHUETENANGO" },
                    { 269, "06", 29, "DEPTO DE ESCUINTLA" },
                    { 268, "07", 29, "DEPTO DE EL PROGRESO" },
                    { 267, "02", 29, "DEPTO DE BAJA VERAPAZ" },
                    { 266, "01", 29, "DEPTO DE ALTA VERAPAZ" },
                    { 265, "20", 78, "Denizli" },
                    { 264, "97607", 48, "Dembeni" },
                    { 263, "07", 33, "Delhi" },
                    { 262, "DE", 82, "Delaware" },
                    { 270, "07", 29, "DEPTO DE GUATEMALA" },
                    { 260, "16", 65, "Dâmboviţa" },
                    { 281, "17", 29, "DEPTO DE SAN MARCOS" },
                    { 283, "19", 29, "DEPTO DE SOLOLA" },
                    { 301, "051", 63, "Dorado" },
                    { 300, "05", 80, "Donetska" },
                    { 299, null, 51, "Donduseni" },
                    { 298, "17", 65, "Dolj" },
                    { 297, "08", 39, "Dobeles nov." },
                    { 296, "04", 80, "Dnipropetrovska" },
                    { 295, "17", 2, "Djelfa" },
                    { 294, "21", 78, "Diyarbakir" },
                    { 282, "18", 29, "DEPTO DE SANTA ROSA" },
                    { 293, "07", 12, "Distrito Federal" },
                    { 291, "07", 45, "Dingli" },
                    { 290, "DI", 42, "Diekirch" },
                    { 289, "81", 8, "Dhaka Division" },
                    { 288, "01", 11, "Devonshire Parish" },
                    { 287, "14", 29, "DEPTO DEL QUICHE" },
                    { 286, "22", 29, "DEPTO DE ZACAPA" },
                    { 285, "21", 29, "DEPTO DE TOTONICAPAN" },
                    { 284, "20", 29, "DEPTO DE SUCHITEPEQUEZ" },
                    { 292, "DC", 82, "District of Columbia" },
                    { 345, "02", 53, "Friesland" },
                    { 173, "37", 15, "Caldas" },
                    { 171, null, 51, "Calarasi" },
                    { 61, "25", 15, "Archipielago De San Andres" },
                    { 60, "03", 65, "Argeş" },
                    { 59, "013", 63, "Arecibo" },
                    { 58, "86", 78, "Ardahan" },
                    { 57, "03", 15, "Arauca" },
                    { 56, "AR", 72, "Aragon" },
                    { 55, "02", 65, "Arad" },
                    { 54, "43", 39, "Apes nov." },
                    { 53, "03", 37, "Aomori Ken" },
                    { 52, "02", 15, "Antioquia" },
                    { 51, "07", 78, "Antalya" },
                    { 50, "23", 2, "Annaba" },
                    { 49, "68", 78, "Ankara" },
                    { 48, "15", 77, "Ang Thong" },
                    { 47, null, 51, "Anenii Noi" },
                    { 46, "02", 33, "Andhra Pradesh" },
                    { 45, "01", 33, "Andaman & Nicobar Islands" },
                    { 62, "AZ", 82, "Arizona" },
                    { 63, "AR", 82, "Arkansas" },
                    { 64, "015", 63, "Arroyo" },
                    { 65, "01", 83, "Artigas" },
                    { 83, "BW", 25, "Baden-Württemberg" },
                    { 82, "BK", 31, "Bács-Kiskun" },
                    { 81, "04", 65, "Bacău" },
                    { 80, "45", 39, "Babītes nov." },
                    { 79, "23", 62, "Azores" },
                    { 78, "09", 78, "Aydin" },
                    { 77, "02", 62, "Aveiro" },
                    { 76, "84", 23, "Auvergne-Rhône-Alpes" },
                    { 44, "AN", 72, "Andalucia" },
                    { 75, "ACT", 6, "Australian Capital Territory" },
                    { 73, "44", 39, "Auces nov." },
                    { 72, "01", 45, "Attard" },
                    { 71, "04", 15, "Atlantico" },
                    { 70, "AS", 72, "Asturias" },
                    { 69, "03", 33, "Assam" },
                    { 68, "60", 3, "As" },
                    { 67, "30", 33, "Arunachal Pradesh" },
                    { 66, "08", 78, "Artvin" },
                    { 74, "09", 57, "Aust-Agder" },
                    { 43, "011", 63, "Anasco" },
                    { 42, "37", 77, "Amnat Charoen" },
                    { 41, "01", 15, "Amazonas" },
                    { 18, "44", 2, "Ain-Defla" },
                    { 17, "01", 37, "Aichi Ken" },
                    { 16, "009", 63, "Aibonito" },
                    { 15, "AGU", 49, "Aguascalientes" },
                    { 14, "007", 63, "Aguas Buenas" },
                    { 13, "005", 63, "Aguadilla" },
                    { 12, "003", 63, "Aguada" },
                    { 11, "04", 78, "Ağri" },
                    { 19, "46", 2, "Ain-Temouchent" },
                    { 10, "35", 39, "Aglonas nov." },
                    { 8, "01", 2, "Adrar" },
                    { 7, "001", 63, "Adjuntas" },
                    { 6, "02", 78, "Adiyaman" },
                    { 5, "34", 39, "Ādažu nov." },
                    { 4, "81", 78, "Adana" },
                    { 3, "01", 12, "Acre" },
                    { 2, "97601", 48, "Acoua" },
                    { 1, "AB", 36, "Abruzzi" },
                    { 9, "03", 78, "Afyonkarahisar" },
                    { 84, "05", 12, "Bahia" },
                    { 20, "01", 39, "Aizkraukles nov." },
                    { 22, "02", 57, "Akershus" },
                    { 40, "04", 12, "Amazonas" },
                    { 39, "42", 39, "Amatas nov." },
                    { 38, "05", 78, "Amasya" },
                    { 37, "03", 12, "Amapa" },
                    { 36, "02", 39, "Alūksnes nov." },
                    { 35, "40", 39, "Alsungas nov." },
                    { 34, "39", 39, "Alojas nov." },
                    { 33, "16", 2, "Alger" },
                    { 21, "37", 39, "Aizputes nov." },
                    { 32, "AB", 14, "Alberta" },
                    { 30, "AK", 82, "Alaska" },
                    { 29, "213", 1, "Ålands skärgård" },
                    { 28, "212", 1, "Ålands landsbygd" },
                    { 27, "02", 12, "Alagoas" },
                    { 26, "AL", 82, "Alabama" },
                    { 25, "75", 78, "Aksaray" },
                    { 24, "38", 39, "Aknīstes nov." },
                    { 23, "02", 37, "Akita Ken" },
                    { 31, "01", 65, "Alba" },
                    { 172, "41", 65, "Călăraşi" },
                    { 85, "BCN", 49, "Baja California" },
                    { 87, "46", 39, "Baldones nov." },
                    { 148, "BL", 69, "Bratislavský kraj" },
                    { 147, "09", 65, "Braşov" },
                    { 146, "BB", 25, "Brandenburg" },
                    { 145, "08", 65, "Brăila" },
                    { 144, "05", 62, "Bragança" },
                    { 143, "04", 62, "Braga" },
                    { 142, "36", 15, "Boyaca" },
                    { 141, "27", 23, "Bourgogne-Franche-Comté" },
                    { 140, "35", 2, "Boumerdes" },
                    { 139, "10", 2, "Bouira" },
                    { 138, "97604", 48, "Bouéni" },
                    { 137, "07", 65, "Botoşani" },
                    { 136, "BZ", 31, "Borsod-Abaúj-Zemplén" },
                    { 135, "06", 45, "Bormla" },
                    { 134, "34", 2, "Bordj-Bou-Arreridj" },
                    { 133, "14", 78, "Bolu" },
                    { 132, "35", 15, "Bolivar" },
                    { 149, "HB", 25, "Bremen" },
                    { 150, null, 9, "Brest" },
                    { 151, "53", 23, "Bretagne" },
                    { 152, null, 51, "Briceni" },
                    { 170, "CI", 36, "Calabria" },
                    { 169, null, 51, "Cahul" },
                    { 168, "025", 63, "Caguas" },
                    { 167, "023", 63, "Cabo Rojo" },
                    { 166, "11", 65, "Buzău" },
                    { 165, "06", 57, "Buskerud" },
                    { 164, "52", 39, "Burtnieku nov." },
                    { 163, "16", 78, "Bursa" },
                    { 131, "34", 15, "Bogota, D.C." },
                    { 162, "31", 77, "Burirum" },
                    { 160, "15", 78, "Burdur" },
                    { 159, "B", 5, "Buenos Aires" },
                    { 158, "BU", 31, "Budapest" },
                    { 157, "10", 65, "Bucureşti" },
                    { 156, "BRU", 10, "Bruxelles-Capitale" },
                    { 155, null, 17, "Brodsko-Posavska" },
                    { 154, "51", 39, "Brocēnu nov." },
                    { 153, "BC", 14, "British Columbia" },
                    { 161, "01", 7, "Burgenland" },
                    { 130, "09", 2, "Blida" },
                    { 129, "K", 75, "Blekinge" },
                    { 128, null, 17, "Bjelovarsko-Bilogorska" },
                    { 105, "BC", 36, "Basilicata" },
                    { 104, "87", 78, "Bartin" },
                    { 103, "019", 63, "Barranquitas" },
                    { 102, "85", 8, "Barisal Division" },
                    { 101, "017", 63, "Barceloneta" },
                    { 100, "BA", 31, "Baranya" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { 99, "BC", 69, "Banskobystrický kraj" },
                    { 98, "10", 77, "Bangkok" },
                    { 106, "76", 78, "Batman" },
                    { 97, "97603", 48, "Bandrele" },
                    { 95, "7003", 40, "Balzers" },
                    { 94, "02", 45, "Balzan" },
                    { 93, "03", 39, "Balvu nov." },
                    { 92, "47", 39, "Baltinavas nov." },
                    { 91, null, 51, "Balti" },
                    { 90, null, 58, "Balochisan" },
                    { 89, "10", 78, "Balikesir" },
                    { 88, "IB", 72, "Baleares" },
                    { 96, "97602", 48, "Bandraboua" },
                    { 86, "BCS", 49, "Baja California Sur" },
                    { 107, "05", 2, "Batna" },
                    { 109, "021", 63, "Bayamon" },
                    { 127, "13", 78, "Bitlis" },
                    { 126, "06", 65, "Bistriţa-Năsăud" },
                    { 125, "07", 2, "Biskra" },
                    { 124, "05", 45, "Birżebbuġa" },
                    { 123, "04", 45, "Birkirkara" },
                    { 122, "12", 78, "Bingöl" },
                    { 121, "11", 78, "Bilecik" },
                    { 120, "05", 65, "Bihor" },
                    { 108, "04", 39, "Bauskas nov." },
                    { 119, "34", 33, "Bihar" },
                    { 117, "BE", 25, "Berlin" },
                    { 116, null, 51, "Bender Tr." },
                    { 115, "BE", 31, "Békés" },
                    { 114, "06", 2, "Bejaia" },
                    { 113, "03", 62, "Beja" },
                    { 112, "08", 2, "Bechar" },
                    { 111, "BY", 25, "Bayern" },
                    { 110, "77", 78, "Bayburt" },
                    { 118, "50", 39, "Beverīnas nov." },
                    { 346, "FV", 36, "Friuli-Venezia Giulia" },
                    { 347, "06", 37, "Fukui Ken" },
                    { 348, "07", 37, "Fukuoka Ken" },
                    { 584, "71", 78, "Konya" },
                    { 583, "KE", 31, "Komárom-Esztergom" },
                    { 582, "82", 39, "Kokneses nov." },
                    { 581, "20", 37, "Kochi Ken" },
                    { 580, "81", 39, "Kocēnu nov." },
                    { 579, "41", 78, "Kocaeli" },
                    { 578, null, 78, "Kktc" },
                    { 577, "40", 78, "Kirşehir" },
                    { 576, "10", 80, "Kirovohradska" },
                    { 575, "28", 45, "Kirkop" },
                    { 574, "39", 78, "Kirklareli" },
                    { 573, "79", 78, "Kirikkale" },
                    { 572, "90", 78, "Kilis" },
                    { 571, "82", 8, "Khulna Division" },
                    { 570, "40", 77, "Khon Kaen" },
                    { 569, "09", 80, "Khmelnytska" },
                    { 568, "08", 80, "Khersonska" },
                    { 585, null, 17, "Koprivničko-Križevačka" },
                    { 586, "KI", 69, "Košický kraj" },
                    { 587, "97610", 48, "Koungou" },
                    { 588, "81", 77, "Krabi" },
                    { 606, "F", 5, "La Rioja" },
                    { 605, "L", 5, "La Pampa" },
                    { 604, "17", 15, "La Guajira" },
                    { 603, "03", 2, "L.Aghouat" },
                    { 602, "22", 37, "Kyoto Fu" },
                    { 601, "08", 22, "Kymenlaakso" },
                    { 600, "12", 80, "Kyivska" },
                    { 599, "13", 80, "Kyiv" },
                    { 567, "40", 2, "Khenchela" },
                    { 598, "43", 78, "Kütahya" },
                    { 596, "15", 39, "Kuldīgas nov." },
                    { 595, "73", 61, "Kujawsko-Pomorskie" },
                    { 594, "KUL", 44, "Kuala Lumpur" },
                    { 593, "85", 39, "Krustpils nov." },
                    { 592, "G", 75, "Kronoberg" },
                    { 591, "84", 39, "Krimuldas nov." },
                    { 590, "14", 39, "Krāslavas nov." },
                    { 589, null, 17, "Krapinsko-Zagorska" },
                    { 597, "21", 37, "Kumamoto Ken" },
                    { 566, "07", 80, "Kharkivska" },
                    { 565, "71", 77, "Khanchanaburi" },
                    { 564, "13", 33, "Kerala" },
                    { 541, "OW", 76, "Kanton Obwalden" },
                    { 540, "NW", 76, "Kanton Nidwalden" },
                    { 539, "LU", 76, "Kanton Luzern" },
                    { 538, "GR", 76, "Kanton Graubünden" },
                    { 537, "GL", 76, "Kanton Glarus" },
                    { 536, "BS", 76, "Kanton Basel-Stadt" },
                    { 535, "BL", 76, "Kanton Basel-Landschaft" },
                    { 534, "AI", 76, "Kanton Appenzell Innerrhoden" },
                    { 542, "SH", 76, "Kanton Schaffhausen" },
                    { 533, "AR", 76, "Kanton Appenzell Ausserrhoden" },
                    { 531, "05", 22, "Kanta-Häme" },
                    { 530, "KS", 82, "Kansas" },
                    { 529, "97609", 48, "Kani-Kéli" },
                    { 528, "77", 39, "Kandavas nov." },
                    { 527, "19", 37, "Kanagawa Ken" },
                    { 526, "62", 77, "Kamphaeng Phet" },
                    { 525, "H", 75, "Kalmar" },
                    { 524, "46", 77, "Kalasin" },
                    { 532, "AG", 76, "Kanton Aargau" },
                    { 607, "RI", 72, "La Rioja" },
                    { 543, "SZ", 76, "Kanton Schwyz" },
                    { 545, "SG", 76, "Kanton St. Gallen" },
                    { 563, "KY", 82, "Kentucky" },
                    { 562, "KTN", 44, "Kelantan" },
                    { 561, "80", 39, "Ķekavas nov." },
                    { 560, "79", 39, "Ķeguma nov." },
                    { 559, "KDH", 44, "Kedah" },
                    { 558, "02", 7, "Kärnten" },
                    { 557, "38", 78, "Kayseri" },
                    { 556, "37", 78, "Kastamonu" },
                    { 544, "SO", 76, "Kanton Solothurn" },
                    { 555, "78", 39, "Kārsavas nov." },
                    { 553, "19", 33, "Karnataka" },
                    { 552, null, 17, "Karlovačka" },
                    { 551, "78", 78, "Karaman" },
                    { 550, "89", 78, "Karabük" },
                    { 549, "ZH", 76, "Kanton Zürich" },
                    { 548, "ZG", 76, "Kanton Zug" },
                    { 547, "UR", 76, "Kanton Uri" },
                    { 546, "TG", 76, "Kanton Thurgau" },
                    { 554, "84", 78, "Kars" },
                    { 523, "18", 22, "Kainuu" },
                    { 608, "LBN", 44, "Labuan" },
                    { 610, "079", 63, "Lajas" },
                    { 671, "091", 63, "Manati" },
                    { 670, "97611", 48, "Mamoudzou" },
                    { 669, "94", 39, "Mālpils nov." },
                    { 668, "09", 83, "Maldonado" },
                    { 667, "44", 78, "Malatya" },
                    { 666, "ME", 82, "Maine" },
                    { 665, "16", 33, "Maharashtra" },
                    { 664, "44", 77, "Maha Sarakham" },
                    { 663, "38", 15, "Magdalena" },
                    { 662, "58", 77, "Mae Hong Son" },
                    { 661, "MD", 72, "Madrid" },
                    { 660, "20", 39, "Madonas nov." },
                    { 659, "35", 33, "Madhya Pradesh" },
                    { 658, "10", 62, "Madeira" },
                    { 657, "15", 80, "Lvivska" },
                    { 656, "LU", 42, "Luxembourg" },
                    { 655, "089", 63, "Luquillo" },
                    { 672, "17", 33, "Manipur" },
                    { 673, "45", 78, "Manisa" },
                    { 674, "MB", 14, "Manitoba" },
                    { 675, "25", 65, "Maramureş" },
                    { 693, "00", 48, "Mayotte (general)" },
                    { 692, "097", 63, "Mayaguez" },
                    { 691, "7008", 40, "Mauren" },
                    { 690, "095", 63, "Maunabo" },
                    { 689, "11", 12, "Mato Grosso do Sul" },
                    { 688, "14", 12, "Mato Grosso" },
                    { 687, "MA", 82, "Massachusetts" },
                    { 686, "29", 2, "Mascara" },
                    { 654, "30", 45, "Luqa" },
                    { 685, "MD", 82, "Maryland" },
                    { 683, "MQ", 47, "Martinique" },
                    { 682, "33", 45, "Marsaxlokk" },
                    { 681, "32", 45, "Marsaskala" },
                    { 680, "211", 1, "Mariehamns stad" },
                    { 679, "093", 63, "Maricao" },
                    { 678, "MH", 36, "Marche" },
                    { 677, "72", 78, "Mardin" },
                    { 676, "13", 12, "Maranhao" },
                    { 684, "95", 39, "Mārupes nov." },
                    { 1390, "JAM", 13, "Ямбол / Jambol" },
                    { 652, "19", 39, "Ludzas nov." },
                    { 651, "76", 61, "Lubusz" },
                    { 628, "88", 39, "Līgatnes nov." },
                    { 627, "87", 39, "Lielvārdes nov." },
                    { 626, null, 17, "Ličko-Senjska" },
                    { 625, "14", 45, "L-Għasri" },
                    { 624, "12", 45, "L-Għarb" },
                    { 623, "77", 61, "Lesser Poland Voivodeship" },
                    { 622, null, 51, "Leova" },
                    { 621, "13", 62, "Leiria" },
                    { 629, "LG", 36, "Liguria" },
                    { 620, null, 51, "Lazo" },
                    { 618, "08", 83, "Lavalleja" },
                    { 617, "085", 63, "Las Piedras" },
                    { 616, "083", 63, "Las Marias" },
                    { 615, "081", 63, "Lares" },
                    { 614, "19", 22, "Lapland" },
                    { 613, "51", 77, "Lamphun" },
                    { 612, "52", 77, "Lampang" },
                    { 611, "14", 33, "Lakshadweep" },
                    { 619, "LZ", 36, "Lazio" },
                    { 609, null, 58, "Lahore" },
                    { 630, "29", 45, "Lija" },
                    { 632, "18", 39, "Limbažu nov." },
                    { 650, "75", 61, "Lublin" },
                    { 649, "91", 39, "Lubānas nov." },
                    { 648, "72", 61, "Lower Silesia" },
                    { 647, "LA", 82, "Louisiana" },
                    { 646, "16", 77, "Lopburi" },
                    { 645, "LM", 36, "Lombardia" },
                    { 644, "087", 63, "Loiza" },
                    { 643, "42", 77, "Loei" },
                    { 631, "19", 45, "L-Iklin" },
                    { 642, "74", 61, "Łódź Voivodeship" },
                    { 640, "25", 45, "L-Isla" },
                    { 639, "14", 62, "Lisboa" },
                    { 638, "24", 45, "L-Imtarfa" },
                    { 637, "23", 45, "L-Imsida" },
                    { 636, "22", 45, "L-Imqabba" },
                    { 635, "21", 45, "L-Imġarr" },
                    { 634, "20", 45, "L-Imdina" },
                    { 633, "05", 53, "Limburg" },
                    { 641, "90", 39, "Līvānu nov." },
                    { 522, "46", 78, "Kahramanmaraş" },
                    { 521, "18", 37, "Kagoshima Ken" },
                    { 520, "17", 37, "Kagawa Ken" },
                    { 409, "HI", 82, "Hawaii" },
                    { 408, "32", 23, "Hauts-de-France" },
                    { 407, "065", 63, "Hatillo" },
                    { 406, "31", 78, "Hatay" },
                    { 405, "10", 33, "Haryana" },
                    { 404, "20", 65, "Harghita" },
                    { 403, "02", 11, "Hamilton" },
                    { 402, "HH", 25, "Hamburg" },
                    { 401, "N", 75, "Halland" },
                    { 400, "15", 45, "Ħal Għaxaq" },
                    { 399, "13", 45, "Ħal Għargħur" },
                    { 398, "70", 78, "Hakkari" },
                    { 397, "HB", 31, "Hajdú-Bihar" },
                    { 396, "GS", 31, "Győr-Moson-Sopron" },
                    { 395, "GF", 24, "Guyane" },
                    { 394, "063", 63, "Gurabo" },
                    { 393, "69", 78, "Gümüşhane" },
                    { 410, "64", 45, "Ħaż-Żabbar" },
                    { 411, "65", 45, "Ħaż-Żebbuġ" },
                    { 412, "04", 57, "Hedmark" },
                    { 413, "HE", 25, "Hessen" },
                    { 431, "05", 33, "Chandigarh" },
                    { 430, "36", 77, "Chaiyaphum" },
                    { 429, "18", 77, "Chainat" },
                    { 428, "24", 77, "Chachoengsao" },
                    { 427, "H", 5, "Chaco" },
                    { 426, "13", 37, "Hyogo Ken" },
                    { 425, null, 58, "Hyderabad" },
                    { 424, "21", 65, "Hunedoara" },
                    { 392, "10", 37, "Gumma Ken" },
                    { 423, "069", 63, "Humacao" },
                    { 421, "067", 63, "Hormigueros" },
                    { 420, "12", 57, "Hordaland" },
                    { 419, "12", 37, "Hokkaido" },
                    { 418, "11", 37, "Hiroshima Ken" },
                    { 417, null, 51, "Hincesti" },
                    { 416, "11", 33, "Himachal Pradesh" },
                    { 415, "HID", 49, "Hidalgo" },
                    { 414, "HE", 31, "Heves" },
                    { 422, "16", 15, "Huila" },
                    { 391, "09", 39, "Gulbenes nov." },
                    { 390, "09", 33, "Gujarat" },
                    { 389, "GRO", 49, "Guerrero" },
                    { 366, "29", 12, "Goias" },
                    { 365, "33", 33, "Goa" },
                    { 364, null, 51, "Glodeni" },
                    { 363, "42", 65, "Giurgiu" },
                    { 362, "28", 78, "Giresun" },
                    { 361, "09", 37, "Gifu Ken" },
                    { 360, "47", 2, "Ghardaia" },
                    { 359, "11", 45, "Għajnsielem" },
                    { 367, null, 9, "Gomel" },
                    { 358, "GA", 82, "Georgia" },
                    { 356, "03", 53, "Gelderland" },
                    { 355, "X", 75, "Gävleborg" },
                    { 354, "83", 78, "Gaziantep" },
                    { 353, "64", 39, "Garkalnes nov." },
                    { 352, "7009", 40, "Gamprin" },
                    { 351, "GA", 72, "Galicia" },
                    { 350, "18", 65, "Galaţi" },
                    { 349, "08", 37, "Fukushima Ken" },
                    { 357, "GE", 76, "Genève" },
                    { 432, "22", 77, "Chanthaburi" },
                    { 368, "19", 65, "Gorj" },
                    { 370, "44", 23, "Grand-Est" },
                    { 388, "24", 2, "Guelma" },
                    { 387, "061", 63, "Guaynabo" },
                    { 386, "059", 63, "Guayanilla" },
                    { 385, "057", 63, "Guayama" },
                    { 384, "14", 15, "Guaviare" },
                    { 383, "11", 62, "Guarda" },
                    { 382, "055", 63, "Guanica" },
                    { 381, "GUA", 49, "Guanajuato" },
                    { 369, "I", 75, "Gotland" },
                    { 380, "15", 15, "Guainia" },
                    { 378, "66", 28, "Gu" },
                    { 377, null, 9, "Grosno" },
                    { 376, "04", 53, "Groningen" },
                    { 375, null, 9, "Grodno" },
                    { 374, "65", 39, "Grobiņas nov." },
                    { 373, null, 51, "Grigoriopol Tr." },
                    { 372, "GR", 42, "Grevenmacher" },
                    { 371, "86", 61, "Greater Poland" },
                    { 379, "GP", 27, "Guadeloupe" },
                    { 433, "37", 33, "Chattisgarh" },
                    { 434, "01", 80, "Cherkaska" },
                    { 435, "02", 80, "Chernihivska" },
                    { 497, "35", 78, "İzmir" },
                    { 496, "63", 45, "Ix-Xgħajra" },
                    { 495, "62", 45, "Ix-Xewkija" },
                    { 494, "61", 45, "Ix-Xagħra" },
                    { 493, "16", 37, "Iwate Ken" },
                    { 492, "06", 80, "Ivano-Frankivska" },
                    { 491, null, 17, "Istarska" },
                    { 490, "34", 78, "İstanbul" },
                    { 498, "66", 45, "Iż-Żebbuġ" },
                    { 489, "57", 45, "Is-Swieqi" },
                    { 487, "33", 78, "Isparta" },
                    { 486, "15", 37, "Ishikawa Ken" },
                    { 485, "071", 63, "Isabela" },
                    { 484, "45", 45, "Ir-Rabat" },
                    { 483, "IA", 82, "Iowa" },
                    { 482, "38", 45, "In-Naxxar" },
                    { 481, "37", 45, "In-Nadur" },
                    { 480, "IN", 82, "Indiana" },
                    { 488, "55", 45, "Is-Siġġiewi" },
                    { 479, "70", 39, "Inčukalna nov." },
                    { 499, "67", 45, "Iż-Żejtun" },
                    { 501, "JAL", 49, "Jalisco" },
                    { 519, "JU", 76, "Jura" },
                    { 518, "077", 63, "Juncos" },
                    { 517, "Y", 5, "Jujuy" },
                    { 516, "075", 63, "Juana Diaz" },
                    { 515, "F", 75, "Jönköping" },
                    { 514, "JHR", 44, "Johor" },
                    { 513, "18", 2, "Jijel" },
                    { 512, "38", 33, "Jharkhand" },
                    { 500, "68", 45, "Iż-Żurrieq" },
                    { 511, "12", 39, "Jelgavas nov." },
                    { 509, "Z", 75, "Jämtland" },
                    { 508, "073", 63, "Jayuya" },
                    { 507, "73", 39, "Jaunpils nov." },
                    { 506, "72", 39, "Jaunpiebalgas nov." },
                    { 505, "71", 39, "Jaunjelgavas nov." },
                    { 504, "JN", 31, "Jász-Nagykun-Szolnok" },
                    { 503, "22", 74, "Jan Mayen" },
                    { 502, "12", 33, "Jammu & Kashmir" },
                    { 510, "10", 39, "Jēkabpils nov." },
                    { 695, "96", 39, "Mazsalacas nov." },
                    { 478, "69", 39, "Ilūkstes nov." },
                    { 476, "42", 45, "Il-Qala" },
                    { 453, "14", 37, "Ibaraki Ken" },
                    { 452, "23", 65, "Iaşi" },
                    { 451, null, 51, "Ialoveni" },
                    { 450, "22", 65, "Ialomiţa" },
                    { 449, "86", 77, "Chumphon" },
                    { 448, "U", 5, "Chubut" },
                    { 447, "20", 77, "Chonburi" },
                    { 446, "11", 15, "Choco" },
                    { 454, "ID", 82, "Idaho" },
                    { 445, "02", 2, "Chlef" },
                    { 443, "97606", 48, "Chirongui" },
                    { 442, "CHH", 49, "Chihuahua" },
                    { 441, "97605", 48, "Chiconi" },
                    { 440, "04", 37, "Chiba Ken" },
                    { 439, "CHP", 49, "Chiapas" },
                    { 438, "57", 77, "Chiang Rai" },
                    { 437, "50", 77, "Chiang Mai" },
                    { 436, "03", 80, "Chernivetska" },
                    { 444, "84", 8, "Chittagong" },
                    { 477, "44", 45, "Il-Qrendi" },
                    { 455, "67", 39, "Iecavas nov." },
                    { 457, "68", 39, "Ikšķiles nov." },
                    { 475, "36", 45, "Il-Munxar" },
                    { 474, "35", 45, "Il-Mosta" },
                    { 473, "34", 45, "Il-Mellieħa" },
                    { 472, "31", 45, "Il-Marsa" },
                    { 471, "33", 2, "Illizi" },
                    { 470, "IL", 82, "Illinois" },
                    { 469, "26", 45, "Il-Kalkara" },
                    { 468, "18", 45, "Il-Ħamrun" },
                    { 456, "88", 78, "Iğdir" },
                    { 467, "17", 45, "Il-Gżira" },
                    { 465, "09", 45, "Il-Furjana" },
                    { 464, "43", 65, "Ilfov" },
                    { 463, "10", 45, "Il-Fontana" },
                    { 462, "08", 45, "Il-Fgura" },
                    { 461, "03", 54, "Îles Loyauté" },
                    { 460, "11", 23, "Île-de-France" },
                    { 459, "03", 45, "Il-Birgu" },
                    { 458, "60", 45, "Il-Belt Valletta" },
                    { 466, "16", 45, "Il-Gudja" },
                    { 1391, "88", 66, "Ярославская Область" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 12,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 13,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 14,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 15,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 16,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 17,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 18,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 19,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 20,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 21,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 22,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 23,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 24,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 25,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 26,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 27,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 28,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 29,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 30,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 31,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 32,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 33,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 34,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 35,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 36,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 37,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 38,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 39,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 40,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 41,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 42,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 43,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 44,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 45,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 46,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 47,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 48,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 49,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 50,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 51,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 52,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 53,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 54,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 55,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 56,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 57,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 58,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 59,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 60,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 61,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 62,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 63,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 64,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 65,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 66,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 67,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 68,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 69,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 70,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 71,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 72,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 73,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 74,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 75,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 76,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 77,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 78,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 79,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 80,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 81,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 82,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 83,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 84,
                column: "TopLevelDomain",
                value: null);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 85,
                column: "TopLevelDomain",
                value: null);
        }
    }
}
