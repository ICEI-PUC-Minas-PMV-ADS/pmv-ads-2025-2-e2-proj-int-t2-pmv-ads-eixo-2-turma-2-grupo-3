using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace Cuida_.Controllers
{
    public class ClinicaController : Controller
    {
        private readonly AppDbContext _context;

        public ClinicaController(AppDbContext context)
        {
            _context = context;
        }

        [Route("clinica/cadastrarmedico")]
        [HttpGet]
        public async Task<IActionResult> registrarMedico()
        {
            var medicos = await _context.Medicos
                .Include(m => m.Usuario)
                .ToListAsync();

            return View("CadastrarMedico", medicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Erro ao cadastrar médico. Verifique os dados.";
                return RedirectToAction("registrarMedico");
            }

            var existeCRM = await _context.Medicos.AnyAsync(m => m.CRM == medico.CRM);
            if (existeCRM)
            {
                TempData["ErrorMessage"] = "Já existe um médico cadastrado com este CRM.";
                return RedirectToAction("registrarMedico");
            }

            var emailExistente = await _context.Usuarios.AnyAsync(u => u.Email == medico.Usuario.Email);
            if (emailExistente)
            {
                TempData["ErrorMessage"] = "Já existe um usuário cadastrado com este e-mail.";
                return RedirectToAction("registrarMedico");
            }

            string senhaCodificada = BCrypt.Net.BCrypt.HashPassword(medico.Usuario.Senha);

            var usuario = new Usuario
            {
                Email = medico.Usuario.Email,
                Senha = senhaCodificada,
                TipoRegistro = "Medico"
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            medico.Usuario = null;
            medico.UsuarioId = usuario.Id;

            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Médico cadastrado com sucesso!";
            return RedirectToAction("registrarMedico");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Erro ao editar médico. Verifique os dados.";
                return RedirectToAction("registrarMedico");
            }

            var medicoExistente = await _context.Medicos
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == medico.Id);

            if (medicoExistente == null)
            {
                TempData["ErrorMessage"] = "Médico não encontrado.";
                return RedirectToAction("registrarMedico");
            }

            medicoExistente.Nome = medico.Nome;
            medicoExistente.CRM = medico.CRM;
            medicoExistente.Especialidade = medico.Especialidade;

            medicoExistente.Usuario.Email = medico.Usuario.Email;

            if (!string.IsNullOrEmpty(medico.Usuario.Senha))
            {
                string senhaCodificada = BCrypt.Net.BCrypt.HashPassword(medico.Usuario.Senha);
                medicoExistente.Usuario.Senha = senhaCodificada;
            }

            _context.Update(medicoExistente);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Médico atualizado com sucesso!";
            return RedirectToAction("registrarMedico");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _context.Medicos
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (medico == null)
            {
                TempData["ErrorMessage"] = "Médico não encontrado.";
                return RedirectToAction("registrarMedico");
            }

            _context.Usuarios.Remove(medico.Usuario);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Médico excluído com sucesso!";
            return RedirectToAction("registrarMedico");
        }
    }
}
