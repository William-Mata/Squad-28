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

    

        [HttpPost]
        public IActionResult CreateContato(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return RedirectToAction("Contatos");
        }
        
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return RedirectToAction("Viagem");
        }

        public IActionResult Viagem()
        {

            ViewBag.cliente = _context.Clientes.ToList();
         

            if (ViewBag.cliente == null)
            {
                return NotFound();
            }


            return View();
        }

        public IActionResult Edit(int id)
        {

            var cliente = _context.Clientes.Where(p => p.IdCliente == id).FirstOrDefault();

     

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_ModalViagemEdit", cliente);
        }


        [HttpPost]
        public IActionResult Edit(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();

            return RedirectToAction("Viagem");
        }

        public IActionResult Details(int id)
        {
            var cliente = _context.Clientes.Where(p => p.IdCliente == id).FirstOrDefault();
            return PartialView("_ModalViagemDetalhes", cliente); ;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Where(p => p.IdCliente == id).FirstOrDefault();

            return PartialView("_ModalViagemDelete", cliente); ;
        }

        [HttpPost]
        public IActionResult Delete(Cliente cliente)
        {
            var clienteDel = _context.Clientes.Where(p => p.IdCliente == cliente.IdCliente).FirstOrDefault();

            _context.Clientes.Remove(clienteDel);
            _context.SaveChanges();


            return RedirectToAction("Viagem");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}