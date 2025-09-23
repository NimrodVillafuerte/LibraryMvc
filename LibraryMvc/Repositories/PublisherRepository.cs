using LibraryMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly LibraryDbContext _context;
        public PublisherRepository(LibraryDbContext context) => _context = context;

        public async Task<IEnumerable<Publisher>> GetAllAsync() =>
            await _context.Publishers.ToListAsync();

        public async Task<Publisher?> GetByIdAsync(int id) =>
            await _context.Publishers.FindAsync(id);

        public async Task AddAsync(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Publisher publisher)
        {
            _context.Entry(publisher).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Publishers.AnyAsync(p => p.PublisherID == id);
    }
}

