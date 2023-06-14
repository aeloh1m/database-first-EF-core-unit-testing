using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreProject.Models
{

    public partial class HollywoodContext : DbContext
    {
        public HollywoodContext()
        {
        }

        public HollywoodContext(DbContextOptions<HollywoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=admin;database=hollywood", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
            

        }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.IdActor).HasName("PRIMARY");

                entity.ToTable("actor");

                entity.Property(e => e.IdActor)
                    .ValueGeneratedNever()
                    .HasColumnName("idActor");
                entity.Property(e => e.ActorBirthdate).HasColumnName("actor_birthdate");
                entity.Property(e => e.ActorName)
                    .HasMaxLength(45)
                    .HasColumnName("actor_name");
                entity.Property(e => e.ActorPicture)
                    .HasMaxLength(45)
                    .HasColumnName("actor_picture");

                entity.HasOne(d => d.IdActorNavigation).WithOne(p => p.Actor)
                    .HasForeignKey<Actor>(d => d.IdActor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Movie_Actor");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.IdMovie).HasName("PRIMARY");

                entity.ToTable("movie");

                entity.Property(e => e.IdMovie)
                    .ValueGeneratedNever()
                    .HasColumnName("idMovie");
                entity.Property(e => e.MovieBudget).HasColumnName("movie_budget");
                entity.Property(e => e.MovieDuration).HasColumnName("movie_duration");
                entity.Property(e => e.MovieGenre)
                    .HasMaxLength(45)
                    .HasColumnName("movie_genre");
                entity.Property(e => e.MovieName)
                    .HasMaxLength(45)
                    .HasColumnName("movie_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }



}

