using LibraryMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;
        public BookRepository(LibraryDbContext context) => _context = context;

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthor).ThenInclude(ba => ba.Author)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthor).ThenInclude(ba => ba.Author)
                .FirstOrDefaultAsync(b => b.BookID == id);
        }

        public async Task AddAsync(Book book, List<int> authorIds)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            foreach (var authorId in authorIds)
                _context.BookAuthors.Add(new BookAuthor { BookID = book.BookID, AuthorID = authorId });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book, List<int> authorIds)
        {
            _context.Entry(book).State = EntityState.Modified;

            var existing = _context.BookAuthors.Where(ba => ba.BookID == book.BookID);
            _context.BookAuthors.RemoveRange(existing);

            foreach (var authorId in authorIds)
                _context.BookAuthors.Add(new BookAuthor { BookID = book.BookID, AuthorID = authorId });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.BookAuthors.RemoveRange(_context.BookAuthors.Where(ba => ba.BookID == id));
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) => await _context.Books.AnyAsync(e => e.BookID == id);
    }
}
