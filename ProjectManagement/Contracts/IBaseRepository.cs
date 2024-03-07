namespace ProjectManagement.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> DeleteAllAsync();
        Task<bool> Exist(int id);
    }
}
