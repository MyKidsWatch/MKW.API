using FluentResults;
using Microsoft.EntityFrameworkCore;
using MKW.Data.Context;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Interface.Repository.IdentityAggregate;
using System.Security.Cryptography;

namespace MKW.Data.Repository.IdentityAggregate
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly MKWContext _context;
        protected readonly DbSet<UserToken> _dbSet;
        public UserTokenRepository(MKWContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserToken>();
        }

        public async Task<(Result, UserToken?)> GetUserTokenAsync(int userID, int keycode)
        {
            var userToken = _dbSet.Where(userToken => userToken.UserId == userID && userToken.KeyCode == keycode).FirstOrDefault();
            if (userToken is not null)
            {
                return (Result.Ok(), userToken);
            }
            else
            {
                return (Result.Fail("invalid key"), null);
            }
        }

        public async Task<(Result, int?)> AddUserTokenAsync(int userID, string token)
        {
            var userToken = new UserToken()
            {
                UserId = userID,
                KeyCode = GenerateKeyCode(),
                Token = token
            };

            var tokensDb = _dbSet.Where(t => t.UserId == userID).ToList();
            _dbSet.RemoveRange(tokensDb);

            var addResult = _dbSet.Add(userToken).Entity;
            if (addResult is not null)
            {
                await _context.SaveChangesAsync();
                return (Result.Ok(), addResult.KeyCode);
            }
            return (Result.Ok(), null);
        }

        public async Task<Result> DeleteUserTokenAsync(int userID, int keycode)
        {
            var userToken = _dbSet.Where(userToken => userToken.UserId == userID && userToken.KeyCode == keycode).FirstOrDefault();
            if (userToken is not null)
            {
                var deleteToken = _dbSet.Remove(userToken);
                var result = await _context.SaveChangesAsync();
                return Result.Ok();
            }
            else
            {
                return Result.Fail("invalid key");
            }
        }

        private int GenerateKeyCode()
        {
            string timestamp = DateTime.Now.Ticks.ToString();
            string keycode = timestamp.Substring(timestamp.Length - 6, 6);
            if (keycode.Length != 6) keycode.PadRight(6, char.Parse(RandomNumberGenerator.GetInt32(1, 9).ToString()));
            return int.Parse(keycode);
        }
    }
}
