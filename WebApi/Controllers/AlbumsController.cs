using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        protected readonly ILogger _logger;
        private IMapper _mapper;
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(ILogger<AlbumsController> logger, IAlbumRepository albumRepository, IMapper mapper)
        {
            _logger = logger;
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        #region << GET >>

        // api/albums/GetAlbums
        [HttpGet]
        [Route("GetAlbums")]
        public async Task<List<AlbumDto>> GetAlbumsAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new List<AlbumDto>();

            try
            {
                _logger?.LogInformation("The GetAlbumsAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetAlbumsAsync();

                response = _mapper.Map<List<AlbumDto>>(serviceResponse);

                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new List<AlbumDto> { new AlbumDto { ErrorMessage = new string[] { ex.Message } } };
            }
        }

        [HttpGet]
        [Route("GetArtists")]
        public async Task<List<ArtistDto>> GetArtistsAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new List<ArtistDto>();

            try
            {
                _logger?.LogInformation("The GetArtistsAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetArtistsAsync();

                response = _mapper.Map<List<ArtistDto>>(serviceResponse);

                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new List<ArtistDto> { new ArtistDto { ErrorMessage = new string[] { ex.Message } } };
            }
        }

        [HttpGet]
        [Route("GetMusicTypes")]
        public async Task<List<MusicTypeDto>> GetMusicTypesAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new List<MusicTypeDto>();

            try
            {
                _logger?.LogInformation("The GetMusicTypesAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetMusicTypesAsync();

                response = _mapper.Map<List<MusicTypeDto>>(serviceResponse);

                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new List<MusicTypeDto> { new MusicTypeDto { ErrorMessage = new string[] { ex.Message } } };
            }
        }

        [HttpGet]
        [Route("GetRatingTypes")]
        public async Task<List<RatingTypeDto>> GetRatingTypesAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new List<RatingTypeDto>();

            try
            {
                _logger?.LogInformation("The GetRatingTypesAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetRatingTypesAsync();

                response = _mapper.Map<List<RatingTypeDto>>(serviceResponse);

                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new List<RatingTypeDto> { new RatingTypeDto { ErrorMessage = new string[] { ex.Message } } };
            }
        }

        [HttpGet]
        [Route("GetSongs")]
        public async Task<List<SongDto>> GetSongsAsync()
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new List<SongDto>();

            try
            {
                _logger?.LogInformation("The GetSongsAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetSongsAsync();

                response = _mapper.Map<List<SongDto>>(serviceResponse);

                return response;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new List<SongDto> { new SongDto { ErrorMessage = new string[] { ex.Message } } };
            }
        }

        #endregion

        #region << GET BY ID >>

        // api/albums/GetAlbums/{id}
        [HttpGet("{id}")]
        [Route("GetAlbums/{id}")]
        public async Task<AlbumDto> GetAlbumByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumDto();

            try
            {
                _logger?.LogInformation("The GetAlbumByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetAlbumByIdAsync(id);

                var result = _mapper.Map<AlbumDto>(serviceResponse);

                result.TotalVotes = result.AlbumRating.Count();
                result.TotalRating = 0;

                if (result.TotalVotes > 0)
                {
                    int sumRatingValue = 0;
                    foreach (var albumRating in result.AlbumRating)
                        sumRatingValue += albumRating.RatingType.Value;

                    result.TotalRating = (decimal)sumRatingValue / (decimal)result.TotalVotes;
                }
                
                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new AlbumDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        [HttpGet("{id}")]
        [Route("GetArtists/{id}")]
        public async Task<ArtistDto> GetArtistByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new ArtistDto();

            try
            {
                _logger?.LogInformation("The GetArtistByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetArtistByIdAsync(id);

                return _mapper.Map<ArtistDto>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new ArtistDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        [HttpGet("{id}")]
        [Route("GetMusicTypes/{id}")]
        public async Task<MusicTypeDto> GetMusicTypeByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new MusicTypeDto();

            try
            {
                _logger?.LogInformation("The GetMusicTypeByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetMusicTypeByIdAsync(id);

                return _mapper.Map<MusicTypeDto>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new MusicTypeDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        [HttpGet("{id}")]
        [Route("GetRatingTypes/{id}")]
        public async Task<RatingTypeDto> GetRatingTypeByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new RatingTypeDto();

            try
            {
                _logger?.LogInformation("The GetRatingTypeByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetRatingTypeByIdAsync(id);

                return _mapper.Map<RatingTypeDto>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new RatingTypeDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        [HttpGet("{id}")]
        [Route("GetSongs/{id}")]
        public async Task<SongDto> GetSongByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new SongDto();

            try
            {
                _logger?.LogInformation("The GetSongByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetSongByIdAsync(id);

                return _mapper.Map<SongDto>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new SongDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        [HttpGet("{id}")]
        [Route("GetAlbumRatings/{id}")]
        public async Task<AlbumRatingDto> GetAlbumRatingByIdAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumRatingDto();

            try
            {
                _logger?.LogInformation("The GetAlbumRatingByIdAsync have been retrieved successfully.");

                var serviceResponse = await _albumRepository.GetAlbumRatingByIdAsync(id);

                return _mapper.Map<AlbumRatingDto>(serviceResponse);
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return response = new AlbumRatingDto { ErrorMessage = new string[] { ex.Message } };
            }
        }

        #endregion

        #region << GET - SEARCHER >>



        #endregion

        #region << CREATE - POST >>

        [HttpPost]
        [Route("CreateAlbum")]
        public async Task<AlbumDto> CreateAlbumAsync([FromBody]AlbumDto albumDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateAlbumAsync have been retrieved successfully.");

                    var album = await _albumRepository.CreateAlbumAsync(_mapper.Map<Album>(albumDto));

                    return _mapper.Map<AlbumDto>(album);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new AlbumDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new AlbumDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPost]
        [Route("CreateArtist")]
        public async Task<ArtistDto> CreateArtistAsync([FromBody]ArtistDto artistDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new ArtistDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateArtistAsync have been retrieved successfully.");

                    var artist = await _albumRepository.CreateArtistAsync(_mapper.Map<Artist>(artistDto));

                    return _mapper.Map<ArtistDto>(artist);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new ArtistDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new ArtistDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPost]
        [Route("CreateMusicType")]
        public async Task<MusicTypeDto> CreateMusicTypeAsync([FromBody]MusicTypeDto musicTypeDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new MusicTypeDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateMusicTypeAsync have been retrieved successfully.");

                    var musicType = await _albumRepository.CreateMusicTypeAsync(_mapper.Map<MusicType>(musicTypeDto));

                    return _mapper.Map<MusicTypeDto>(musicType);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new MusicTypeDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new MusicTypeDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPost]
        [Route("CreateRatingType")]
        public async Task<RatingTypeDto> CreateRatingTypeAsync([FromBody]RatingTypeDto ratingTypeDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new RatingTypeDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateRatingTypeAsync have been retrieved successfully.");

                    var ratingType = await _albumRepository.CreateRatingTypeAsync(_mapper.Map<RatingType>(ratingTypeDto));

                    return _mapper.Map<RatingTypeDto>(ratingType);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new RatingTypeDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new RatingTypeDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPost]
        [Route("CreateSong")]
        public async Task<SongDto> CreateSongAsync([FromBody]SongDto songDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new SongDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateSongAsync have been retrieved successfully.");

                    var song = await _albumRepository.CreateSongAsync(_mapper.Map<Song>(songDto));

                    return _mapper.Map<SongDto>(song);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new SongDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new SongDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPost]
        [Route("CreateAlbumRating")]
        public async Task<AlbumRatingDto> CreateAlbumRatingAsync([FromBody]AlbumRatingDto albumRatingDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumRatingDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The CreateAlbumRatingAsync have been retrieved successfully.");

                    var albumRating = await _albumRepository.CreateAlbumRatingAsync(_mapper.Map<AlbumRating>(albumRatingDto));

                    return _mapper.Map<AlbumRatingDto>(albumRating);
                }

                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new AlbumRatingDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new AlbumRatingDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        #endregion

        #region << UPDATE - PUT >>

        [HttpPut("{id}")]
        [Route("UpdateAlbum/{id}")]
        public async Task<AlbumDto> UpdateAlbumAsync(Guid id, [FromBody]AlbumDto albumDto)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new AlbumDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The UpdateAlbumAsync have been retrieved successfully.");

                    var album = await _albumRepository.UpdateAlbumAsync(_mapper.Map<Album>(albumDto));

                    return _mapper.Map<AlbumDto>(album);
                }
                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new AlbumDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new AlbumDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        [HttpPut("{id}")]
        [Route("IncreaseSongPopularity/{id}")]
        public async Task<SongDto> IncreaseSongPopularityAsync(Guid id)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            var response = new SongDto();

            if (ModelState.IsValid)
            {
                try
                {
                    _logger?.LogInformation("The IncreaseSongPopularityAsync have been retrieved successfully.");

                    var song = await _albumRepository.IncreaseSongPopularityAsync(id);

                    return _mapper.Map<SongDto>(song);
                }
                catch (Exception ex)
                {
                    _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                    return response = new SongDto { ErrorMessage = new string[] { ex.Message } };
                }
            }
            else
                return response = new SongDto { ErrorMessage = new string[] { "ModelState is not valid: " + ModelState.ToString() } };
        }

        #endregion

        #region << DELETE >>

        [HttpDelete]
        [Route("DeleteAlbum")]
        public async Task<bool> DeleteAlbumAsync(Guid albumId)
        {
            _logger?.LogDebug("'{0}' has been invoked", MethodBase.GetCurrentMethod().DeclaringType);
            bool result = false;

            try
            {
                _logger?.LogInformation("The DeleteAlbumAsync have been retrieved successfully.");

                result = await _albumRepository.DeleteAlbumAsync(albumId);

                return result;
            }
            catch (Exception ex)
            {
                _logger?.LogCritical("There was an error on '{0}' invocation: {1}", MethodBase.GetCurrentMethod().DeclaringType, ex);
                return false;
            }
        }

        #endregion

    }
}