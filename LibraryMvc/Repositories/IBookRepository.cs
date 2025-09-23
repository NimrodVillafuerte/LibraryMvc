using LibraryMvc.Models;

namespace LibraryMvc.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book, List<int> authorIds);
        Task UpdateAsync(Book book, List<int> authorIds);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
