using Newtonsoft.Json;
using System.Threading.Tasks;
using Authentication.API.Entities;
using Authentication.API.Repositories.Base;
using Microsoft.Extensions.Caching.Distributed;

namespace Authentication.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDistributedCache _redisCache;

        public UserRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<User> GetUser(string userName)
        {
            var user = await _redisCache.GetStringAsync(userName);

            if (string.IsNullOrEmpty(user))
            {
                //In order not to create an extra microservice for the app users, we are creating a dummy user here as if it is already a registered user on our database. This code block should return null on normal scenarios
                return new User()
                {
                    ID = 1,
                    UserName = "Razz",
                    Password = "hqkb;T90"
                };

                //return null;
            }

            return JsonConvert.DeserializeObject<User>(user);
        }
    }
}