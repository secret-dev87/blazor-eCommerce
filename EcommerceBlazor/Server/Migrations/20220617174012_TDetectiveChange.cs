using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    public partial class TDetectiveChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://i.pinimg.com/originals/73/61/58/7361583898d2e42805a913c10bfa39fb.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "http://ic.pics.livejournal.com/iskander_zombie/17864134/1500378/1500378_original.jpg");
        }
    }
}
