using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    //[Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;

        public PlanoContaController(ILogger<PlanoContaController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var planoContaModel = new PlanoContaModel();
            ViewBag.Lista = planoContaModel.ListaPlanoContas();
            return View();
        }

        [HttpGet]
        public IActionResult CriarPlanoConta(int? id)
        {
            if (id !=null)
            {
                var plano_conta = new PlanoContaModel().CarregarPlanoContaPorId(id);
                ViewBag.PlanoConta = plano_conta;
            }

            return View();
        }

        [HttpPost]
        public IActionResult CriarPlanoConta(PlanoContaModel formulario)
        {
            if (formulario.Id == null)
                formulario.Inserir();
            else
                formulario.Atualizar(formulario.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirPlanoConta(int id)
        {
            new PlanoContaModel().Excluir(id);
            return RedirectToAction("Index");
        }



    }
}