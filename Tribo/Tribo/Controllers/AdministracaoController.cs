using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tribo.Models;

namespace Tribo.Controllers
{
    public class AdministracaoController : Controller
    {
        private TriboDbContext _context;

        public AdministracaoController(TriboDbContext context)
        {
            _context = context;
        }

        /*Crud Contatos*/
        public IActionResult AdministracaoContatos()
        {
            ViewBag.contatos = _context.Contato.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult EditContato(int id)
        {

            var contato = _context.Contato.Where(c => c.IdContato == id).FirstOrDefault();


            if (contato == null)
            {
                return NotFound();
            }

            return PartialView("_ModalContatoEdit", contato);
        }


        [HttpPost]
        public IActionResult EditContato(Contato contato)
        {

            _context.Contato.Update(contato);
            _context.SaveChanges();


            return RedirectToAction("AdministracaoContatos");
        }
        
        [HttpGet]
        public IActionResult DetailsContato(int id)
        {
            var contato = _context.Contato.Where(c => c.IdContato == id).FirstOrDefault();

            return PartialView("_ModalContatoDetalhes", contato); ;
        }

        [HttpGet]
        public IActionResult DeleteContato(int id)
        {
            var contato = _context.Contato.Where(c => c.IdContato == id).FirstOrDefault();


            return PartialView("_ModalContatoDelete", contato); ;
        }

        [HttpPost]
        public IActionResult DeleteContato(Contato contato)
        {
            var id = contato.IdContato;

            var contatoDel = _context.Contato.Find(id);

            if ((id > 0) && (id != null)) 
            {
                _context.Contato.Remove(contatoDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("AdministracaoContatos");
        }

        /*Crud Clientes*/

        public IActionResult AdministracaoViagens()
        {
            ViewBag.cliente = _context.Cliente.ToList();
            ViewBag.viagem = _context.Viagem.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult EditCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();


            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_ModalViagemEdit", cliente);
        }


        [HttpPost]
        public IActionResult EditCliente(Cliente cliente)
        {

            _context.Cliente.Update(cliente);
            _context.SaveChanges();


            return RedirectToAction("AdministracaoViagens");
        }

        [HttpGet]
        public IActionResult DetailsViagem(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            return PartialView("_ModalViagemDetalhes", cliente); 
        }

        [HttpGet]
        public IActionResult DeleteViagem(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();


            return PartialView("_ModalViagemDelete", cliente); 
        }

        [HttpPost]
        public IActionResult DeleteViagem(Cliente cliente)
        {
            var id = cliente.IdCliente;

            var clienteDel = _context.Cliente.Find(id);

            if ((id > 0) && (id != null))
            {
                _context.Cliente.Remove(clienteDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("AdministracaoViagens");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
