using AutoMapper;
using LibraryMvc.DTOs;
using LibraryMvc.Models;
using LibraryMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _repo.GetAllAsync();
            var dtoList = _mapper.Map<List<BookReadDto>>(books);
            return View(dtoList);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return NotFound();
            var dto = _mapper.Map<BookReadDto>(book);
            return View(dto);
        }

        // GET: Books/Create
        public IActionResult Create() => View();

        // POST: Books/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var book = _mapper.Map<Book>(dto);
            await _repo.AddAsync(book, dto.AuthorIds);
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return NotFound();

            var dto = _mapper.Map<BookUpdateDto>(book);
            dto.AuthorIds = book.BookAuthor?.Select(ba => ba.AuthorID).ToList() ?? new List<int>();
            return View(dto);
        }

        // POST: Books/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookUpdateDto dto)
        {
            if (id != dto.BookID) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            var book = _mapper.Map<Book>(dto);
            await _repo.UpdateAsync(book, dto.AuthorIds);
            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _repo.GetByIdAsync(id);
            if (book == null) return NotFound();

            var dto = _mapper.Map<BookReadDto>(book);
            return View(dto);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

