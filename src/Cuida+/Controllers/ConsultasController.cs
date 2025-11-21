using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Cuida_.Models;
using Cuida_.Repository;

namespace Cuida_.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly AppDbContext _context;

        public ConsultasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Paciente"))
            {
                var lista = await _context.Consultas
                    .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                    .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                    .Where(c => c.Paciente.Usuario.Email == email)
                    .ToListAsync();

                return View(lista);
            }

            if (User.IsInRole("Medico"))
            {
                var lista = await _context.Consultas
                    .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                    .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                    .Where(c => c.Medico.Usuario.Email == email)
                    .ToListAsync();

                return View(lista);
            }

            if (User.IsInRole("Clinica"))
            {
                var lista = await _context.Consultas
                    .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                    .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                    .ToListAsync();

                return View(lista);
            }

            var geral = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .ToListAsync();

            return View(geral);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var consulta = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null) return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Paciente") && consulta.Paciente.Usuario.Email != email)
                return Unauthorized();

            if (User.IsInRole("Medico") && consulta.Medico.Usuario.Email != email)
                return Unauthorized();

            return View(consulta);
        }

        [Authorize(Roles = "Paciente")]
        public IActionResult Create()
        {
            ViewBag.PacienteId = new SelectList(_context.Pacientes, "Id", "Cpf");
            ViewBag.MedicoId = new SelectList(_context.Medicos, "Id", "Crm");
            return View();
        }

        [Authorize(Roles = "Paciente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,PacienteId,MedicoId,Data,Horario")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                bool medicoOcupado = await _context.Consultas
                    .AnyAsync(c => c.MedicoId == consulta.MedicoId &&
                                   c.Data == consulta.Data &&
                                   c.Horario == consulta.Horario);

                if (medicoOcupado)
                {
                    ModelState.AddModelError("", "O médico já possui consulta neste horário.");
                    return View(consulta);
                }

                bool pacienteOcupado = await _context.Consultas
                    .AnyAsync(c => c.PacienteId == consulta.PacienteId &&
                                   c.Data == consulta.Data &&
                                   c.Horario == consulta.Horario);

                if (pacienteOcupado)
                {
                    ModelState.AddModelError("", "O paciente já possui uma consulta neste horário.");
                    return View(consulta);
                }

                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "CRM", consulta.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CPF", consulta.PacienteId);

            return View(consulta);
        }

        [Authorize(Roles = "Medico,Clinica,Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var consulta = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null) return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Medico") && consulta.Medico.Usuario.Email != email)
                return Unauthorized();

            ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "CRM", consulta.MedicoId);
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "CPF", consulta.PacienteId);

            return View(consulta);
        }

        [Authorize(Roles = "Medico,Clinica,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,Data,Horario")] Consulta dadosEditados)
        {
            var consulta = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null) return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Medico") && consulta.Medico.Usuario.Email != email)
                return Unauthorized();

            bool medicoOcupado = await _context.Consultas
                .AnyAsync(c => c.MedicoId == consulta.MedicoId &&
                               c.Data == dadosEditados.Data &&
                               c.Horario == dadosEditados.Horario &&
                               c.IdConsulta != consulta.IdConsulta);

            if (medicoOcupado)
            {
                ModelState.AddModelError("", "O médico já possui consulta neste novo horário.");
                return View(consulta);
            }

            bool pacienteOcupado = await _context.Consultas
                .AnyAsync(c => c.PacienteId == consulta.PacienteId &&
                               c.Data == dadosEditados.Data &&
                               c.Horario == dadosEditados.Horario &&
                               c.IdConsulta != consulta.IdConsulta);

            if (pacienteOcupado)
            {
                ModelState.AddModelError("", "O paciente já possui consulta neste novo horário.");
                return View(consulta);
            }

            consulta.Data = dadosEditados.Data;
            consulta.Horario = dadosEditados.Horario;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Paciente,Medico,Clinica,Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var consulta = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null) return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Paciente") && consulta.Paciente.Usuario.Email != email)
                return Unauthorized();

            if (User.IsInRole("Medico") && consulta.Medico.Usuario.Email != email)
                return Unauthorized();

            return View(consulta);
        }

        [Authorize(Roles = "Paciente,Medico,Clinica,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas
                .Include(c => c.Medico).ThenInclude(m => m.Usuario)
                .Include(c => c.Paciente).ThenInclude(p => p.Usuario)
                .FirstOrDefaultAsync(c => c.IdConsulta == id);

            if (consulta == null) return NotFound();

            var email = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Paciente") && consulta.Paciente.Usuario.Email != email)
                return Unauthorized();

            if (User.IsInRole("Medico") && consulta.Medico.Usuario.Email != email)
                return Unauthorized();

            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Agendar()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AgendarView()
        {
            var dias = GetProximosDiasUteis(10);

            var horarios = new List<TimeSpan>
            {
                new TimeSpan(9,0,0),
                new TimeSpan(10,0,0),
                new TimeSpan(11,0,0),
                new TimeSpan(13,0,0),
                new TimeSpan(14,0,0),
                new TimeSpan(15,0,0),
                new TimeSpan(16,0,0),
                new TimeSpan(17,0,0)
            };

            var ocupados = await _context.Consultas
                .Select(c => c.Horario)
                .ToListAsync();

            var model = new AgendarViewModel
            {
                Dias = dias,
                Horarios = horarios,
                SlotsOcupados = ocupados
            };

            return View("Agendar", model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarAgendamento(ConfirmarAgendamentoDto dto)
        {
            var paciente = await _context.Pacientes.Include(p => p.Usuario)
                .FirstOrDefaultAsync(p => p.Usuario.Email == User.FindFirstValue(ClaimTypes.Email));

            if (paciente == null) return Unauthorized();

            if (dto.Horario <= DateTime.Now) return BadRequest();

            bool medicoOcupado = await _context.Consultas
                .AnyAsync(c => c.Horario == dto.Horario && c.MedicoId == 0);

            if (medicoOcupado) return Conflict();

            bool pacienteOcupado = await _context.Consultas
                .AnyAsync(c => c.Horario == dto.Horario && c.PacienteId == paciente.Id);

            if (pacienteOcupado) return Conflict();

            var consulta = new Consulta
            {
                PacienteId = paciente.Id,
                MedicoId = 1,
                Data = dto.Horario.Date,
                Horario = dto.Horario
            };

            _context.Consultas.Add(consulta);
            await _context.SaveChangesAsync();

            TempData["SucessoAgendamento"] = true;
            return RedirectToAction("AgendarView");
        }

        private List<DateTime> GetProximosDiasUteis(int quantidade)
        {
            var dias = new List<DateTime>();
            var atual = DateTime.Today;
            var limite = atual.AddDays(14);

            while (dias.Count < quantidade && atual <= limite)
            {
                if (atual.DayOfWeek != DayOfWeek.Saturday &&
                    atual.DayOfWeek != DayOfWeek.Sunday)
                {
                    dias.Add(atual);
                }

                atual = atual.AddDays(1);
            }

            return dias;
        }
    }
}
