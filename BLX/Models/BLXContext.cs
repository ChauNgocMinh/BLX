using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;

namespace BLX.Models
{
    public partial class BLXContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BLXContext()
        {
        }

        public BLXContext(DbContextOptions<BLXContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<TypeQuestion> TypeQuestions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserQuestion> UserQuestions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_TypeQuestion");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Rank).HasMaxLength(15);

                entity.Property(e => e.TestDay).HasColumnType("date");
            });

            modelBuilder.Entity<TypeQuestion>(entity =>
            {
                entity.ToTable("TypeQuestion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Domain)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cccd)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("Name");

                entity.Property(e => e.NamSinh).HasColumnType("date");

                entity.Property(e => e.Sbd).HasColumnName("SBD");

                entity.Property(e => e.Score).HasColumnName("Score");
                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Semester");
            });

            modelBuilder.Entity<UserQuestion>(entity =>
            {
                entity.ToTable("UserQuestion");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Reply).HasColumnName("Reply");

                entity.Property(e => e.Number).HasColumnName("Number");


                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.UserQuestions)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserQuestion_Question");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserQuestions)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserQuestion_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
