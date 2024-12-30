﻿using Domain;
using Domain.Dto;

namespace Service
{
    public interface IUserService
    {
        Guid CreateUser(ProfileDto profileDto);
        Profile GetUser(Guid id);
    }
}
