using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using WebApi.Controllers;
using Xunit;

namespace WebApi.xUnitTests
{
    public class AlbumsControllerTests
    {
        private readonly Mock<ILogger<AlbumsController>> _mockLogger;
        private readonly IMapper _mockMapper;
        private readonly IAlbumRepository _repository;
        private readonly AlbumsController _albumsController;

        public AlbumsControllerTests()
        {
            // Initialize the database in memory
            var dbContext = DbContextMocker.GetWebApiDBContext();

            // Logger
            _mockLogger = new Mock<ILogger<AlbumsController>>();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            // Mapper
            _mockMapper = mockMapper.CreateMapper();

            // Service / Repository
            _repository = new AlbumRepository(dbContext);

            // Controller
            _albumsController = new AlbumsController(_mockLogger.Object, _repository, _mockMapper);
        }

        #region << GET ALL >>

        [Fact]
        public async void TestGetAlbumsAsync()
        {
            var data = await _albumsController.GetAlbumsAsync();
            
            Assert.IsAssignableFrom<List<AlbumDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetArtistsAsync()
        {
            var data = await _albumsController.GetArtistsAsync();

            Assert.IsAssignableFrom<List<ArtistDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetMusicTypesAsync()
        {
            var data = await _albumsController.GetMusicTypesAsync();

            Assert.IsAssignableFrom<List<MusicTypeDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetRatingTypesAsync()
        {
            var data = await _albumsController.GetRatingTypesAsync();

            Assert.IsAssignableFrom<List<RatingTypeDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetSongsAsync()
        {
            var data = await _albumsController.GetSongsAsync();

            Assert.IsAssignableFrom<List<SongDto>>(data);
            bool IsValid = data[0].ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        #endregion

        #region << GET BY ID >>

        [Fact]
        public async void TestGetAlbumByIdAsync()
        {
            var data = await _albumsController.GetAlbumByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"));
            
            Assert.IsAssignableFrom<AlbumDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetArtistByIdAsync()
        {
            var data = await _albumsController.GetArtistByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a1"));

            Assert.IsAssignableFrom<ArtistDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetMusicTypeByIdAsync()
        {
            var data = await _albumsController.GetMusicTypeByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c1"));

            Assert.IsAssignableFrom<MusicTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetRatingTypeByIdAsync()
        {
            var data = await _albumsController.GetRatingTypeByIdAsync(Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b1"));

            Assert.IsAssignableFrom<RatingTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetSongByIdAsync()
        {
            var data = await _albumsController.GetSongByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"));

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestGetAlbumRatingByIdAsync()
        {
            var data = await _albumsController.GetAlbumRatingByIdAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00fabbb1"));

            Assert.IsAssignableFrom<AlbumRatingDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        #endregion

        #region << CREATE - POST >>

        [Fact]
        public async void TestCreateAlbumAsync()
        {
            var request = new AlbumDto
            {
                Name = "DNA 2",
                Review = @"2222 There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2020-01-22"),
                CopyRightInfo = "222 © 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "Uploads222/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa1")
            };
            
            var data = await _albumsController.CreateAlbumAsync(request);

            Assert.IsAssignableFrom<AlbumDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateArtistAsync()
        {
            var request = new ArtistDto
            {
                Name = "R.E.M."
            };

            var data = await _albumsController.CreateArtistAsync(request);

            Assert.IsAssignableFrom<ArtistDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateMusicTypeAsync()
        {
            var request = new MusicTypeDto
            {
                Name = "Classic"
            };

            var data = await _albumsController.CreateMusicTypeAsync(request);

            Assert.IsAssignableFrom<MusicTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateRatingTypeAsync()
        {
            var request = new RatingTypeDto
            {
                Name = "Star 6",
                Value = 6
            };

            var data = await _albumsController.CreateRatingTypeAsync(request);

            Assert.IsAssignableFrom<RatingTypeDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateSongAsync()
        {
            var request = new SongDto
            {
                AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Number = 5,
                Name = "Is It Just Me",
                Time = new TimeSpan(00, 03, 37),
                SongPriceId = Guid.Parse("1b178d0e-6602-4375-a088-ab8d00facbb1"),
                Popularity = 30,
            };

            var data = await _albumsController.CreateSongAsync(request);

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestCreateAlbumRatingAsync()
        {
            var request = new AlbumRatingDto
            {
                AlbumId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                RatingTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3b3")
            };

            var data = await _albumsController.CreateAlbumRatingAsync(request);

            Assert.IsAssignableFrom<AlbumRatingDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        #endregion

        #region << UPDATE - PUT >>

        [Fact]
        public async void TestUpdateAlbumAsync()
        {
            var albumRequest = new AlbumDto
            {
                UniqueId = Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"),
                Name = "DNA - UPDATED.",
                Review = @"UPDATED There's one question the Backsteet Boys can't seem to escape: Do they still consider themselves a boy band? The five-piece, most of whom are now over 40 and married with children, have come to embrace the term. ""At this point, 'boys' has come to mean more, like, 'friends'."" Kevin Richardson told...",
                Released = DateTime.Parse("2020-01-22"),
                CopyRightInfo = "UPDATED © 2018 K-Bahn, LLC & RCA Records, a division of Sony Music Entertainment",
                CoverPath = "UploadsUPDATED/Pictures/Albums/Covers/DNA.png",
                MusicTypeId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3c2"),
                ArtistId = Guid.Parse("5befa4aa-06fd-4390-a2f5-a54600d4e3a2"),
                AlbumPriceId = Guid.Parse("1a178d0e-6602-4375-a088-ab8d00facaa2"),
            };
            
            var data = await _albumsController.UpdateAlbumAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"), albumRequest);
            
            Assert.IsAssignableFrom<AlbumDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        [Fact]
        public async void TestIncreaseSongPopularityAsync()
        {
            var data = await _albumsController.IncreaseSongPopularityAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facad1"));

            Assert.IsAssignableFrom<SongDto>(data);
            bool IsValid = data.ErrorMessage == null ? true : false;
            Assert.True(IsValid);
        }

        #endregion

        #region << DELETE >>

        [Fact]
        public async void TestDeleteAlbumAsync()
        {
            var response = await _albumsController.DeleteAlbumAsync(Guid.Parse("0f078d0e-6602-4375-a088-ab8d00facdd1"));
            
            Assert.True(response);
        }

        #endregion

    }
}
