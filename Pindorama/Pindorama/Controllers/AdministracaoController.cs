using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Pindorama.Data;
using Pindorama.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Pindorama.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministracaoController : Controller
    {
        private PindoramaDbContext _context;

        public AdministracaoController(PindoramaDbContext context)
        {
            _context = context;
        }

        /*Crud Contatos*/
        [HttpGet]
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

        /*Crud das Viagens Dos Clientes*/

        [HttpGet]
        public IActionResult AdministracaoPacotes()
        {
            var clientes = _context.Cliente.ToList();

            foreach (var cliente in clientes)
            {
                var pacotes = _context.Pacote.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == cliente.IdCliente)).ToList();
                cliente.Pacote = pacotes;
            }

            return View(clientes);
        }


        [HttpGet]
        public IActionResult DetailsPacote(int IdPacote, int IdCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == IdCliente).FirstOrDefault();

            ViewBag.pacote = _context.Pacote.Where(pc => pc.IdPacote == IdPacote).FirstOrDefault();
            return PartialView("_ModalPacoteDetalhes", cliente);
        }


        [HttpGet]
        public IActionResult DeletePacote(int IdPacote, int IdCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == IdCliente).FirstOrDefault();

            ViewBag.pacote = _context.Pacote.Where(pc => pc.IdPacote == IdPacote).FirstOrDefault();
            return PartialView("_ModalPacoteDelete", cliente);
        }



        [HttpPost]
        public IActionResult DeletePacote(Cliente newCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == newCliente.IdCliente).FirstOrDefault();
            var pacote = _context.Pacote.Where(pct => pct.IdPacote == newCliente.Pacote[0].IdPacote).FirstOrDefault();

            _context.Database.ExecuteSqlRaw("DELETE FROM ClientePacote WHERE Cliente = " + pacote.IdPacote + " And Pacote = " + cliente.IdCliente);
            return RedirectToAction("AdministracaoPacotes");
        }


        /*Crud das Viagens Dos Clientes*/

        [HttpGet]
        public IActionResult AdministracaoArtesanatos()
        {
            var clientes = _context.Cliente.ToList();

            foreach (var cliente in clientes)
            {
                var artesanatos = _context.Artesanato.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == cliente.IdCliente)).ToList();
                cliente.Artesanato = artesanatos;
            }

            return View(clientes);
        }


        [HttpGet]
        public IActionResult DetailsArtesanato(int IdArtesanato, int IdCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == IdCliente).FirstOrDefault();

            ViewBag.artesanato = _context.Artesanato.Where(pc => pc.IdArtesanato == IdArtesanato).FirstOrDefault();
            return PartialView("_ModalArtesanatoDetalhes", cliente);
        }


        [HttpGet]
        public IActionResult DeleteArtesanato(int IdArtesanato, int IdCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == IdCliente).FirstOrDefault();

            ViewBag.artesanato = _context.Artesanato.Where(pc => pc.IdArtesanato == IdArtesanato).FirstOrDefault();
            return PartialView("_ModalArtesanatoDelete", cliente);
        }



        [HttpPost]
        public IActionResult DeleteArtesanato(Cliente newCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == newCliente.IdCliente).FirstOrDefault();
            var artesanato = _context.Artesanato.Where(pct => pct.IdArtesanato == newCliente.Artesanato[0].IdArtesanato).FirstOrDefault();

            _context.Database.ExecuteSqlRaw("DELETE FROM ArtesanatoCliente WHERE Cliente = " + artesanato.IdArtesanato + " And Artesanato = " + cliente.IdCliente);
            return RedirectToAction("AdministracaoArtesanatos");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
