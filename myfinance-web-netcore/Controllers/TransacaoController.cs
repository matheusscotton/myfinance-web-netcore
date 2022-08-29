using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    //[Route("[controller]")]
    public class TransacaoController : Controller
    {
        private readonly ILogger<TransacaoController> _logger;

        public TransacaoController(ILogger<TransacaoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var transacao = new Transacao();
            ViewBag.Lista = transacao.ListaTransacoes();
            return View();

        }

        [HttpGet]
        public IActionResult CriarTransacao(int? id)
        {
            if (id !=null)
            {
                var transacao = new Transacao().TransacaoPorId(id);
                ViewBag.Registro = transacao;
            }
            
            ViewBag.ListaPlanoContas = new PlanoContaModel().ListaPlanoContas();

            return View();
        }



        [HttpPost]
        public IActionResult CriarTransacao(TransacaoModel formulario)
        {
            var transacao = new Transacao();

            if ((formulario.Id == null) || (formulario.Id.Equals(0)))
                transacao.Inserir(formulario);
            else
                transacao.Atualizar(formulario);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirTransacao(int id)
        {
            var transacao = new Transacao();

            transacao.Excluir(id);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
	    public IActionResult RelatorioTransacao(string? dataInit, string? dataEnd)
        {
            var transacao = new Transacao();
            
            if (dataInit==null)
                ViewBag.Lista = transacao.ListaTransacoes();
            else
                ViewBag.Lista = transacao.ListaTransacoesToDates("2022-08-27","2022-08-28");
            
            return View();
       }


    }
}