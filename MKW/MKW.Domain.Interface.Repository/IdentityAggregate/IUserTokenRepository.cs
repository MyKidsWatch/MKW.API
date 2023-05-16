using FluentResults;
using Microsoft.EntityFrameworkCore;
using MKW.Domain.Entities.IdentityAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserTokenRepository
    {
        Task<(Result result, UserToken? userToken)> GetUserTokenAsync(int userID, int keycode);
        Task<(Result result, int? keycode)> AddUserTokenAsync(int userID, string token);
        Task<Result> DeleteUserTokenAsync(int userID, int keycode);
    }
}
