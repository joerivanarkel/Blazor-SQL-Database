namespace Business.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        void CreateAsync(T entity);
        void Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        void Update(T entity);
    }
}