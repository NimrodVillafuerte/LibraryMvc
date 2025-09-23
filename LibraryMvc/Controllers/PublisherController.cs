using AutoMapper;
using LibraryMvc.DTOs;
using LibraryMvc.Models;
using LibraryMvc.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherRepository _repo;
        private readonly IMapper _mapper;

        public PublishersController(IPublisherRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var publishers = await _repo.GetAllAsync();
            return View(_mapper.Map<List<PublisherReadDto>>(publishers));
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublisherCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var publisher = _mapper.Map<Publisher>(dto);
            await _repo.AddAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publisher = await _repo.GetByIdAsync(id);
            if (publisher == null) return NotFound();

            return View(_mapper.Map<PublisherUpdateDto>(publisher));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PublisherUpdateDto dto)
        {
            if (id != dto.PublisherID) return NotFound();
            if (!ModelState.IsValid) return View(dto);

            var publisher = _mapper.Map<Publisher>(dto);
            await _repo.UpdateAsync(publisher);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _repo.GetByIdAsync(id);
            if (publisher == null) return NotFound();

            return View(_mapper.Map<PublisherReadDto>(publisher));
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

