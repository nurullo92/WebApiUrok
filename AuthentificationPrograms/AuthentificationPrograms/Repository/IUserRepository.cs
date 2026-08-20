using AuthentificationPrograms.Models;

namespace AuthentificationPrograms.Repository
{
    public interface IUserRepository
    {
         User GetByLogin(string Loggin);
        IEnumerable<User> GetAll();

    }
}
