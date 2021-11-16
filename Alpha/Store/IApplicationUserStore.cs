namespace Alpha.Store
{
    public interface IApplicationUserStore
    {
        Task<ApplicationUser?> Get(int key);
        Task Create(ApplicationUser obj);
        Task Delete(int key);
        Task<IEnumerable<ApplicationUser>> GetAll();
        Task<ApplicationUser?> FindByUsernameAsync(string username);
    }
}
