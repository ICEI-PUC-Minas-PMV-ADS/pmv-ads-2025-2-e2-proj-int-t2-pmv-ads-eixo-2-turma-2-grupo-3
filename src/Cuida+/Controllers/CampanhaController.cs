using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cuida_.Repository;
using Cuida_.Models;
using Cuida_.Models.Usuarios;
using System.Security.Claims;

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
            var dados = await _context.Campanhas
                .Include(c => c.Clinica)
                .Include(c => c.Medicos)
                .ToListAsync();

            var usuario = await GetCurrentUsuarioAsync();
            var isClinica = usuario != null && usuario.TipoRegistro?.ToLower() == "clinica";
            var isMedico = false;
            int currentMedicoId = 0;

            if (usuario != null)
            {
                var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.UsuarioId == usuario.Id);
                if (medico != null)
                {
                    isMedico = true;
                    currentMedicoId = medico.Id;
                }
            }

            ViewBag.CanCreate = isClinica;
            ViewBag.IsMedico = isMedico;
            ViewBag.CurrentMedicoId = currentMedicoId;

            return View(dados);
        }

        public async Task<IActionResult> Create()
        {
           var usuario = await GetCurrentUsuarioAsync();
           if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
               return Forbid();

           var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuario.Id);
           if (clinica == null)
               return Forbid();

           ViewBag.Clinicas = new List<SelectListItem>
           {
              new SelectListItem { Value = clinica.Id.ToString(), Text = clinica.NomeClinica, Selected = true }
           };

           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Campanha campanha)
        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
                return Forbid();

            var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuario.Id);
            if (clinica == null)
                return Forbid();

            campanha.ClinicaId = clinica.Id;

            if (ModelState.IsValid)
            { 
                _context.Campanhas.Add(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Clinicas = new List<SelectListItem>
           {
              new SelectListItem { Value = clinica.Id.ToString(), Text = clinica.NomeClinica, Selected = true }
           };

            return View(campanha);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
                return Forbid();

            var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuario.Id);
            if (clinica == null)
                return Forbid();

            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if(dados == null)
                return NotFound();

            if (dados.ClinicaId != clinica.Id)
                return Forbid();

            ViewBag.Clinicas = new List<SelectListItem>
           {
              new SelectListItem { Value = clinica.Id.ToString(), Text = clinica.NomeClinica, Selected = true }
           };
            
            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Campanha campanha)
        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
                return Forbid();

            if (id != campanha.Id)
                return NotFound();

            var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuario.Id);
            if (clinica == null)
                return Forbid();

            var existente = await _context.Campanhas.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (existente == null)
                return NotFound();
            if (existente.ClinicaId != clinica.Id)
                return Forbid();

            campanha.ClinicaId = clinica.Id;

            if (ModelState.IsValid)
            {
                _context.Campanhas.Update(campanha);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Clinicas = new List<SelectListItem>
           {
              new SelectListItem { Value = clinica.Id.ToString(), Text = clinica.NomeClinica, Selected = true }
           };

            return View(campanha);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas
                .Include(c => c.Clinica)
                .Include(c => c.Medicos)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)

        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
                return Forbid();

            if(id == null)
                return NotFound();

            var dados = await _context.Campanhas
                .Include(c => c.Clinica)
                .FirstOrDefaultAsync(c => c.Id == id);
            if(dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost,ActionName("Delete")]    
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null || usuario.TipoRegistro?.ToLower() != "clinica")
                return Forbid();

            if (id == null)
                return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if (dados == null)
                return NotFound();

            _context.Campanhas.Remove(dados);
            await _context.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aderir(int id)
        {
            var usuario = await GetCurrentUsuarioAsync();
            if (usuario == null)
                return Challenge();

            var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.UsuarioId == usuario.Id);
            if (medico == null)
                return Forbid();

            var campanha = await _context.Campanhas
                .Include(c => c.Medicos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (campanha == null)
                return NotFound();

            if (!campanha.Medicos.Any(m => m.Id == medico.Id))
            {
                campanha.Medicos.Add(medico);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        private async Task<Usuario?> GetCurrentUsuarioAsync()
        {
            if (!User.Identity.IsAuthenticated)
                return null;

            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? User.Identity.Name;
            if (string.IsNullOrEmpty(email))
                return null;

            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
