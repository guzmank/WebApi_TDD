using AutoMapper;
using Data.Entities;
using Domain.Models;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();

            CreateMap<AlbumRating, AlbumRatingDto>();
            CreateMap<AlbumRatingDto, AlbumRating>();

            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();

            CreateMap<MusicType, MusicTypeDto>();
            CreateMap<MusicTypeDto, MusicType>();

            CreateMap<RatingType, RatingTypeDto>();
            CreateMap<RatingTypeDto, RatingType>();

            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();

            CreateMap<SongPrice, SongPriceDto>();
            CreateMap<SongPriceDto, SongPrice>();

            CreateMap<AlbumPrice, AlbumPriceDto>();
            CreateMap<AlbumPriceDto, AlbumPrice>();
        }
    }
}
