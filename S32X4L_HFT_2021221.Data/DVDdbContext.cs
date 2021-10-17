using Microsoft.EntityFrameworkCore;
using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Data
{
    public class DVDDbContext:DbContext
    {
        public virtual DbSet<DVD> DVDs {  get; set;}
        public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }    
        public virtual DbSet<DVDstore> DVDstore { get; set; }

        public DVDDbContext()
        {
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity
                .HasMany(customer => customer.RentedDVDs)
                .WithMany(dvd => dvd.CustomerWhoRentedID);
                
            });

            modelBuilder.Entity<DVD>(entity =>
            {
                entity
                .HasMany(dvd => dvd.CustomerWhoRentedID)
                .WithMany(customerwhoranted => customerwhoranted.RentedDVDs);

            });

            modelBuilder.Entity<DVDstore>(entity =>
            {
                entity
                .HasMany(store => store.DVDs)
                .WithOne(dvd => dvd.Store)
                .OnDelete(DeleteBehavior.Restrict);
            });

            DVDstore dvdstore = new DVDstore() { ID = 1, StoreName = "Bence Boltja ( ami legálisan üzemel )", Location = "1034 Budapest, Bécsi út 104", WorkerCount = 20 };
            CustomerInfo customer = new CustomerInfo()
            { ID = 1, Name = "Kálvin Ferenc" };
            CustomerInfo customer2 = new CustomerInfo()
            { ID = 2, Name = "Rajnai Gábor" };
            CustomerInfo customer3 = new CustomerInfo()
            { ID = 3, Name = "Dobák Csongor" };
            CustomerInfo customer4 = new CustomerInfo()
            { ID = 4, Name = "Bence Vass " };

            DVD Venom2 = new DVD() { ID = 1, Title = "Venom 2", Length = 97, Genre = Genre.action, Store = dvdstore };
            DVD nincsido= new DVD() { ID = 2, Title = "007 Nincs idő meghalni", Length = 163, Genre = Genre.action, Store = dvdstore };
            DVD shangchi = new DVD() { ID = 3, Title = "Shang-chi és a tíz gyűrű legendája", Length = 132, Genre = Genre.action, Store = dvdstore };

            modelBuilder.Entity<DVDstore>().HasData(dvdstore);
            modelBuilder.Entity<CustomerInfo>().HasData(customer, customer2, customer3, customer4);
            modelBuilder.Entity<DVD>().HasData(Venom2, nincsido, shangchi);

        }


    }
}
