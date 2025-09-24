using AutoMapper;
using LibraryMvc.DTOs;
using LibraryMvc.Models;
using LibraryMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository _repo;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetAllAsync();
            return View(_mapper.Map<List<AuthorReadDto>>(authors));
        }

        public async Task<IActionResult> Details(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();

            var dto = _mapper.Map<AuthorReadDto>(author);
            return View(dto);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AuthorCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var author = _mapper.Map<Author>(dto);
            await _repo.AddAsync(author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();

            return View(_mapper.Map<AuthorUpdateDto>(author));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AuthorUpdateDto dto)
        {
            if (id != dto.AuthorID) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            var author = _mapper.Map<Author>(dto);
            await _repo.UpdateAsync(author);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound();

            return View(_mapper.Map<AuthorReadDto>(author));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

