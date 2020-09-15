using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public static class DatabaseInitialization
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkType>()
                .HasData(
                    new LinkType()
                    {
                        Id = 1,
                        Type = "თანამშრომელი"
                    },
                    new LinkType()
                    {
                        Id = 2,
                        Type = "ნათესავი"
                    },
                    new LinkType()
                    {
                        Id = 3,
                        Type = "ნაცნობი"
                    },
                    new LinkType()
                    {
                        Id = 4,
                        Type = "სხვა"
                    }
                );
        }
    }
}
