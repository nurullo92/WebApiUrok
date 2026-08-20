using AuthentificationPrograms.Models;


namespace AuthentificationPrograms.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _user = new List<User>();
        public UserRepository()
        {
            _user.Add(new User
            {
                Loggin = "admin",
                FirstName = "Иван",
                LastName = "Иванов",
                Password = "1111",
                Email = "admin@gmail.com",
                Role = new Role
                {
                    Id = 1,
                    Name = "Администратор"
                }
            });
            _user.Add(new User
            {
                Loggin = "adnreis",
                FirstName = "Анрей",
                LastName = "Иванов",
                Password = "1112",
                Email = "admin@gmail.com",
                Role = new Role
                {
                    Id = 2,
                    Name = "Пользователь"
                }
            });
        }

        public IEnumerable<User> GetAll()
        {
            return _user;
        }

        public User GetByLogin(string login)
        {
            return _user.FirstOrDefault(l => l.Loggin == login);
   
        }

    }
}