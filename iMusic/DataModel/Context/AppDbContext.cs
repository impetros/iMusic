using System;
using iMusic.DataModel.Models;
using Microsoft.EntityFrameworkCore;

namespace iMusic.DataModel.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistDetails> ArtistDetails { get; set; }
        public DbSet<ArtistSong> ArtistSongs { get; set; }
        public DbSet<MusicGenre> MusicGenres { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=imusic.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> ShoppingCart (ONE TO MANY)
            modelBuilder.Entity<ShoppingCart>()
                .HasOne(p => p.User)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(p => p.UserId);

            // ShoppingCart -> ShoppingCartItem (ONE TO MANY)
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(p => p.ShoppingCart)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(p => p.ShoppingCartId);

            // Album -> ShoppingCartItem (ONE TO MANY)
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(p => p.Album)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(p => p.AlbumId);

            // Song -> ShoppingCartItem (ONE TO MANY)
            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(p => p.Song)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(p => p.SongId);

            // Artist -> ArtistDetails (ONE TO ONE)
            modelBuilder.Entity<ArtistDetails>().HasKey(sc => sc.ArtistId); // foreign key is primary key too
            modelBuilder.Entity<Artist>()
                .HasOne<ArtistDetails>(s => s.ArtistDetails) // one to one
                .WithOne(ad => ad.Artist)
                .HasForeignKey<ArtistDetails>(ad => ad.ArtistId);

            // Artist -> Album (ONE TO MANY)
            modelBuilder.Entity<Album>()
                .HasOne(p => p.Artist)
                .WithMany(b => b.Albums)
                .HasForeignKey(p => p.AlbumId);

            // Album -> Song (ONE TO MANY)
            modelBuilder.Entity<Song>()
                .HasOne(p => p.Album)
                .WithMany(p => p.Songs)
                .HasForeignKey(p => p.AlbumId);

            // Artist -> Song (MANY TO MANY)
            modelBuilder.Entity<ArtistSong>().HasKey(sc => new { sc.ArtistId, sc.SongId });

            modelBuilder.Entity<ArtistSong>()
            .HasOne(x => x.Artist)
            .WithMany(x => x.ArtistSongs)
            .HasForeignKey(x => x.ArtistId);

            modelBuilder.Entity<ArtistSong>()
               .HasOne(x => x.Song)
               .WithMany(x => x.ArtistSongs)
               .HasForeignKey(x => x.SongId);

            // Song -> Music Genre (MANY TO MANY)
            modelBuilder.Entity<SongGenre>().HasKey(sc => new { sc.SongId, sc.MusicGenreId });

            modelBuilder.Entity<SongGenre>()
                .HasOne(p => p.Song)
                .WithMany(p => p.SongGenres)
                .HasForeignKey(p => p.SongId);

            modelBuilder.Entity<SongGenre>()
                .HasOne(p => p.MusicGenre)
                .WithMany(p => p.SongGenres)
                .HasForeignKey(p => p.MusicGenreId);
        }
    }
}
