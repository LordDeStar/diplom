using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace diplombee.Model;

public partial class BeeContext : DbContext
{
    public BeeContext()
    {
    }

    public BeeContext(DbContextOptions<BeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Ordersproduct> Ordersproducts { get; set; }

    public virtual DbSet<PriseList> PriseLists { get; set; }

    public virtual DbSet<Statusorder> Statusorders { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=1234;database=test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.IdArea).HasName("PRIMARY");

            entity.ToTable("areas");

            entity.Property(e => e.IdArea).HasColumnName("idArea");
            entity.Property(e => e.NameArea)
                .HasMaxLength(45)
                .HasColumnName("name_area");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Idcategory).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Idcategory).HasColumnName("idcategory");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(45)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Idclients).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.Idclients).HasColumnName("idclients");
            //entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.LoginClient)
                .HasMaxLength(45)
                .HasColumnName("login_client");
            entity.Property(e => e.NameClient)
                .HasMaxLength(45)
                .HasColumnName("name_client");
            entity.Property(e => e.PasswordClient)
                .HasMaxLength(45)
                .HasColumnName("password_client");
            entity.Property(e => e.PatronomycClient)
                .HasMaxLength(45)
                .HasColumnName("patronomyc_client");
            entity.Property(e => e.PhoneClient)
                .HasMaxLength(45)
                .HasColumnName("phone_client");
            entity.Property(e => e.SurnameClient)
                .HasMaxLength(45)
                .HasColumnName("surname_client");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Idmanagers).HasName("PRIMARY");

            entity.ToTable("managers");

            entity.Property(e => e.Idmanagers).HasColumnName("idmanagers");
            entity.Property(e => e.BirthdayManager).HasColumnName("birthday_manager");
            entity.Property(e => e.LoginManager)
                .HasMaxLength(45)
                .HasColumnName("login_manager");
            entity.Property(e => e.NameManager)
                .HasMaxLength(45)
                .HasColumnName("name_manager");
            entity.Property(e => e.PasswordManager)
                .HasMaxLength(45)
                .HasColumnName("password_manager");
            entity.Property(e => e.PatronomycManager)
                .HasMaxLength(45)
                .HasColumnName("patronomyc_manager");
            entity.Property(e => e.PhoneManager)
                .HasMaxLength(45)
                .HasColumnName("phone_manager");
            entity.Property(e => e.SurnameManager)
                .HasMaxLength(45)
                .HasColumnName("surname_manager");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Idorders).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.Property(e => e.Idorders).HasColumnName("idorders");
            entity.Property(e => e.DataGet)
                .HasColumnType("datetime")
                .HasColumnName("data_get");
            entity.Property(e => e.Etaj).HasColumnName("etaj");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdStreet).HasColumnName("id_street");
            entity.Property(e => e.NumberHouse).HasColumnName("number_house");
            entity.Property(e => e.NumberKv).HasColumnName("number_kv");
            entity.Property(e => e.NumberPodjezd).HasColumnName("number_podjezd");
            entity.Property(e => e.Reasons).HasColumnName("reasons");
            entity.Property(e => e.StatusOrder).HasColumnName("status_order");
        });

        modelBuilder.Entity<Ordersproduct>(entity =>
        {
            entity.HasKey(e => e.IdOrdersProducts).HasName("PRIMARY");

            entity.ToTable("ordersproducts");

            entity.HasIndex(e => e.OrderId, "order_idx");

            entity.HasIndex(e => e.ProductId, "product_idx");

            entity.Property(e => e.IdOrdersProducts).HasColumnName("idOrdersProducts");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Order).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("order");

            entity.HasOne(d => d.Product).WithMany(p => p.Ordersproducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("product");
        });

        modelBuilder.Entity<PriseList>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PRIMARY");

            entity.ToTable("prise_list");

            entity.HasIndex(e => e.Article, "article_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Categoyid, "cat_idx");

            entity.Property(e => e.IdProduct).HasColumnName("idProduct");
            entity.Property(e => e.Article)
                .HasMaxLength(45)
                .HasColumnName("article");
            entity.Property(e => e.Categoyid).HasColumnName("categoyid");
            entity.Property(e => e.CostForOne)
                .HasPrecision(10, 2)
                .HasColumnName("cost_for_one");
            entity.Property(e => e.CountInStock).HasColumnName("count_in_stock");
            entity.Property(e => e.Image)
                .HasMaxLength(45)
                .HasColumnName("image");
            entity.Property(e => e.NameProduct)
                .HasMaxLength(100)
                .HasColumnName("name_product");

            entity.HasOne(d => d.Categoy).WithMany(p => p.PriseLists)
                .HasForeignKey(d => d.Categoyid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cat");
        });

        modelBuilder.Entity<Statusorder>(entity =>
        {
            entity.HasKey(e => e.IdStatusOrders).HasName("PRIMARY");

            entity.ToTable("statusorders");

            entity.Property(e => e.IdStatusOrders).HasColumnName("idStatusOrders");
            entity.Property(e => e.NameStarus)
                .HasMaxLength(45)
                .HasColumnName("Name_starus");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.Idstreet).HasName("PRIMARY");

            entity.ToTable("streets");

            entity.HasIndex(e => e.IdArea, "area_idx");

            entity.Property(e => e.Idstreet).HasColumnName("idstreet");
            entity.Property(e => e.IdArea).HasColumnName("id_area");
            entity.Property(e => e.NameStreet)
                .HasMaxLength(45)
                .HasColumnName("name_street");

            entity.HasOne(d => d.IdAreaNavigation).WithMany(p => p.Streets)
                .HasForeignKey(d => d.IdArea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("area");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
