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


        /* Retorna Dados do Cliente */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string senha)
        {

            var cliente = _context.Cliente.Where(c => c.Email.Equals(email) && c.Senha.Equals(senha));
            var admin = _context.Admin.Where(a => a.Email.Equals(email) && a.Senha.Equals(senha));
            var tribo = _context.TriboParceira.Where(t => t.Email.Equals(email) && t.Senha.Equals(senha));

            if (cliente != null)
            {

                return RedirectToAction("Clientes", "DadosCliente", cliente);
            }
            else if (tribo != null)
            {
                return RedirectToAction("Tribos", "DadosTribo", tribo);
            }
            else if (admin != null)
            {
                return RedirectToAction("Admin", "DadosCliente");
            }

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