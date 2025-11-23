using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Models.ViewModels;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using BCrypt.Net;

namespace Cuida_.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // /usuario/perfil (GET)
        [HttpGet("perfil")]
        public async Task<IActionResult> Perfil(int? id)
        {
            int usuarioId;

            if (id.HasValue)
            {
                usuarioId = id.Value;
            }
            else
            {
                var claim = User.FindFirst(ClaimTypes.NameIdentifier);
                usuarioId = claim != null ? int.Parse(claim.Value) : 0;
            }

            if (usuarioId == 0) return RedirectToAction("Login", "Auth");

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
            if (usuario == null) return NotFound("Usuário não encontrado.");

            var perfil = new PerfilViewModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                TipoRegistro = usuario.TipoUsuario.ToString()
            };

            switch (usuario.TipoUsuario.ToString())
            {
                case "Paciente":
                    var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
                    if (paciente == null) return NotFound("Paciente não encontrado.");
                    perfil.CPF = paciente.CPF;
                    perfil.CadUnico = paciente.CadUnico;
                    break;

                case "Medico":
                    var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.UsuarioId == usuarioId);
                    if (medico == null) return NotFound("Médico não encontrado.");
                    perfil.CRM = medico.CRM;
                    perfil.Especialidade = medico.Especialidade;
                    break;

                case "Clinica":
                    var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
                    if (clinica == null) return NotFound("Clínica não encontrada.");
                    perfil.NomeClinica = clinica.NomeClinica;
                    perfil.CNPJ = clinica.CNPJ;
                    break;
            }

            return View("Perfil", perfil);
        }

        // /usuario/perfil (POST)
        [HttpPost("perfil")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarPerfil(PerfilViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Perfil", model);
            }

            if (model.Id == null)
            {
                TempData["MensagemErro"] = "ID inválido.";
                return RedirectToAction("Perfil");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == model.Id.Value);
            if (usuario == null)
            {
                TempData["MensagemErro"] = "Usuário não encontrado para edição.";
                return RedirectToAction("Perfil", new { id = model.Id.Value });
            }

            usuario.Nome = model.Nome;
            usuario.Email = model.Email;
            _context.Entry(usuario).State = EntityState.Modified;

            switch (usuario.TipoUsuario.ToString())
            {
                case "Clinica":
                    var clinica = await _context.Clinicas.FirstOrDefaultAsync(c => c.UsuarioId == model.Id.Value);
                    if (clinica == null) return NotFound("Clínica não encontrada para edição.");

                    clinica.NomeClinica = model.NomeClinica;
                    clinica.CNPJ = model.CNPJ;
                    _context.Entry(clinica).State = EntityState.Modified;
                    break;

                case "Paciente":
                    var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.UsuarioId == model.Id.Value);
                    if (paciente == null) return NotFound("Paciente não encontrado para edição.");

                    paciente.CPF = model.CPF;
                    paciente.CadUnico = model.CadUnico;
                    _context.Entry(paciente).State = EntityState.Modified;
                    break;

                case "Medico":
                    var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.UsuarioId == model.Id.Value);
                    if (medico == null) return NotFound("Médico não encontrado para edição.");

                    medico.CRM = model.CRM;
                    medico.Especialidade = model.Especialidade;
                    _context.Entry(medico).State = EntityState.Modified;
                    break;
            }

            try
            {
                await _context.SaveChangesAsync();
                TempData["MensagemSucesso"] = "Perfil atualizado com sucesso!";
                return RedirectToAction("Perfil", new { id = model.Id.Value });
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Erro ao salvar as informações. Verifique se o Email ou CNPJ já está em uso.");
                return View("Perfil", model);
            }
        }

        // /usuario/mudar-senha (GET)
        [HttpGet("mudar-senha")]
        public IActionResult MudarSenha()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            int usuarioId = claim != null ? int.Parse(claim.Value) : 0;

            var vm = new TrocarSenhaViewModel { UsuarioId = usuarioId };
            return View(vm);
        }

        // /usuario/mudar-senha (POST)
        [HttpPost("mudar-senha")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudarSenha(TrocarSenhaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == model.UsuarioId);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuário não encontrado.");
                return View(model);
            }

            bool senhaValida = false;

            if (!string.IsNullOrEmpty(usuario.Senha) && usuario.Senha.StartsWith("$2"))
            {
                try
                {
                    senhaValida = BCrypt.Net.BCrypt.Verify(model.SenhaAtual, usuario.Senha);
                }
                catch
                {
                    senhaValida = false;
                }
            }
            else
            {
                senhaValida = usuario.Senha == model.SenhaAtual;
            }

            if (!senhaValida)
            {
                ModelState.AddModelError(nameof(model.SenhaAtual), "Senha atual incorreta.");
                return View(model);
            }

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(model.NovaSenha);

            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
            return RedirectToAction("Perfil");
        }
    }
}
