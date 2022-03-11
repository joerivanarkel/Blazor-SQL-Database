namespace Business.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        void Create(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void NewDbContext();
    }
}