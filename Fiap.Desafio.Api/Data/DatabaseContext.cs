    using Fiap.Desafio.Api.Models;
    using Microsoft.EntityFrameworkCore;

    namespace Fiap.Desafio.Api.Data
    {
        public class DatabaseContext : DbContext
        {
            public virtual DbSet<PersonModel> PersonModels { get; set; }
            public virtual DbSet<UserModel> UserModels { get; set; }
            public virtual DbSet<PermissionModel> PermissionModels { get; set; }
            public virtual DbSet<UserPermissionModel> UserPermissionModels { get; set; }
            public virtual DbSet<ResourceModel> ResourceModels { get; set; }
            public virtual DbSet<ResourceIndexModel> ResourceIndexModels { get; set; }
            public virtual DbSet<RecordMeasurementModel> RecordMeasurementModels { get; set; }
            
            
            
            protected DatabaseContext() { }

            public DatabaseContext(DbContextOptions options) : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<PersonModel>(entity =>
                {
                    entity.ToTable("person");
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255)
                        .HasColumnName("person_name");
                    entity.HasKey(e => e.Email);
                    entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                });

                modelBuilder.Entity<UserModel>(entity =>
                {
                    entity.ToTable("users");
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id_user");
                    entity.Property(e => e.Login).IsRequired().HasMaxLength(255);
                    entity.Property(e => e.SendNotification).HasColumnName("send_notification");
                    entity.Property(e => e.Password).IsRequired().HasMaxLength(255).HasColumnName("passwords");
                    entity.Property(e => e.Enabled);
                    entity.Property(e => e.PersonId).HasColumnName("id_person");

                    entity.HasOne(e => e.Person)
                        .WithOne()
                        .HasForeignKey<UserModel>(e => e.PersonId)
                        .IsRequired()
                        .HasConstraintName("id_person");
                });

                modelBuilder.Entity<PermissionModel>(entity =>
                {
                    entity.ToTable("permission"); 
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("id_permission");
                    entity.Property(e => e.Name).IsRequired().HasMaxLength(255)
                        .HasColumnName("permission_name");
                });

                modelBuilder.Entity<UserPermissionModel>(entity =>
                {
                    entity.ToTable("user_permission");
                    entity.HasKey(up => new { up.UserId, up.PermissionId });

                    entity.Property(up => up.UserId).HasColumnName("id_user");
                    entity.Property(up => up.PermissionId).HasColumnName("id_permission");

                    entity.HasOne(up => up.User)
                        .WithMany(u => u.UserPermissions)
                        .HasForeignKey(up => up.UserId);

                    entity.HasOne(up => up.Permission)
                        .WithMany(p => p.UserPermissions)
                        .HasForeignKey(up => up.PermissionId);
                });
                
                modelBuilder.Entity<ResourceModel>(entity =>
                {
                    entity.ToTable("resources");

                    entity.HasKey(e => e.Id).HasName("id_record");

                    entity.Property(e => e.Id)
                        .HasColumnName("id_resource");

                    entity.Property(e => e.Name)
                        .HasColumnName("resource_name")
                        .HasMaxLength(100)
                        .IsRequired();

                    entity.Property(e => e.UnityMeasure)
                        .HasColumnName("unity_measure")
                        .HasMaxLength(50)
                        .IsRequired();
                });
                
                           modelBuilder.Entity<ResourceIndexModel>(entity =>
            {
                entity.ToTable("resource_index");

                entity.HasKey(e => e.ResourceId)
                      .HasName("PRIMARY");

                entity.Property(e => e.ResourceId)
                      .HasColumnName("id_resource")
                      .IsRequired();

                entity.Property(e => e.IndexMinimum)
                      .HasColumnName("ind_minimum")
                      .IsRequired();

                entity.Property(e => e.IndexNormal)
                      .HasColumnName("ind_normal")
                      .IsRequired();

                entity.Property(e => e.IndexMaximum)
                      .HasColumnName("ind_maximum")
                      .IsRequired();

                entity.HasOne(e => e.Resource)
                      .WithOne()
                      .HasForeignKey<ResourceIndexModel>(e => e.ResourceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RecordMeasurementModel>(entity =>
            {
                entity.ToTable("record_measurements");

                entity.HasKey(e => e.Id)
                      .HasName("PRIMARY");

                entity.Property(e => e.Id)
                      .HasColumnName("id_record")
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.ResourceId)
                      .HasColumnName("id_resource")
                      .IsRequired();

                entity.Property(e => e.DateTime)
                      .HasColumnName("date_time")
                      .IsRequired();

                entity.Property(e => e.Measurement)
                      .HasColumnName("measure")
                      .IsRequired();

                entity.Property(e => e.Location)
                      .HasColumnName("location")
                      .HasMaxLength(200)
                      .IsRequired();

                entity.HasOne(e => e.Resource)
                      .WithMany()
                      .HasForeignKey(e => e.ResourceId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

                base.OnModelCreating(modelBuilder);
            }
        }
    }
