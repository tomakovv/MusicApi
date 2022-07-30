using AutoMapper;
using Music.Data.Entities;
using Music.Dto.Album;
using Music.Dto.Artist;
using Music.Dto.Genre;
using Music.Dto.Playlist;
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
            CreateMap<PlaylistDto, Playlist>();
            CreateMap<AddPlaylistDto, Playlist>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name));
            CreateMap<Playlist, PlaylistDto>();
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();
            CreateMap<AlbumWithSongsDto, Album>();
            CreateMap<Album, AddAlbumDto>();
            CreateMap<AddAlbumDto, Album>();
            CreateMap<EditAlbumDto, Album>();
            CreateMap<Album, EditAlbumDto>();
            CreateMap<Album, AlbumWithSongsDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
            CreateMap<GenreWithSongsDto, Genre>();
            CreateMap<Genre, GenreWithSongsDto>();
            CreateMap<Genre, AddGenreDto>();
            CreateMap<AddGenreDto, Genre>();
            CreateMap<EditGenreDto, Genre>();
            CreateMap<Genre, EditGenreDto>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();
        }
    }
}