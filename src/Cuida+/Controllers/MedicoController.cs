using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return View(medicos);
        }

        [HttpGet("medico")]
        public async Task<IActionResult> CampanhasDisponiveis()
        {
            var campanhas = await _context.Campanhas
               .Select(c => new Campanha
               {
                   Id = c.Id,
                   NomeCampanha = c.NomeCampanha,
                   DataInicio = c.DataInicio,
                   DataFim = c.DataFim,
                   Ativa = c.Ativa,
               })
               .ToListAsync();

            return View("CampanhasDisponiveis", campanhas);
        }
    }
}
