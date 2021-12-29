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


        public IActionResult AdministracaoContatos()
        {
            ViewBag.contatos = _context.Contatos.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult EditContato(int id)
        {

            var contato = _context.Contatos.Where(c => c.IdContato == id).FirstOrDefault();


            if (contato == null)
            {
                return NotFound();
            }

            return PartialView("_ModalContatoEdit", contato);
        }


        [HttpPost]
        public IActionResult EditContato(Contato contato)
        {

            _context.Contatos.Update(contato);
            _context.SaveChanges();


            return RedirectToAction("AdministracaoContatos");
        }
        
        [HttpGet]
        public IActionResult DetailsContato(int id)
        {
            var contato = _context.Contatos.Where(c => c.IdContato == id).FirstOrDefault();

            return PartialView("_ModalContatoDetalhes", contato); ;
        }

        [HttpGet]
        public IActionResult DeleteContato(int id)
        {
            var contato = _context.Contatos.Where(c => c.IdContato == id).FirstOrDefault();


            return PartialView("_ModalContatoDelete", contato); ;
        }

        [HttpPost]
        public IActionResult DeleteContato(Contato contato)
        {
            var id = contato.IdContato;

            var contatoDel = _context.Contatos.Find(id);

            if ((id > 0) && (id != null)) 
            {
                _context.Contatos.Remove(contatoDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("AdministracaoContatos");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
