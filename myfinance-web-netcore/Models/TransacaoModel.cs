using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id {get; set;}

        public DateTime Data {get; set;}

        public decimal Valor {get; set;}

        public string? Tipo {get; set;}

        public string? Historico {get; set;}
        public int? IdPlanoConta {get; set;}


    }
}