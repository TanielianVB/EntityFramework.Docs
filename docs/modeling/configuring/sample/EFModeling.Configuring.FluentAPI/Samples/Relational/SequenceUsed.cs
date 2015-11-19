﻿using Microsoft.Data.Entity;

namespace EFModeling.Configuring.FluentAPI.Samples.Relational.SequenceUsed
{
    class MyContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("OrderNumbers", schema: "sales")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderNo)
                .HasDefaultValueSql("NEXT VALUE FOR shared.MySequence");
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int OrderNo { get; set; }
        public string Url { get; set; }
    }
}