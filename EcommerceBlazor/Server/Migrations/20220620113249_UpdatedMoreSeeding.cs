using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    public partial class UpdatedMoreSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://ru.gecid.com/data/news/201910050926-57502/img/01_red_dead_redemption_2.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://static.wikia.nocookie.net/reddead/images/0/02/RDR2_cover.png/revision/latest?cb=20180504190605&path-prefix=ru");
        }
    }
}
