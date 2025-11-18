using Cuida_.Models.Usuarios.Dto;
using Cuida_.Repository;
using Cuida_.Services;
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
        private readonly EmailService _emailService;

        public LoginController(AppDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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

            return RedirectToAction("Index", "Home");
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

        [HttpGet]
        [Route("recuperarsenha")]
        public IActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        [Route("recuperarsenha")]
        public async Task<IActionResult> RecuperarSenha(string email)
        {
            if (email == null)
            {
                Console.WriteLine("email == NULL");
            }
            else
            {
                Console.WriteLine($"[{email}]");
                foreach (var c in email)
                {
                    Console.WriteLine($"{(int)c} => '{c}'");
                }
            }

            if (string.IsNullOrEmpty(email))
            {
                TempData["Erro"] = "Digite um email válido.";
                return RedirectToAction("RecuperarSenha");
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                TempData["Erro"] = "Email não encontrado.";
                return RedirectToAction("RecuperarSenha");
            }

            var token = Guid.NewGuid().ToString();
            usuario.TokenRecuperacao = token;
            usuario.TokenExpiracao = DateTime.UtcNow.AddHours(1);

            await _context.SaveChangesAsync();

            string link = Url.Action(
                "NovaSenha",
                "Login",
                new { token = token },
                Request.Scheme);

            _emailService.Enviar(
                email,
                "Recuperação de senha - Cuida+",
                $@"
                    <p>Você solicitou a recuperação de senha.</p>
                    <p>Clique no link abaixo para criar uma nova senha:</p>
                    <p>
                        <a href='{link}' style='color:#0D99FF; font-weight:bold;'>
                            Recuperar Senha
                        </a>
                    </p>
                "
            );

            TempData["Sucesso"] = "Se o email existir, enviamos um link de recuperação.";
            return RedirectToAction("RecuperarSenha");
        }

        [HttpGet]
        [Route("novasenha")]
        public async Task<IActionResult> NovaSenha(string token)
        {
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token inválido.");

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.TokenRecuperacao == token);

            if (usuario == null || usuario.TokenExpiracao < DateTime.UtcNow)
            {
                TempData["Erro"] = "Este link expirou ou é inválido.";
                return RedirectToAction("RecuperarSenha");
            }

            ViewBag.Token = token;
            return View("~/Views/Usuario/NovaSenha.cshtml");
        }

        [HttpPost]
        [Route("novasenha")]
        public async Task<IActionResult> NovaSenha(string token, string senha, string confirmar)
        {
            if (senha != confirmar)
            {
                TempData["Erro"] = "As senhas não coincidem.";
                ViewBag.Token = token;
                return View("~/Views/Usuario/NovaSenha.cshtml");
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.TokenRecuperacao == token);

            if (usuario == null || usuario.TokenExpiracao < DateTime.UtcNow)
            {
                TempData["Erro"] = "Link de recuperação inválido.";
                return RedirectToAction("RecuperarSenha");
            }

            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(senha);

            usuario.TokenRecuperacao = null;
            usuario.TokenExpiracao = null;

            await _context.SaveChangesAsync();

            TempData["SenhaAlterada"] = true;
            return RedirectToAction("Index", "Login");
        }
    }
}
