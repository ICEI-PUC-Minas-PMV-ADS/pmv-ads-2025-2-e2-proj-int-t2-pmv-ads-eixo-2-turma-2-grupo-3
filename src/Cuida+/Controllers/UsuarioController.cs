using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Models.ViewModels;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        // GET: /usuario/perfil
        [HttpGet("perfil")]
        public async Task<IActionResult> Perfil()
        {
            var perfilmedico = await _context.Medicos
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == 1); // você pode ajustar para pegar usuário logado

            return View("PerfilM", perfilmedico);
        }

        // GET: /usuario/mudar-senha
        [HttpGet("mudar-senha")]
        public IActionResult MudarSenha()
        {
            // Pega o usuário logado via Claims
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var vm = new TrocarSenhaViewModel
            {
                UsuarioId = usuarioId
            };

            return View(vm);
        }

        // POST: /usuario/mudar-senha
        [HttpPost("mudar-senha")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MudarSenha(TrocarSenhaViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Pega id do usuário logado
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
            {
                ModelState.AddModelError("", "Usuário não encontrado.");
                return View(model);
            }

            // MOCK: comparar senha como texto puro
            if (usuario.Senha != model.SenhaAtual)
            {
                ModelState.AddModelError(nameof(model.SenhaAtual), "Senha atual incorreta.");
                return View(model);
            }

            // MOCK: salvar senha nova sem hash
            usuario.Senha = model.NovaSenha;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
            return RedirectToAction("Perfil");
        }
    }
}
