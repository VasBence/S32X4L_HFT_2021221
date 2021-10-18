using Microsoft.EntityFrameworkCore;
using S32X4L_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S32X4L_HFT_2021221.Data
{
    public class EgyetemDbContext : DbContext
    {
        public virtual DbSet<tanulok> Tanulok { get; set; }
        public virtual DbSet<targyak> Targyak { get; set; }
        public virtual DbSet<kurzusok> Kurzusok { get; set; }

        public EgyetemDbContext()
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
            modelBuilder.Entity<targyak>(entity =>
            {
                entity
                .HasMany(targyak => targyak.TargyKurzusok)
                .WithOne(kurzusok => kurzusok.Targyak)
                .HasForeignKey(targyak => targyak.KurzusID)
                .OnDelete(DeleteBehavior.Restrict);


            });

            modelBuilder.Entity<tanulok>(entity =>
            {
                entity
                .HasOne(tanulok => tanulok.FelvettKurzusok)
                .WithMany(kurzusok => kurzusok.Tanulok)
                .HasForeignKey(tanulok => tanulok.FelvettKurzusID);
                


            });

            modelBuilder.Entity<kurzusok>(entity =>
            {
                entity
                .HasMany(kurzusok => kurzusok.Tanulok)
                .WithOne(tanulok => tanulok.FelvettKurzusok);
                
                

                entity
                .HasOne(kurzusok => kurzusok.Targyak)
                .WithMany(targyak => targyak.TargyKurzusok)
                .HasForeignKey(kurzusok => kurzusok.TargyID)
                .OnDelete(DeleteBehavior.Restrict);

            });

            targyak analizis2 = new targyak() { TargyID = 1, TargyNev = "Analízis 2", Kredit = 6 };
            targyak hft = new targyak() { TargyID = 2, TargyNev = "Haladó Fejlesztési Technikák", Kredit = 6 };

            kurzusok hftkurzus1 = new kurzusok() { KurzusID = 1, KurzusTanarok = "Sipos Miklós", TargyID = 2 };
            kurzusok hftkurzus2 = new kurzusok() { KurzusID = 2, KurzusTanarok = "Kovács András", TargyID = 2 };

            tanulok vassbence = new tanulok() { Neptunkod = "S32X4L", Nev = "Vass Bence", Kor = 19, FelvettKurzusID = 1};




            modelBuilder.Entity<kurzusok>().HasData(hftkurzus1, hftkurzus2);
            modelBuilder.Entity<targyak>().HasData(analizis2, hft);
            modelBuilder.Entity<tanulok>().HasData(vassbence);

            



        }


    }
}
