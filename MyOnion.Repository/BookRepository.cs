using Microsoft.EntityFrameworkCore;
using MyOnion.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnion.Repository
{
    public class BookRepository: IBookRepository
    {
        BookDbContext ctx;

        public BookRepository(BookDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<Book>> FindAll()
        {
            return await ctx.Books!.ToListAsync();
        }

        public async Task<Book?> FindById(int id)
        {
            return await ctx.Books!.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<int> Create(Book b)
        {
            ctx.Books!.Add(b);
            await ctx.SaveChangesAsync();
            return b.Id;
        }

        public async Task<bool> Update(Book b)
        {
            ctx.Entry(b).State = EntityState.Modified;
            int result = await ctx.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var b = await ctx.Books!.SingleOrDefaultAsync(b => b.Id == id);
            int result = 0;
            if (b != null)
            {
                ctx.Books!.Remove(b);
                result = await ctx.SaveChangesAsync();
            }
            return result > 0;
        }
    }
}
