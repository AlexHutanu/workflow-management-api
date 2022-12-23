using AutoMapper;
using Infrastructure.Entities;
using WebAPI.Models.Board;

namespace WebAPI.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile() {
            CreateMap<Board, ReadBoardModel>();
            CreateMap<WriteBoardModel, Board>();
        }
    }
}
