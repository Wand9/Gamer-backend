using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace gamer_beck.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        
        [Route("Login")]
        public IActionResult Index()
        {
            HttpContext.Session.getset
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            string email = form["Email"].ToString();
            string senha = form["Senha"].ToString();

            Jogador jogadorBuscado = c.Jogador.first(j => j.Email == email && j.Senha == senha);

            //Aqui precisamos implementar a sessao
            if (jogadorBuscado != null)
            {
                HttpContext.Session.SetString("UserName",jogadorBuscado.Nome);
                return LocalRedirect("~/");
            }




            return LocalRedirect("~/Login/Login");
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}