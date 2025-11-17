using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Models.ViewModels;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Controllers
{
    [Route("medico")]
    public class MedicoController : Controller
    {
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /medico
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var medicos = await _context.Medicos
                .Include(m => m.Usuario)
                .Select(m => new MedicoListaViewModel
                {
                    Id = m.Id,
                    CRM = m.CRM,
                    Especialidade = m.Especialidade,
                    Nome = m.Usuario.Nome,
                    Email = m.Usuario.Email
                })
                .ToListAsync();

            return View(medicos);
        }

        // GET: /medico/campanhas
        [HttpGet("campanhas")]
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
