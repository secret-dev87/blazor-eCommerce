using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceBlazor.Server.Migrations
{
    public partial class SeedMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 24.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 19.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 23.99m);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 4, 2, "An Inquiry into the Nature and Causes of the Wealth of Nations is the magnum opus of the Scottish economist and moral philosopher Adam Smith. First published in 1776, the book offers one of the world's first collected descriptions of what builds nations' wealth, and is today a fundamental work in classical economics.", "https://images-na.ssl-images-amazon.com/images/I/71yqXZeTuxL.jpg", 14.99m, "The Wealth of Nations" },
                    { 5, 2, "The Lord of the Rings is an epic high-fantasy novel by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.", "https://s26162.pcdn.co/wp-content/uploads/2017/05/the-lord-of-the-rings-book-cover.jpg", 13.99m, "The Lord of the Rings" },
                    { 6, 2, "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.", "https://images-na.ssl-images-amazon.com/images/I/819ijTWp9JL.jpg", 12.99m, "Nineteen Eighty-Four" },
                    { 7, 3, "Batman: Arkham Origins is a 2013 action-adventure game developed by WB Games Montréal and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the follow-up to the 2011 video game Batman: Arkham City and is the third main installment in the Batman: Arkham series. Written by Corey May, Ryan Galletta, and Dooma Wendschuh, the game's main storyline is set eight years before 2009's Batman: Arkham Asylum and follows a younger, less-refined Batman.", "https://i.pinimg.com/originals/bd/62/53/bd6253c0755ac54e3b38e4aaf4724b08.jpg", 19.99m, "Batman: Arkham Origins" },
                    { 8, 3, "Red Dead Redemption 2[a] is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in 1899 and follows the exploits of outlaw Arthur Morgan, a member of the Van der Linde gang, in a fictionalized representation of the Western, Midwestern, and Southern United States. Arthur must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The game's epilogue follows fellow gang member John Marston, the protagonist of Red Dead Redemption.", "https://static.wikia.nocookie.net/reddead/images/0/02/RDR2_cover.png/revision/latest?cb=20180504190605&path-prefix=ru", 39.99m, "Red Dead Redemption 2" },
                    { 9, 3, "The Witcher 3: Wild Hunt is the third and final installment in the series of games developed by CD PROJEKT RED featuring the witcher Geralt of Rivia. Unlike the previous games, The Witcher 3 is set in a multi-region open world, featuring over 100 hours of content.", "https://store-images.s-microsoft.com/image/apps.19883.65858607118306853.bade8222-c0ad-4481-b2d6-b46cc0450658.98c0bbcd-9d06-4bb7-94c8-dd4063e032fc", 14.99m, "The Witcher 3: Wild Hunt" },
                    { 10, 3, "Gaming PC, is a specialized personal computer designed for playing video games at very high standards. Gaming PCs typically differ from mainstream personal computers by using high-performance video cards and high core-count central processing units with raw performance. Gaming PCs are also used for other demanding tasks such as video editing.", "https://upload.wikimedia.org/wikipedia/commons/3/38/Pc_game_logo.png", 1999.99m, "PC" },
                    { 11, 3, "PlayStation is a video game brand that consists of five home video game consoles, two handhelds, a media center, and a smartphone, as well as an online service and multiple magazines. The brand is produced by Sony Interactive Entertainment, a division of Sony; the first PlayStation console was released in Japan in December 1994, and worldwide the following year.", "https://www.fifplay.com/img/public/playstation-5-logo.jpg", 499.99m, "PlayStation" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 11.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 7.99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 10.99m);
        }
    }
}
