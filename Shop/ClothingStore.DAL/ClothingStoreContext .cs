using Microsoft.EntityFrameworkCore;

namespace ClothingStore.DAL
{
    public class ClothingStoreContext : DbContext
    {
        public DbSet<ClothingItem> ClothingItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CLothingShop;Trusted_Connection=True;");
        }
    }
}
