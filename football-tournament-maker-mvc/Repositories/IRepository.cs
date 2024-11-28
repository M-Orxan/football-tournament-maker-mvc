using football_tournament_maker_mvc.Models;

namespace football_tournament_maker_mvc.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
       
        Task DeleteAsync(int id);
        Task<bool> ExistsByNameAsync(string name);
    }
}
