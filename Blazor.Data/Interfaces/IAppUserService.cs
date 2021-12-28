﻿using Blazor.Data.Models;
using Blazor.Data.Responses;
using Blazor.Models.Identity;

namespace Blazor.Data.Interfaces
{
    public interface IAppUserService
    {
        Task<AppUserResponse> GetUserRoleAsync(AppUser user);
        AppUserResponse GetUserById(int id);
        AppUserResponse GetUserByEmail(string email);
        Task<AppUser> FindUserByIdAsync(int userId);
        Task<AppUser> FindUserByEmailAsync(string email);
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);
        Task<RequestResponse> DeleteUserAsync(int userId);
    }
}
