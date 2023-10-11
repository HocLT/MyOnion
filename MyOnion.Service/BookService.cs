using MyOnion.Domain;
using MyOnion.Repository;


namespace MyOnion.Service
{
    public class BookService: IBookService
    {
        IBookRepository repo;

        public BookService(IBookRepository repo)
        {
            this.repo = repo;
        }

        public async Task<List<BookDto>> FindAll()
        {
            List<Book> result = await repo.FindAll();
            return result.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Price = b.Price != null ? b.Price.Value : 0,
            }).ToList();
        }

        public async Task<BookDto?> FindById(int id)
        {
            Book? result = await repo.FindById(id);
            if (result != null)
            {
                return new BookDto
                {
                    Id = result.Id,
                    Title = result.Title,
                    Price = result.Price != null ? result.Price.Value : 0,
                };
            }
            return null;
        }

        public async Task<int> Create(BookDto dto)
        {
            Book b = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price
            };
            return await repo.Create(b);
        }
    }
}
