using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResoApp;

public partial class DbResturantContext : DbContext
{
    public DbResturantContext()
    {
    }

    public DbResturantContext(DbContextOptions<DbResturantContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbInvoice> TbInvoices { get; set; }

    public virtual DbSet<TbItem> TbItems { get; set; }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-IIL7N6G;Database=DbResturant;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryname).HasColumnName("categoryname");
        });

        modelBuilder.Entity<TbInvoice>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Invoicetotal).HasColumnName("invoicetotal");
           

            
        });

        modelBuilder.Entity<TbItem>(entity =>
        {
            entity.HasIndex(e => e.Categoryid, "IX_TbItems_categoryid");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Itemname).HasColumnName("itemname");
            entity.Property(e => e.Itemprice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("itemprice");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Category).WithMany(p => p.TbItems).HasForeignKey(d => d.Categoryid);
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
