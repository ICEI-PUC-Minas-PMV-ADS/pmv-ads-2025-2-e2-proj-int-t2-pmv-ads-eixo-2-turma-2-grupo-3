using Cuida_.Models;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Controllers
{
    public class PacienteController : Controller
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("paciente/horariosMarcados")]
        public async Task<IActionResult> horariosMarcados()
        {
            var consultas = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();

            return View("horariosMarcadosPaciente", consultas);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var consulta = await _context.Consultas.FindAsync(id);

            if (consulta == null)
            {
                TempData["ErrorMessage"] = "Consulta não encontrada.";
                return RedirectToAction("horariosMarcados");
            }

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Consulta cancelada com sucesso!";

            return RedirectToAction("horariosMarcados");
        }
    }
}
