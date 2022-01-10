using Tribo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tribo.Data;

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
            ViewBag.pacotes = _context.Pacote.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Tribos(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            ViewBag.pacotes = _context.Pacote.ToList();
            return View(cliente);
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
        public IActionResult Comprar(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

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