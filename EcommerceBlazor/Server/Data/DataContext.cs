namespace EcommerceBlazor.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        //Data Seeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "TV Shows",
                    Url = "tv-shows"
                },
                new Category
                {
                    Id = 2,
                    Name = "Books",
                    Url = "books"
                },
                new Category
                {
                    Id = 3,
                    Name = "Video Games",
                    Url = "video-games"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Breaking Bad",
                    Description = "Breaking Bad is an American neo-Western crime drama television series created and produced by Vince Gilligan. Set and filmed in Albuquerque, New Mexico, it tells the story of Walter White (Bryan Cranston), an underpaid, overqualified, and dispirited high-school chemistry teacher who is struggling with a recent diagnosis of stage-three lung cancer. Walter turns to a life of crime, partnering with his former student Jesse Pinkman (Aaron Paul), by producing and distributing crystal meth to secure his family's financial future before he dies, while navigating the dangers of the criminal underworld.",
                    ImageUrl = "https://content2.rozetka.com.ua/goods/images/big/23632594.jpg",
                    Price = 24.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Title = "Raised by Wolves",
                    Description = "Raised by Wolves is an American science fiction drama television series created by Aaron Guzikowski that premiered on HBO Max on September 3, 2020. The first two episodes were directed by Ridley Scott, who also serves as an executive producer for the show. The series was renewed for a second season shortly after its debut, and the second season premiered on February 3, 2022. The first season was met with generally positive reviews from critics, while the second season has received critical acclaim. In June 2022, the series was cancelled after two seasons.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/ru/6/64/Raised_by_Wolves_%28TV%29.jpg",
                    Price = 19.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    Title = "True Detective",
                    Description = "Constructed as a nonlinear narrative, season one focuses on Louisiana State Police homicide detectives Rustin Rust Cohle (McConaughey) and Martin Marty Hart (Harrelson), who investigated the murder of prostitute Dora Lange in 1995. Seventeen years later, they must revisit the investigation, along with several other unsolved crimes. During this time, Hart's infidelity threatens his marriage to Maggie (Monaghan), and Cohle struggles to cope with his troubled past.",
                    ImageUrl = "https://i.pinimg.com/originals/73/61/58/7361583898d2e42805a913c10bfa39fb.jpg",
                    Price = 23.99m,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    Title = "The Wealth of Nations",
                    Description = "An Inquiry into the Nature and Causes of the Wealth of Nations is the magnum opus of the Scottish economist and moral philosopher Adam Smith. First published in 1776, the book offers one of the world's first collected descriptions of what builds nations' wealth, and is today a fundamental work in classical economics.",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71yqXZeTuxL.jpg",
                    Price = 14.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    Title = "The Lord of the Rings",
                    Description = "The Lord of the Rings is an epic high-fantasy novel by English author and scholar J. R. R. Tolkien. Set in Middle-earth, intended to be Earth at some distant time in the past, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.",
                    ImageUrl = "https://s26162.pcdn.co/wp-content/uploads/2017/05/the-lord-of-the-rings-book-cover.jpg",
                    Price = 13.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    Title = "Nineteen Eighty-Four",
                    Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/819ijTWp9JL.jpg",
                    Price = 12.99m,
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    CategoryId = 3,
                    Title = "Batman: Arkham Origins",
                    Price = 19.99m,
                    Description = "Batman: Arkham Origins is a 2013 action-adventure game developed by WB Games Montréal and published by Warner Bros. Interactive Entertainment. Based on the DC Comics superhero Batman, it is the follow-up to the 2011 video game Batman: Arkham City and is the third main installment in the Batman: Arkham series. Written by Corey May, Ryan Galletta, and Dooma Wendschuh, the game's main storyline is set eight years before 2009's Batman: Arkham Asylum and follows a younger, less-refined Batman.",
                    ImageUrl = "https://i.pinimg.com/originals/bd/62/53/bd6253c0755ac54e3b38e4aaf4724b08.jpg",

                },
                new Product
                {
                    Id = 8,
                    CategoryId = 3,
                    Title = "Red Dead Redemption 2",
                    Price = 39.99m,
                    Description = "Red Dead Redemption 2[a] is a 2018 action-adventure game developed and published by Rockstar Games. The game is the third entry in the Red Dead series and a prequel to the 2010 game Red Dead Redemption. The story is set in 1899 and follows the exploits of outlaw Arthur Morgan, a member of the Van der Linde gang, in a fictionalized representation of the Western, Midwestern, and Southern United States. Arthur must deal with the decline of the Wild West whilst attempting to survive against government forces, rival gangs, and other adversaries. The game's epilogue follows fellow gang member John Marston, the protagonist of Red Dead Redemption.",
                    ImageUrl = "https://ru.gecid.com/data/news/201910050926-57502/img/01_red_dead_redemption_2.jpg",
                },
                new Product
                {
                    Id = 9,
                    CategoryId = 3,
                    Price = 14.99m,
                    Title = "The Witcher 3: Wild Hunt",
                    Description = "The Witcher 3: Wild Hunt is the third and final installment in the series of games developed by CD PROJEKT RED featuring the witcher Geralt of Rivia. Unlike the previous games, The Witcher 3 is set in a multi-region open world, featuring over 100 hours of content.",
                    ImageUrl = "https://store-images.s-microsoft.com/image/apps.19883.65858607118306853.bade8222-c0ad-4481-b2d6-b46cc0450658.98c0bbcd-9d06-4bb7-94c8-dd4063e032fc",
                },
                new Product
                {
                    Id = 10,
                    CategoryId = 3,
                    Price = 1999.99m,
                    Title = "PC",
                    Description = "Gaming PC, is a specialized personal computer designed for playing video games at very high standards. Gaming PCs typically differ from mainstream personal computers by using high-performance video cards and high core-count central processing units with raw performance. Gaming PCs are also used for other demanding tasks such as video editing.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/38/Pc_game_logo.png",
                },
                new Product
                {
                    Id = 11,
                    CategoryId = 3,
                    Price = 499.99m,
                    Title = "PlayStation",
                    Description = "PlayStation is a video game brand that consists of five home video game consoles, two handhelds, a media center, and a smartphone, as well as an online service and multiple magazines. The brand is produced by Sony Interactive Entertainment, a division of Sony; the first PlayStation console was released in Japan in December 1994, and worldwide the following year.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Playstation_logo_colour.svg/2560px-Playstation_logo_colour.svg.png",
                }
                );
        }

        //DbSet is needed to add your Models to a database as tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
