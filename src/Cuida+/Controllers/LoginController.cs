using Cuida_.Models.Usuarios.Dto;
using Cuida_.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Cuida_.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View("~/Views/Usuario/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Os campos devem ser preenchidos";
                return RedirectToAction("Index");
            }

            var logged = await AutenticarUsuario(loginDTO);
            
            if (!logged)
            {
                TempData["Message"] = "E-mail ou senha incorretos";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "Login efetuado com sucesso";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        private async Task<bool> AutenticarUsuario(UsuarioLoginDTO loginDTO)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email);

            if (usuario == null)
            {
                return false;
            }

            bool senhaValida = BCrypt.Net.BCrypt.Verify(loginDTO.Senha, usuario.Senha);
            if (!senhaValida)
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, usuario.Email ?? string.Empty)
            };

            if (!string.IsNullOrEmpty(usuario.TipoRegistro))
            {
                claims.Add(new Claim(ClaimTypes.Role, usuario.TipoRegistro));
            }

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
            return true;
        }
    }
}
