using AutoMapper;
using Music.Data.Entities;
using Music.Dto.Song;

namespace Music.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, SongDto>()
                .ForMember(dest => dest.Genre, act => act.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Artist, act => act.MapFrom(src => src.Artist.Name));

            CreateMap<SongDto, Song>();
            CreateMap<AddSongDto, Song>();
            CreateMap<UpdateSongDto, Song>();
        }
    }
}