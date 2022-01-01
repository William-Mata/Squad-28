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

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        public IActionResult CadastrarTribo()
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
        
        [HttpPost]
        public IActionResult CadastroCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Clientes/DadosCliente");
        }

        [HttpPost]
        public IActionResult CadastroTribo(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Tribo/DadosTribo");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}