using MyOnion.Domain;

namespace MyOnion.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> FindAll();

        Task<Book?> FindById(int id);

        Task<int> Create(Book b);

        Task<bool> Update(Book b);

        Task<bool> Delete(int id);
    }
}
