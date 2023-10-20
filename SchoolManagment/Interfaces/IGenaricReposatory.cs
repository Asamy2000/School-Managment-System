namespace SchoolManagment.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD operations Signature any repo Implement IGenericRepository must have functions with the following signature
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
