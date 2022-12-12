using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Dtos.BoardDtos;

namespace WebAPI.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile() {
            CreateMap<Board, BoardGetDto>();
            CreateMap<BoardPostPutDto, Board>();
        }
    }
}
