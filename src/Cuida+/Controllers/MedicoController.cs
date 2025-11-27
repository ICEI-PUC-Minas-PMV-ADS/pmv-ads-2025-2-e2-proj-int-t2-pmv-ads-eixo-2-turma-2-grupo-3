using Cuida_.Models;
using Cuida_.Models.Usuarios;
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

        /*[HttpGet("")]
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
        }*/

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

        [HttpGet("horariosMarcados")]
        public async Task<IActionResult> horariosMarcados()
        {
            var consultas = await _context.Consultas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToListAsync();

            return View("horariosMarcadosMedico", consultas);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Consulta consultaAtualizada)
        {
            var consulta = await _context.Consultas.FindAsync(consultaAtualizada.IdConsulta);

            if (consulta == null)
            {
                TempData["ErrorMessage"] = "Consulta não encontrada.";
                return RedirectToAction("horariosMarcados");
            }

            consulta.Data = consultaAtualizada.Data;

            consulta.Horario = consultaAtualizada.Data.Date
                .AddHours(consultaAtualizada.Horario.Hour)
                .AddMinutes(consultaAtualizada.Horario.Minute);

            try
            {
                _context.Update(consulta);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Horário atualizado com sucesso!";
            }
            catch
            {
                TempData["ErrorMessage"] = "Erro ao atualizar horário.";
            }

            return RedirectToAction("horariosMarcados");
        }
    }
}
