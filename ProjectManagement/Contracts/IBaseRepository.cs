namespace ProjectManagement.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
    }
}
