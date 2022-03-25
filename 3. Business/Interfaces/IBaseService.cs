namespace Business.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        bool Create(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        void NewDbContext();
    }
}