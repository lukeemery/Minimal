namespace Alpha.Store
{
    public class ApplicationUserStore : IApplicationUserStore
    {
        private static IEnumerable<ApplicationUser> _users = new List<ApplicationUser>
        {
            new ()
            {
                Username = "admin",
                Password = "password"
            }
        };

        public Task Create(ApplicationUser obj)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> FindByUsernameAsync(string username)
        {
            var user = _users.FirstOrDefault(x => x.Username == username);
            return Task.FromResult(user);
        }

        public Task<ApplicationUser?> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
