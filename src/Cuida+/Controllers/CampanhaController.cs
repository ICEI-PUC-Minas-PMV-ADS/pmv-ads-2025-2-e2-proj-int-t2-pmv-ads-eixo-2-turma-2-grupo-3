using Cuida_.Models.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cuida_.Models.campanhas;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cuida_.Controllers
{
    public class CampanhaController : Controller
    {
        private readonly AppDbContext _context;

        public CampanhaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        { 
            var dados = await _context.Campanhas.ToListAsync();

            return View(dados);
        }
        public IActionResult Create()
        {
           var clinicasMock = new List<SelectListItem>
           {
              new SelectListItem { Value = "1", Text = "Clinica Teste" }
            };
              ViewBag.Clinicas = clinicasMock;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Campanha campanha)
        {
            if (ModelState.IsValid)
            { 
                _context.Campanhas.Add(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var clinicasMock = new List<SelectListItem>
           {
              new SelectListItem { Value = "1", Text = "Clinica Teste" }
            };
            ViewBag.Clinicas = clinicasMock;
            
            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if(dados == null)
                return NotFound();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Campanha campanha)
        {
            if (id != campanha.Id)
                return NotFound();
            
            if (ModelState.IsValid)
            {
                _context.Campanhas.Update(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(campanha);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)

        {
            if(id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if(dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost,ActionName("Delete")]    
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if (dados == null)
                return NotFound();

            _context.Campanhas.Remove(dados);
            await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }
    }
}
