using Microsoft.EntityFrameworkCore;
using psikolog_randevu_projesi.Models;

namespace psikolog_randevu_projesi.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<hizmet> Hizmetler { get; set; }
        public DbSet<RandevuKayıt> RandevuKayitlari { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ZEYNEPS\\SQLEXPRESS;initial Catalog=PsikologRandevuDb;integrated Security=true;TrustServerCertificate=true;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RandevuKayıt>()
                .HasOne(r => r.Hizmet)
                .WithMany(h => h.RandevuKayıtları)
                .HasForeignKey(r => r.HizmetId);
        }

    }
}
