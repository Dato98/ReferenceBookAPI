using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class ReferenceDBContext : DbContext
    {
        public ReferenceDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<LinkedPerson> LinkedPeople { get; set; }
        public DbSet<LinkType> LinkTypes { get; set; }
        public DbSet<ContactInformation> ContactInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Person
            modelBuilder.Entity<Person>()
                .Property(e => e.NameEng)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.NameGeo)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.SurnameEng)
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.SurnameGeo)
                .HasColumnType("nvarchar(60)")
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.BirthDate)
                .HasColumnType("Date")
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .Property(e => e.Address)
                .HasColumnType("nvarchar(300)")
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .HasMany(e => e.ContactInformation)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Restrict);


            // LinkedPerson

            modelBuilder.Entity<LinkedPerson>()
                .HasOne(e => e.LinkType)
                .WithMany(e => e.linkedPeople)
                .HasForeignKey(e => e.LinkTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LinkedPerson>()
                .HasOne(e => e.Person)
                .WithMany(e => e.LinkedPerson)
                .HasForeignKey(e => e.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            // ContactInformation

            modelBuilder.Entity<ContactInformation>()
                .Property(e => e.Information)
                .HasMaxLength(100)
                .IsRequired();

            // LinkType

            modelBuilder.Entity<LinkType>()
                .Property(e => e.Type)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Seed();
        }
    }
}
