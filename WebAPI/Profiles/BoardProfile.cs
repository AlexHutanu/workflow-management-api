﻿using AutoMapper;
using Domain.Entities;
using WebAPI.Models.Board;

namespace WebAPI.Profiles
{
    public class BoardProfile : Profile
    {
        public BoardProfile() {
            CreateMap<BoardEntity, ReadBoardModel>();
            CreateMap<WriteBoardModel, BoardEntity>();
        }
    }
}
