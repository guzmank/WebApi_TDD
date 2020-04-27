using Data.Entities;
using System;
using System.Linq;

namespace WebApi.xUnitTests
{
    public static class DbInitializer
    {
        public static void Seed(this WebApiDBContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            
            dbContext.RatingType.AddRange(
                new RatingType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b1"), Name = "Star 1", Value = 1 },
                new RatingType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b2"), Name = "Star 2", Value = 2 },
                new RatingType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b3"), Name = "Star 3", Value = 3 },
                new RatingType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b4"), Name = "Star 4", Value = 4 },
                new RatingType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b5"), Name = "Star 5", Value = 5 }
            );

            dbContext.MusicType.AddRange(
                new MusicType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"), Name = "Pop" },
                new MusicType() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"), Name = "Rock and Roll" }
            );

            dbContext.Artist.AddRange(
                new Artist() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"), Name = "Backstreet Boys" },
                new Artist() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"), Name = "The Beatles" },
                new Artist() { UniqueId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a3"), Name = "Elvis Presley" }
            );

            dbContext.AlbumPrice.AddRange(
                new AlbumPrice() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1"), Price = (decimal)11.29 },
                new AlbumPrice() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa2"), Price = (decimal)12.29 },
                new AlbumPrice() { UniqueId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa3"), Price = (decimal)13.29 }
            );

            dbContext.SongPrice.AddRange(
                new SongPrice() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Price = (decimal)1.29 },
                new SongPrice() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb2"), Price = (decimal)1.30 },
                new SongPrice() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb3"), Price = (decimal)1.31 },
                new SongPrice() { UniqueId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb4"), Price = (decimal)1.32 }
            );

            dbContext.SaveChanges();

            dbContext.Album.Add(new Album
            {
                UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Name = "DNA",
                Review = @"There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2019-01-25"),
                CopyRightInfo = "© 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "Uploads/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1")
            });

            dbContext.SaveChanges();
            
            dbContext.Song.AddRange(
                new Song() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 1, Name = "Don't Go Breaking My Heart", Time = new TimeSpan(00, 03, 36), Popularity = 70 },
                new Song() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad2"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 2, Name = "Nobody Else", Time = new TimeSpan(00, 03, 38), Popularity = 20 },
                new Song() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad3"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 3, Name = "Breathe", Time = new TimeSpan(00, 03, 06), Popularity = 30 },
                new Song() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad4"), AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"), Number = 4, Name = "New Love", Time = new TimeSpan(00, 03, 00), Popularity = 25 }
            );

            dbContext.SaveChanges();
            
            dbContext.AlbumRating.AddRange(
                new AlbumRating() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb1"), Album = dbContext.Album.Where(x => x.UniqueId == Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1")).SingleOrDefault(), RatingType = dbContext.RatingType.Where(x => x.UniqueId == Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b4")).SingleOrDefault() },
                new AlbumRating() { UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb2"), Album = dbContext.Album.Where(x => x.UniqueId == Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1")).SingleOrDefault(), RatingType = dbContext.RatingType.Where(x => x.UniqueId == Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b5")).SingleOrDefault() }
            );

            dbContext.SaveChanges();
        }
    }
}
