using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server =MSI\\SQLEXPRESS; database=SiteDB00;  integrated security=true;TrustServerCertificate=true;");
        }

        public DbSet<Aidat> Aidats { get; set; }
        public DbSet<Blok> Bloks { get; set; }
        public DbSet<Daire>Daires  { get; set; }
        public DbSet<EvSahibiKiraci>EvSahibis  { get; set; }
        public DbSet<Gider> Giders { get; set; }
       
        public DbSet<Site> Sites { get; set; }
        public DbSet<SiteYoneticisi> SiteYoneticisis { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

