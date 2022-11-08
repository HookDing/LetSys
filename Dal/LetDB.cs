using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Dal
{
    public partial class LetDB : DbContext
    {
        public LetDB()
            : base("name=LetDB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ChargeCategory> ChargeCategory { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Dutys> Dutys { get; set; }
        public virtual DbSet<Employs> Employs { get; set; }
        public virtual DbSet<HouseCategory> HouseCategory { get; set; }
        public virtual DbSet<HouseInfo> HouseInfo { get; set; }
        public virtual DbSet<JurisdicDuty> JurisdicDuty { get; set; }
        public virtual DbSet<Jurisdictions> Jurisdictions { get; set; }
        public virtual DbSet<Lets> Lets { get; set; }
        public virtual DbSet<PayInfo> PayInfo { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChargeCategory>()
                .Property(e => e.CCColumn1)
                .IsUnicode(false);

            modelBuilder.Entity<ChargeCategory>()
                .Property(e => e.CCColumn2)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.CusTel)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.CusCard)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employs>()
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<Employs>()
                .Property(e => e.LoginPWD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HRent)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HNet)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HElectric)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HWater)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HElectricMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<HouseInfo>()
                .Property(e => e.HWaterMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.LetRent)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.LetNet)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.BeginElectric)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.BeginWater)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.EndElectric)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.EndWater)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.EndMoney)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.LetElectric)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Lets>()
                .Property(e => e.LetWater)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.PayNum)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.PayPrice)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.PayMoney1)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PayInfo>()
                .Property(e => e.PayMoney2)
                .HasPrecision(8, 2);
        }
    }
}
