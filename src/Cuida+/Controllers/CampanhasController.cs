using Cuida_.Models.campanhas;
﻿using Cuida_.Models.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cuida_.Controllers
{
    public class CampanhasController : Controller
    {
        private readonly AppDbContext _context;

        public CampanhasController(AppDbContext context)
        {
            _context = context;
        }

        // Carrega dropdown de clínicas a partir do banco (MySQL)
        private async Task CarregarClinicasAsync(int? selecionadaId = null)
        {
            var clinicas = await _context.Clinicas
                                         .AsNoTracking()
                                         .OrderBy(c => c.Nome) // ajuste se o campo tiver outro nome
                                         .ToListAsync();

            ViewBag.Clinicas = new SelectList(clinicas, "Id", "Nome", selecionadaId);
        }

        // LISTA
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Campanhas
                                      .Include(c => c.Clinica)
                                      .AsNoTracking()
                                      .ToListAsync();
            return View(dados);
        }

        // CREATE (GET)
        public async Task<IActionResult> Create()
        {
            await CarregarClinicasAsync();
            return View(new Campanha { Ativa = true });
        }

        // CREATE (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Campanha campanha)
        {
            if (!ModelState.IsValid)
            {
                await CarregarClinicasAsync(campanha.ClinicaId);
                return View(campanha);
            }

            _context.Campanhas.Add(campanha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // EDIT (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if (dados == null) return NotFound();

            await CarregarClinicasAsync(dados.ClinicaId);
            return View(dados); // <-- antes você não passava o model
        }

        // EDIT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Campanha campanha)
        {
            if (id != campanha.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                await CarregarClinicasAsync(campanha.ClinicaId);
                return View(campanha);
            }

            try
            {
                _context.Campanhas.Update(campanha);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var existe = await _context.Campanhas.AnyAsync(c => c.Id == id);
                if (!existe) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Campanhas
                                      .Include(c => c.Clinica)
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(c => c.Id == id);
            if (dados == null) return NotFound();

            return View(dados);
        }

        // DELETE (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Campanhas
                                      .Include(c => c.Clinica)
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(c => c.Id == id);
            if (dados == null) return NotFound();

            return View(dados);
        }

        // DELETE (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) return NotFound();

            var dados = await _context.Campanhas.FindAsync(id);
            if (dados == null) return NotFound();

            _context.Campanhas.Remove(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}