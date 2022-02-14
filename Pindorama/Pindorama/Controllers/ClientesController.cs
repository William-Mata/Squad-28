using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Pindorama.Data;
using Pindorama.Models;
using Microsoft.EntityFrameworkCore;

namespace Pindorama.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClientesController : Controller
    {


        private readonly PindoramaDbContext _context;

        public ClientesController(PindoramaDbContext context)
        {
            _context = context;
        }

        /* Crud dos dados do cliente */

        [HttpGet]
        public IActionResult MeusDados()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("CadastrarCliente", "Clientes");
            }
        }


        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                _context.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction("Home", "Pages");
            }
            else
            {
                ModelState.AddModelError("", "Não foi possivel realizar o cadastro.");
                return View();

            }

        }

        [HttpGet]
        public IActionResult EditDadosCliente(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            return PartialView("_ModalDadosClEdit", cliente);
        }


        [HttpPost]
        public IActionResult EditDadosCliente(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return RedirectToAction("MeusDados", new { id = cliente.IdCliente });
        }



        [HttpGet]
        public IActionResult DetailDadosCliente(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            return PartialView("_ModalDadosClDetalhes", cliente);
        }

        [HttpGet]
        public IActionResult DeleteDadosCliente(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            return PartialView("_ModalDadosClDelete", cliente);
        }

        [HttpPost]
        public IActionResult DeleteDadosCliente(Cliente cliente)
        {

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("Home", "Pages");
        }

        /* Crud dos Pacote do Cliente */
        [HttpGet]
        public IActionResult MeusPacotes()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.pacotes = _context.Pacote.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == cliente.IdCliente)).ToList();
                return View(cliente);
            }
            else
            {
                return RedirectToAction("CadastrarCliente", "Clientes");
            }
        }

        [HttpGet]
        public IActionResult DetailPacoteCliente(int id)
        {

            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            ViewBag.pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();
            return PartialView("_ModalPacoteClDetalhes", cliente);

        }

        [HttpGet]
        public IActionResult DeletePacoteCliente(int id)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();


            ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == id).FirstOrDefault();
            return PartialView("_ModalPacoteClDelete", cliente);
        }

        [HttpPost]
        public IActionResult DeletePacoteCliente(Cliente newCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == newCliente.IdCliente).FirstOrDefault();
            var pacote = _context.Pacote.Where(pct => pct.IdPacote == newCliente.Pacote[0].IdPacote).FirstOrDefault();

            _context.Database.ExecuteSqlRaw("DELETE FROM ClientePacote WHERE Cliente = " + pacote.IdPacote + " And Pacote = " + cliente.IdCliente);

            return RedirectToAction("MeusPacotes");

        }



        /* Crud dos artesanatos do cliente*/

        [HttpGet]
        public IActionResult MeusArtesanatos()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.artesanatos = _context.Artesanato.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == cliente.IdCliente)).ToList();
                return View(cliente);
            }
            else
            {
                return RedirectToAction("CadastrarCliente", "Clientes");
            }

        }

        [HttpGet]
        public IActionResult DetailArtesanatoCliente(int id)
        {

            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

            ViewBag.artesanato = _context.Artesanato.Where(p => p.IdArtesanato == id).FirstOrDefault();
            return PartialView("_ModalArtesanatoClDetalhes", cliente);

        }

        [HttpGet]
        public IActionResult DeleteArtesanatoCliente(int id)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();


            ViewBag.artesanato = _context.Artesanato.Where(v => v.IdArtesanato == id).FirstOrDefault();
            return PartialView("_ModalArtesanatoClDelete", cliente);
        }

        [HttpPost]
        public IActionResult DeleteArtesanatoCliente(Cliente newCliente)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == newCliente.IdCliente).FirstOrDefault();
            var artesanato = _context.Artesanato.Where(pct => pct.IdArtesanato == newCliente.Artesanato[0].IdArtesanato).FirstOrDefault();

            _context.Database.ExecuteSqlRaw("DELETE FROM ArtesanatoCliente WHERE Cliente = " + artesanato.IdArtesanato + " And Artesanato = " + cliente.IdCliente);

            return RedirectToAction("MeusArtesanatos");

        }
    }
}
