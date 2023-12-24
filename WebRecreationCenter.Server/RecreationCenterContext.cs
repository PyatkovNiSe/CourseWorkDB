using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebRecreationCenter.Server;

public partial class RecreationCenterContext : DbContext
{
    public RecreationCenterContext()
    {
    }

    public RecreationCenterContext(DbContextOptions<RecreationCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Lodge> Lodges { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicerating> Serviceratings { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=recreation_center;Username=postgres;Password=16062001");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("basket_pkey");

            entity.ToTable("basket");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Service).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.Serviceid)
                .HasConstraintName("basket_serviceid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("basket_userid_fkey");
        });

        modelBuilder.Entity<Lodge>(entity =>
        {
            entity.HasKey(e => e.Lodgeid).HasName("lodge_pkey");

            entity.ToTable("lodge");

            entity.Property(e => e.Lodgeid).HasColumnName("lodgeid");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Lodgenumber).HasColumnName("lodgenumber");
            entity.Property(e => e.Lodgeprice)
                .HasPrecision(10, 2)
                .HasColumnName("lodgeprice");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Reservationid).HasName("reservation_pkey");

            entity.ToTable("reservation");

            entity.Property(e => e.Reservationid).HasColumnName("reservationid");
            entity.Property(e => e.Checkindate).HasColumnName("checkindate");
            entity.Property(e => e.Checkoutdate).HasColumnName("checkoutdate");
            entity.Property(e => e.Lodgeid).HasColumnName("lodgeid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Lodge).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Lodgeid)
                .HasConstraintName("reservation_lodgeid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("reservation_userid_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pkey");

            entity.ToTable("role");

            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Serviceid).HasName("service_pkey");

            entity.ToTable("service");

            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Servicedescription).HasColumnName("servicedescription");
            entity.Property(e => e.Servicename)
                .HasMaxLength(255)
                .HasColumnName("servicename");
            entity.Property(e => e.Serviceprice)
                .HasPrecision(10, 2)
                .HasColumnName("serviceprice");
        });

        modelBuilder.Entity<Servicerating>(entity =>
        {
            entity.HasKey(e => e.Ratingid).HasName("servicerating_pkey");

            entity.ToTable("servicerating");

            entity.Property(e => e.Ratingid).HasColumnName("ratingid");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Serviceid).HasColumnName("serviceid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Service).WithMany(p => p.Serviceratings)
                .HasForeignKey(d => d.Serviceid)
                .HasConstraintName("servicerating_serviceid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Serviceratings)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("servicerating_userid_fkey");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.Userdataid).HasName("userdata_pkey");

            entity.ToTable("userdata");

            entity.Property(e => e.Userdataid).HasColumnName("userdataid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(255)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Role).HasColumnName("role");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.Userdata)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("userdata_role_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
