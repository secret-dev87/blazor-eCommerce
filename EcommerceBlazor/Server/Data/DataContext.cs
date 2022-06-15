namespace EcommerceBlazor.Server.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //DbSet is needed to add your Models to a database
        public DbSet<Product> Products { get; set; }

    }
}
