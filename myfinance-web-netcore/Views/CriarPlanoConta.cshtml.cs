using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace myfinance_web_netcore.Views
{
    public class CriarPlanoConta : PageModel
    {
        private readonly ILogger<CriarPlanoConta> _logger;

        public CriarPlanoConta(ILogger<CriarPlanoConta> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}