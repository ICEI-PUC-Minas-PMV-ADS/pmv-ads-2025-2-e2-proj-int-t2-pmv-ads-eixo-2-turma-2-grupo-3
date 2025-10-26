using Microsoft.AspNetCore.Mvc;
using Cuida_.Models.usuarios;
using Cuida_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cuida_.Controllers
{
    public class ConsultaController : Controller
    {
        private List<Medico> medicos = new List<Medico>
        {
            new Medico { Id = 1, Nome = "Dra. Ana", Especialidade = "Cardiologia", HorariosDisponiveis = new List<string> { "08:00", "09:00", "10:00" } },
            new Medico { Id = 2, Nome = "Dr. João", Especialidade = "Dermatologia", HorariosDisponiveis = new List<string> { "13:00", "14:00", "15:00" } }
        };

        private List<Paciente> pacientes = new List<Paciente>
        {
            new Paciente { Id = 1, Nome = "Caio Silva" },
            new Paciente { Id = 2, Nome = "Maria Souza" }
        };

        private List<Campanha> campanhas = new List<Campanha>
        {
            new Campanha { Id = 1, Nome = "Campanha Coração Saudável", Especialidade = "Cardiologia" },
            new Campanha { Id = 2, Nome = "Campanha Pele Limpa", Especialidade = "Dermatologia" }
        };

        [HttpGet]
        public IActionResult MarcarConsulta()
        {
            var viewModel = new ConsultaViewModel
            {
                Pacientes = pacientes,
                Medicos = medicos,
                Campanhas = campanhas
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MarcarConsulta(ConsultaViewModel model)
        {
            var medico = medicos.FirstOrDefault(m => m.Id == model.MedicoId);
            var campanha = campanhas.FirstOrDefault(c => c.Especialidade == medico?.Especialidade);

            if (medico == null)
            {
                ModelState.AddModelError("", "Médico não encontrado.");
            }
            else if (campanha == null)
            {
                ModelState.AddModelError("", "Nenhuma campanha aderente à especialidade do médico.");
            }
            else if (medico.HorariosDisponiveis == null || !medico.HorariosDisponiveis.Contains(model.Horario))
            {
                ModelState.AddModelError("", "Horário não disponível para este médico.");
            }

            if (!ModelState.IsValid)
            {
                model.Medicos = medicos;
                model.Pacientes = pacientes;
                model.Campanhas = campanhas;
                return View(model);
            }

            TempData["Mensagem"] = $"Consulta marcada com o médico {medico.Nome} às {model.Horario} para o paciente {model.PacienteId} na campanha \"{campanha.Nome}\".";
            return RedirectToAction("Confirmacao");
        }

        public IActionResult Confirmacao()
        {
            ViewBag.Mensagem = TempData["Mensagem"];
            return View();
       