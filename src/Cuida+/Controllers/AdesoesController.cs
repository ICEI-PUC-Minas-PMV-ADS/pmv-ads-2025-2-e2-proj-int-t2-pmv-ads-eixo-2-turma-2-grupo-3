using Cuida_.Models.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

                    
        
        
    
namespace Cuida_.Controllers
{
    public class AderirCampanhasController : Controller

    {
        private readonly AppDbContext _context;
        public AderirCampanhasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.AderirCampanhas.ToListAsync();
            return View(dados);
        }
    }
}