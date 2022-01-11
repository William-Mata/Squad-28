using Tribo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tribo.Data;
using System.Security.Claims;

namespace Tribo.Controllers
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
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            if (userEmail != null)
            {
                var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();
                ViewBag.pacotes = _context.Pacote.ToList();
                return View(cliente);
            }
            else
            {
                ViewBag.pacotes = _context.Pacote.ToList();
                return View();

            }
        }

        public IActionResult Prevencoes()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateContato(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return RedirectToAction("Contatos");
        }


        [HttpGet]
        public IActionResult Comprar()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);

            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            if (cliente != null)
            {
                return View(cliente);
            }

            return View();


        }

        [HttpPost]
        public IActionResult Comprar(Cliente cliente)
        {
            if (cliente != null)
            {
                _context.Cliente.Update(cliente);
                _context.SaveChanges();
            }

            return RedirectToAction("MeuPacote", "Clientes", new { id = cliente.IdCliente });

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}