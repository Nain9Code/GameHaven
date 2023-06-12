using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GameHaven.Models
{
    public partial class GameHavenContext : DbContext
    {
        public GameHavenContext()
        {
        }

        public GameHavenContext(DbContextOptions<GameHavenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ActivityLog> ActivityLog { get; set; }
        public virtual DbSet<CommentReports> CommentReports { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<GameReports> GameReports { get; set; }
        public virtual DbSet<GameScreenshots> GameScreenshots { get; set; }

        public virtual DbSet<GameTags> GameTags { get; set; }

        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost,1443;Database=GameHaven;User Id=sa;Password=Avalisito_1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleID);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.RoleName)
                    .IsUnique();
            });



            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CCAC0EF500CC");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.IsBanned).HasDefaultValueSql("((0))");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Users__RoleID__5629CD9C");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.GameId);

                entity.Property(e => e.FreeGameName).HasMaxLength(100);
                entity.Property(e => e.GameDescription).HasMaxLength(500);
                entity.Property(e => e.GameFileUrl); // new property
                entity.Property(e => e.CategoryId); // new property

                entity.HasOne(d => d.Category) // new relation
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Games_CategoryId");
            });
            modelBuilder.Entity<GameScreenshots>(entity =>
            {
                entity.HasKey(e => e.ScreenshotId);

                entity.Property(e => e.ScreenshotImagePath);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameScreenshots)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_GameScreenshots_GameId");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ActivityLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.ActionTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ActionType)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActivityLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActivityLog_UserId");
            });


            modelBuilder.Entity<CommentReports>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.CommentReports)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK_CommentReports_CommentId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CommentReports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_CommentReports_UserId");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Comments_GameId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comments_UserId");
            });

            modelBuilder.Entity<GameReports>(entity =>
            {
                entity.HasKey(e => e.ReportId);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameReports)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_GameReports_GameId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameReports)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_GameReports_UserId");
            });

            modelBuilder.Entity<GameTags>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.TagId });

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameTags)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameTags_GameId");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.GameTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameTags_TagId");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.HasCheckConstraint("CK_Ratings_RatingValue", "[RatingValue]>=1 AND [RatingValue]<=5");


                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK_Ratings_GameId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Ratings_UserId");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.TagName)
                    .IsUnique();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
