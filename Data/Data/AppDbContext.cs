using Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<ProductReceipt> ProductReceipts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReceipt>()
                .HasKey(e => new { e.ReceiptId, e.ProductId });

            modelBuilder.Entity<ProductReceipt>(entity =>
            {
                entity.HasOne(pr => pr.Product)
                .WithMany(pr => pr.ProductReceipt)
                .HasForeignKey(pr => pr.ProductId);
            });

            modelBuilder.Entity<ProductReceipt>(entity =>
            {
                entity.HasOne(pr => pr.Receipt)
                .WithMany(pr => pr.ProductReceipt)
                .HasForeignKey(pr => pr.ReceiptId);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasOne(r => r.Client)
                .WithMany(r => r.Receipts)
                .HasForeignKey(r => r.ClientId);
            });

        }


    }
}
