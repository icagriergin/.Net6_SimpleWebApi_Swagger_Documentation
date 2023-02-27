using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieApi.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MovieType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovieImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Creator = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Modifier = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedDate", "Creator", "ModifiedDate", "Modifier", "MovieImageUrl", "MovieTitle", "MovieType" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 2, 26, 12, 34, 3, 972, DateTimeKind.Unspecified).AddTicks(6240), new TimeSpan(0, 3, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "src/images/Esaretin_bedeli_img.jpg", "Esaretin Bedeli", "Dram/Aksiyon" },
                    { 2, new DateTimeOffset(new DateTime(2023, 2, 26, 12, 34, 3, 987, DateTimeKind.Unspecified).AddTicks(2840), new TimeSpan(0, 3, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "src/images/Baba_img.jpg", "Baba", "Suç/Dram" },
                    { 3, new DateTimeOffset(new DateTime(2023, 2, 26, 12, 34, 3, 987, DateTimeKind.Unspecified).AddTicks(3120), new TimeSpan(0, 3, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "src/images/Dövüs_klübü_img.jpg", "Dövüş Klübü", "Dram" },
                    { 4, new DateTimeOffset(new DateTime(2023, 2, 26, 12, 34, 3, 987, DateTimeKind.Unspecified).AddTicks(3140), new TimeSpan(0, 3, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "src/images/Yesil_yol_img.jpg", "Yeşil Yol", "Dram" },
                    { 5, new DateTimeOffset(new DateTime(2023, 2, 26, 12, 34, 3, 987, DateTimeKind.Unspecified).AddTicks(3150), new TimeSpan(0, 3, 0, 0, 0)), 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, "src/images/Batman_kara_sovalye_img.jpg", "Batman Kara Şövalye", "Aksiyon/Macera" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
