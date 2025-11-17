using Cuida_.Models;
using Cuida_.Models.Usuarios;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller   // <-- ADICIONAR HERANÇA
    {
        private readonly AppDbContext _context;    // <-- ADICIONAR CONTEXT

        // INJETAR O CONTEXT VIA CONSTRUTOR
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
                .FirstOrDefaultAsync(m => m.Id == 1);

            return View("PerfilM", perfilmedico);   // <-- AGORA FUNCIONA
        }
    }
}
