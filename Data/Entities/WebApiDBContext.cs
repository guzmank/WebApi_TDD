using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Entities
{
    public partial class WebApiDBContext : DbContext
    {
        public WebApiDBContext()
        {
        }

        public WebApiDBContext(DbContextOptions<WebApiDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumPrice> AlbumPrice { get; set; }
        public virtual DbSet<AlbumRating> AlbumRating { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<MusicType> MusicType { get; set; }
        public virtual DbSet<RatingType> RatingType { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<SongPrice> SongPrice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=KELVIN-LP; Database=WebApiDB; User Id=umsitari; Password=Lapsyl100%; MultipleActiveResultSets=True; Connection Timeout=500");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumPriceId).HasColumnName("AlbumPriceID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.CopyRightInfo).HasMaxLength(500);

                entity.Property(e => e.CoverPath).HasMaxLength(1000);

                entity.Property(e => e.MusicTypeId).HasColumnName("MusicTypeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Released).HasColumnType("datetime");

                entity.HasOne(d => d.AlbumPrice)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.AlbumPriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_ALBUM_PRICE");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_ARTIST");

                entity.HasOne(d => d.MusicType)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.MusicTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_MUSIC_TYPE");
            });

            modelBuilder.Entity<AlbumPrice>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM_PRICE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            });

            modelBuilder.Entity<AlbumRating>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ALBUM_RATING");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.RatingTypeId).HasColumnName("RatingTypeID");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.AlbumRating)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_RATING_ALBUM");

                entity.HasOne(d => d.RatingType)
                    .WithMany(p => p.AlbumRating)
                    .HasForeignKey(d => d.RatingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ALBUM_RATING_RATING_TYPE");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("ARTIST");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MusicType>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("MUSIC_TYPE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RatingType>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("RATING_TYPE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("SONG");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SongPriceId).HasColumnName("SongPriceID");

                entity.Property(e => e.Time).HasColumnType("time(0)");

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SONG_ALBUM");

                entity.HasOne(d => d.SongPrice)
                    .WithMany(p => p.Song)
                    .HasForeignKey(d => d.SongPriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SONG_SONG_PRICE");
            });

            modelBuilder.Entity<SongPrice>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("SONG_PRICE");

                entity.Property(e => e.UniqueId)
                    .HasColumnName("UniqueID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(9, 2)");
            });
        }
    }
}
