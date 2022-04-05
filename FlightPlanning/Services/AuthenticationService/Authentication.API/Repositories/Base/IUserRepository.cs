using System.Threading.Tasks;
using Authentication.API.Entities;

namespace Authentication.API.Repositories.Base
{
    public interface IUserRepository
    {
        Task<User> GetUser(string userName);
    }
}