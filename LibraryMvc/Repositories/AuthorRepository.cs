﻿using LibraryMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _context;
        public AuthorRepository(LibraryDbContext context) => _context = context;

        public async Task<IEnumerable<Author>> GetAllAsync() =>
            await _context.Authors.ToListAsync();

        public async Task<Author?> GetByIdAsync(int id) =>
            await _context.Authors.FindAsync(id);

        public async Task AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Authors.AnyAsync(a => a.AuthorID == id);
    }
}
