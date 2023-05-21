using FluentResults;
using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Domain.Interface.Repository.IdentityAggregate
{
    public interface IUserTokenRepository
    {
        Task<(Result result, UserToken? userToken)> GetUserTokenAsync(int userID, int keycode);
        Task<(Result result, int? keycode)> AddUserTokenAsync(int userID, string token);
        Task<Result> DeleteUserTokenAsync(int userID, int keycode);
    }
}
