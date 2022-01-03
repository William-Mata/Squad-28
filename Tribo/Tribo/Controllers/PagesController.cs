using Tribo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace BrasTravel.Controllers
{
    public class PagesController : Controller
    {

        private TriboDbContext _context;

        public PagesController(TriboDbContext context)
        {
            _context = context;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Contatos()
        {
            return View();
        }


        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Tribos()
        {
            return View();
        }

        public IActionResult Prevencoes()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Logar(string email, string senha)
        {

            var cliente = _context.Cliente.Where(c => c.Email.Equals(email) && c.Senha.Equals(senha)).FirstOrDefault();
            var tribo = _context.TriboParceira.Where(t => t.Email.Equals(email) && t.Senha.Equals(senha)).FirstOrDefault();
            var admin = _context.Admin.Where(a => a.Email.Equals(email) && a.Senha.Equals(senha)).FirstOrDefault();



            if (cliente != null)
            {

                return RedirectToAction("MeusDados", "Clientes", new { id = cliente.IdCliente });
            }
            else if (tribo != null)
            {
                return RedirectToAction("DadosTribo", "Tribos", new { id = tribo.IdTribo });
            }
            else if (admin != null)
            {
                return RedirectToAction("AdministracaoContatos", "Administracao");
            }
          
                ModelState.AddModelError("CustomError", "E-mail ou Senha inválida.");
                return View();
          

        }



        [HttpPost]
        public IActionResult CreateContato(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return RedirectToAction("Contatos");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}