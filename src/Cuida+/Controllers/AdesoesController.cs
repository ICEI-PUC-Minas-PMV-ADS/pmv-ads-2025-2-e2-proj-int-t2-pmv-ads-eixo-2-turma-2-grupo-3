using System.Threading.Tasks;                  // para Task e async/await
using Microsoft.AspNetCore.Mvc;               // para Controller e IActionResult
using Microsoft.EntityFrameworkCore;          // para ToListAsync e DbContext
using Cuida_.Data;                            // onde está o seu DbContext (ajuste o namespace)
using Cuida_.Models.CampanhasAderidas;        // onde está sua classe AderirCampanhas
using MySqlConnector;

namespace Cuida_.Controllers
{
    public class AdesoesController : Controller
    {
        private readonly cuidamais_db _context; // ou cuidamais_dbContext, se for o nome real

        public AdesoesController(cuidamais_db context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.AderirCampanhas.ToListAsync();
            return View(dados);
        }
    }
}