using Cuida_.Models.repository;
using Cuida_.Models.usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cuida_.Models.campanhas;
using System.Linq;

namespace Cuida_.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AppDbContext _context;

        public MedicoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _context.Medicos.ToListAsync();
            return View(medicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                var existeCRM = await _context.Medicos
                    .AnyAsync(m => m.CRM == medico.CRM);

                if (existeCRM)
                {
                    TempData["ErrorMessage"] = "Já existe um médico cadastrado com este CRM.";
                    return RedirectToAction("Index");
                }

                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Médico cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Erro ao cadastrar médico. Verifique os dados.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Erro ao editar médico. Verifique os dados.";
                return RedirectToAction("Index");
            }

            var medicoExistente = await _context.Medicos.FindAsync(medico.Id);
            if (medicoExistente == null)
            {
                TempData["ErrorMessage"] = "Médico não encontrado.";
                return RedirectToAction("Index");
            }

            medicoExistente.Nome = medico.Nome;
            medicoExistente.Email = medico.Email;
            medicoExistente.Senha = medico.Senha;
            medicoExistente.CRM = medico.CRM;
            medicoExistente.Especialidade = medico.Especialidade;

            _context.Update(medicoExistente);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Médico atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico == null)
            {
                TempData["ErrorMessage"] = "Médico não encontrado.";
                return RedirectToAction("Index");
            }

            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Médico excluído com sucesso!";
            return RedirectToAction("Index");
        }
    
    [HttpGet("Medico/CampanhasDisponiveis")]
        public async Task<IActionResult> CampanhasDisponiveis()
        {
            var campanhas = await _context.Campanhas
               .Select(c => new CampanhaDisponivelVM
               {
                   Id = c.Id,
                   NomeCampanha = c.NomeCampanha,
                   DataInicio = c.DataInicio,
                   DataFim = c.DataFim,
                   Ativa = c.Ativa,
                   
               })
                 .ToListAsync();

            
            return View("CampanhasDisponiveis", campanhas);
        }
    }



}
