using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAlbumRepository
    {
        // GET ALL
        Task<List<Album>> GetAlbumsAsync();
        Task<List<Artist>> GetArtistsAsync();
        Task<List<MusicType>> GetMusicTypesAsync();
        Task<List<RatingType>> GetRatingTypesAsync();
        Task<List<Song>> GetSongsAsync();

        // GET BY ID
        Task<Album> GetAlbumByIdAsync(Guid albumId);
        Task<Artist> GetArtistByIdAsync(Guid artistId);
        Task<MusicType> GetMusicTypeByIdAsync(Guid musicTypeId);
        Task<RatingType> GetRatingTypeByIdAsync(Guid ratingTypeId);
        Task<Song> GetSongByIdAsync(Guid songId);
        Task<AlbumRating> GetAlbumRatingByIdAsync(Guid albumRatingId);

        // CREATE - POST
        Task<Album> CreateAlbumAsync(Album album);
        Task<Artist> CreateArtistAsync(Artist artist);
        Task<MusicType> CreateMusicTypeAsync(MusicType musicType);
        Task<RatingType> CreateRatingTypeAsync(RatingType ratingType);
        Task<Song> CreateSongAsync(Song song);
        Task<AlbumRating> CreateAlbumRatingAsync(AlbumRating albumRating);

        // UPDATE - PUT
        Task<Album> UpdateAlbumAsync(Album album);
        Task<Song> IncreaseSongPopularityAsync(Guid songId);

        // DELETE
        Task<bool> DeleteAlbumAsync(Guid albumId);
    }

    public class AlbumRepository : IAlbumRepository
    {
        WebApiDBContext db;

        public AlbumRepository(WebApiDBContext _db)
        {
            db = _db;
        }

        #region << GET ALL >>

        public async Task<List<Album>> GetAlbumsAsync()
        {
            if (db != null)
            {
                var response = new List<Album>();

                foreach (var album in await db.Album.ToListAsync())
                {
                    album.Artist = await db.Artist.Where(x => x.UniqueId == album.ArtistId).SingleOrDefaultAsync();
                    album.Artist.Album = null;
                    album.MusicType = await db.MusicType.Where(x => x.UniqueId == album.MusicTypeId).SingleOrDefaultAsync();
                    album.MusicType.Album = null;
                    album.AlbumPrice = await db.AlbumPrice.Where(x => x.UniqueId == album.AlbumPriceId).SingleOrDefaultAsync();
                    album.AlbumPrice.Album = null;

                    album.Song = await db.Song.Where(x => x.AlbumId == album.UniqueId).ToListAsync();
                    foreach (var song in album.Song)
                    {
                        song.Album = null;
                        song.SongPrice.Song = null;
                    }

                    album.AlbumRating = await db.AlbumRating.Where(x => x.AlbumId == album.UniqueId).ToListAsync();
                    foreach (var albumRating in album.AlbumRating)
                    {
                        albumRating.Album = null;
                        albumRating.RatingType = await db.RatingType.Where(x => x.UniqueId == albumRating.RatingTypeId).SingleOrDefaultAsync();
                        albumRating.RatingType.AlbumRating = null;
                    }

                    response.Add(album);
                }

                return response;
            }

            return null;
        }

        public async Task<List<Artist>> GetArtistsAsync()
        {
            if (db != null)
            {
                var response = new List<Artist>();

                foreach (var artist in await db.Artist.ToListAsync())
                {
                    artist.Album = null;
                    response.Add(artist);
                }

                return response;
            }

            return null;
        }

        public async Task<List<MusicType>> GetMusicTypesAsync()
        {
            if (db != null)
            {
                var response = new List<MusicType>();

                foreach (var musicType in await db.MusicType.ToListAsync())
                {
                    musicType.Album = null;
                    response.Add(musicType);
                }

                return response;
            }

            return null;
        }

        public async Task<List<RatingType>> GetRatingTypesAsync()
        {
            if (db != null)
            {
                var response = new List<RatingType>();

                foreach (var ratingType in await db.RatingType.ToListAsync())
                {
                    ratingType.AlbumRating = null;
                    response.Add(ratingType);
                }

                return response;
            }

            return null;
        }

        public async Task<List<Song>> GetSongsAsync()
        {
            if (db != null)
            {
                var response = new List<Song>();

                foreach (var song in await db.Song.ToListAsync())
                {
                    song.Album = null;
                    song.SongPrice.Song = null;
                    response.Add(song);
                }

                return response;
            }

            return null;
        }

        #endregion

        #region << GET BY ID >>

        public async Task<Album> GetAlbumByIdAsync(Guid albumId)
        {
            if (db != null)
            {
                var album = await db.Album.Where(x => x.UniqueId == albumId).SingleOrDefaultAsync();

                album.Artist = await db.Artist.Where(x => x.UniqueId == album.ArtistId).SingleOrDefaultAsync();
                album.Artist.Album = null;
                album.MusicType = await db.MusicType.Where(x => x.UniqueId == album.MusicTypeId).SingleOrDefaultAsync();
                album.MusicType.Album = null;
                album.AlbumPrice = await db.AlbumPrice.Where(x => x.UniqueId == album.AlbumPriceId).SingleOrDefaultAsync();
                album.AlbumPrice.Album = null;

                album.Song = await db.Song.Where(x => x.AlbumId == album.UniqueId).ToListAsync();
                foreach (var song in album.Song)
                {
                    song.Album = null;
                    if (song.SongPrice != null)
                        song.SongPrice.Song = null;
                }

                album.AlbumRating = await db.AlbumRating.Where(x => x.AlbumId == album.UniqueId).ToListAsync();
                foreach (var albumRating in album.AlbumRating)
                {
                    albumRating.Album = null;

                    albumRating.RatingType = await db.RatingType.Where(x => x.UniqueId == albumRating.RatingTypeId).SingleOrDefaultAsync();
                    if (albumRating.RatingType != null)
                        albumRating.RatingType.AlbumRating = null;
                }

                return album;
            }

            return null;
        }

        public async Task<Artist> GetArtistByIdAsync(Guid artistId)
        {
            if (db != null)
            {
                var response = await db.Artist.Where(x => x.UniqueId == artistId).SingleOrDefaultAsync();

                response.Album = null;

                return response;
            }

            return null;
        }

        public async Task<MusicType> GetMusicTypeByIdAsync(Guid musicTypeId)
        {
            if (db != null)
            {
                var response = await db.MusicType.Where(x => x.UniqueId == musicTypeId).SingleOrDefaultAsync();

                response.Album = null;

                return response;
            }

            return null;
        }

        public async Task<RatingType> GetRatingTypeByIdAsync(Guid ratingTypeId)
        {
            if (db != null)
            {
                var response = await db.RatingType.Where(x => x.UniqueId == ratingTypeId).SingleOrDefaultAsync();

                response.AlbumRating = null;

                return response;
            }

            return null;
        }

        public async Task<Song> GetSongByIdAsync(Guid songId)
        {
            if (db != null)
            {
                var response = await db.Song.Where(x => x.UniqueId == songId).SingleOrDefaultAsync();

                response.Album = null;
                response.SongPrice.Song = null;

                return response;
            }

            return null;
        }

        public async Task<AlbumRating> GetAlbumRatingByIdAsync(Guid albumRatingId)
        {
            if (db != null)
            {
                var response = await db.AlbumRating.Where(x => x.UniqueId == albumRatingId).SingleOrDefaultAsync();
                response.Album = null;
                response.RatingType.AlbumRating = null;

                return response;
            }

            return null;
        }

        #endregion

        #region << CREATE - POST >>

        public async Task<Album> CreateAlbumAsync(Album album)
        {
            if (db != null)
            {
                album.UniqueId = Guid.NewGuid();
                await db.Album.AddAsync(album);
                await db.SaveChangesAsync();

                return await GetAlbumByIdAsync(album.UniqueId);
            }

            return null;
        }

        public async Task<Artist> CreateArtistAsync(Artist artist)
        {
            if (db != null)
            {
                artist.UniqueId = Guid.NewGuid();
                await db.Artist.AddAsync(artist);
                await db.SaveChangesAsync();

                return await GetArtistByIdAsync(artist.UniqueId);
            }

            return null;
        }

        public async Task<MusicType> CreateMusicTypeAsync(MusicType musicType)
        {
            if (db != null)
            {
                musicType.UniqueId = Guid.NewGuid();
                await db.MusicType.AddAsync(musicType);
                await db.SaveChangesAsync();

                return await GetMusicTypeByIdAsync(musicType.UniqueId);
            }

            return null;
        }

        public async Task<RatingType> CreateRatingTypeAsync(RatingType ratingType)
        {
            if (db != null)
            {
                ratingType.UniqueId = Guid.NewGuid();
                await db.RatingType.AddAsync(ratingType);
                await db.SaveChangesAsync();

                return await GetRatingTypeByIdAsync(ratingType.UniqueId);
            }

            return null;
        }

        public async Task<Song> CreateSongAsync(Song song)
        {
            if (db != null)
            {
                song.UniqueId = Guid.NewGuid();
                await db.Song.AddAsync(song);
                await db.SaveChangesAsync();

                return await GetSongByIdAsync(song.UniqueId);
            }

            return null;
        }

        public async Task<AlbumRating> CreateAlbumRatingAsync(AlbumRating albumRating)
        {
            if (db != null)
            {
                albumRating.UniqueId = Guid.NewGuid();
                await db.AlbumRating.AddAsync(albumRating);
                await db.SaveChangesAsync();

                return await GetAlbumRatingByIdAsync(albumRating.UniqueId);
            }

            return null;
        }

        #endregion

        #region << UDPATE - PUT >>

        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            if (db != null)
            {
                DetachAll();
                db.Album.Update(album);
                await db.SaveChangesAsync();

                return await GetAlbumByIdAsync(album.UniqueId);
            }

            return null;
        }

        public async Task<Song> IncreaseSongPopularityAsync(Guid songId)
        {
            if (db != null)
            {
                var song = await db.Song.Where(x => x.UniqueId == songId).SingleOrDefaultAsync();
                song.Popularity += 1;
                db.Song.Update(song);
                await db.SaveChangesAsync();

                return await GetSongByIdAsync(song.UniqueId);
            }

            return null;
        }

        #endregion

        #region << DELETE >>

        public async Task<bool> DeleteAlbumAsync(Guid albumId)
        {
            bool result = false;

            if (db != null)
            {
                //Find the album for specific album id
                var album = await db.Album.SingleOrDefaultAsync(x => x.UniqueId == albumId);

                if (album != null)
                {
                    db.AlbumRating.RemoveRange(await db.AlbumRating.Where(x => x.AlbumId == albumId).ToListAsync());
                    db.Song.RemoveRange(await db.Song.Where(x => x.AlbumId == albumId).ToListAsync());

                    //Delete album
                    db.Album.Remove(album);

                    //Commit the transaction
                    result = await db.SaveChangesAsync() >= 1;
                }

                return result;
            }

            return result;
        }

        #endregion

        #region << PRIVATE METHODS >>

        private void DetachAll()
        {
            EntityEntry[] entityEntries = db.ChangeTracker.Entries().ToArray();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

        #endregion

    }
}
