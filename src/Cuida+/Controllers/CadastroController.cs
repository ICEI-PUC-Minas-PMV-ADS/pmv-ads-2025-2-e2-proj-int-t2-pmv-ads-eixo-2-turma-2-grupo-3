using Cuida_.Models.Usuarios.Dto;
using Cuida_.Models.Usuarios;
using Cuida_.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cuida_.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;
        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Usuario/Cadastro.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Index(UsuarioCadastroDTO cadastroDTO) 
        {
            if(!ModelState.IsValid)             {
                TempData["Message"] = "Erro ao cadastrar usuário. \n Verifique os dados";
                return RedirectToAction("Index");
            }

            try
            {
                await Cadastrar(cadastroDTO);
                TempData["Message"] = "Usuário cadastrado com sucesso!";
                return View("~/Views/Usuario/Login.cshtml");
            }
            catch (DbUpdateException)
            {
                TempData["Message"] = "Erro ao cadastrar usuário. Usuário já existente";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Message"] = "Erro interno ao cadastrar usuário. Tente novamente mais tarde";
                return RedirectToAction("Index");
            }
        }
        private async Task Cadastrar(UsuarioCadastroDTO cadastroDTO)
        {
            var usuario = await CadastrarUsuario(cadastroDTO);

            switch(usuario.TipoRegistro)
            {
                case "paciente":
                    var paciente = new Paciente
                    {
                        Nome = cadastroDTO.Nome,
                        CPF = cadastroDTO.CPF,
                        CadUnico = (int)cadastroDTO.CadUnico,
                        UsuarioId = usuario.Id
                    };

                    await _context.Pacientes.AddAsync(paciente);
                    await _context.SaveChangesAsync();
                    break;
                case "medico":
                    var medico = new Medico
                    {
                        Nome = cadastroDTO.Nome,
                        CRM = cadastroDTO.CRM,
                        Especialidade = cadastroDTO.Especialidade,
                        UsuarioId = usuario.Id
                    };

                    await _context.Medicos.AddAsync(medico);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    var clinica = new Clinica
                    {
                        NomeClinica = cadastroDTO.NomeClinica,
                        CNPJ = cadastroDTO.CNPJ,
                        UsuarioId = usuario.Id
                    };

                    await _context.Clinicas.AddAsync(clinica);
                    await _context.SaveChangesAsync();
                    break;
            }
        }

        private async Task<Usuario> CadastrarUsuario(UsuarioCadastroDTO cadastroDTO) {

            string senhaCodificada = BCrypt.Net.BCrypt.HashPassword(cadastroDTO.Senha);

            var usuario = new Usuario { 
                Email = cadastroDTO.Email,
                Senha = senhaCodificada,
                TipoRegistro = cadastroDTO.TipoRegistro
            };

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

    }
}
