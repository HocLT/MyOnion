using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnion.Service
{
    public interface IBookService
    {
        Task<List<BookDto>> FindAll();

        Task<BookDto?> FindById(int id);

        Task<int> Create(BookDto dto);
    }
}
