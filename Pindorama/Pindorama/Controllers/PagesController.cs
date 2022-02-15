using Pindorama.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Pindorama.Data;
using System.Security.Claims;
using NuGet.Packaging;
using Microsoft.AspNetCore.Http;

namespace Pindorama.Controllers
{
    public class PagesController : Controller
    {

        private PindoramaDbContext _context;

        public PagesController(PindoramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contatos()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sobre()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Aldeias()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            if (userEmail != null)
            {
                var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();

                if (cliente != null)
                {
                    ViewBag.pacotes = _context.Pacote.ToList();
                    return View(cliente);
                }
            }
            ViewBag.pacotes = _context.Pacote.ToList();
            return View();

        }

        [HttpGet]
        public IActionResult Artesanatos()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var cliente = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();
            if (userEmail != null)
            {
                if (cliente != null)
                {
                    ViewBag.artesanatos = _context.Artesanato.ToList();
                    return View(cliente);
                }
            }
            ViewBag.artesanatos = _context.Artesanato.ToList();
            return View();

        }

        [HttpGet]
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
        public IActionResult ComprarPct()
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
        public IActionResult ComprarPct(Cliente cliente)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var clienteCompra = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();
            var result = false;

            var pacote = _context.Pacote.Where(pct => pct.IdPacote == cliente.Pacote[0].IdPacote).FirstOrDefault();
            var oldPacotes = _context.Pacote.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == clienteCompra.IdCliente)).ToList();

            if (clienteCompra != null && pacote != null)
            {
                foreach (var oldPacote in oldPacotes)
                {
                    if ((pacote.IdPacote == oldPacote.IdPacote) && (result == false))
                    {
                        result = true;

                        TempData["msg"] = "Esse pacote já foi adquirido por você.";
                        return RedirectToAction("Aldeias", "Pages");
                    }
                }
            }

            clienteCompra.Origem = cliente.Origem;
            clienteCompra.Pacote = new List<Pacote> { pacote };
            _context.Cliente.Update(clienteCompra);
            _context.SaveChanges();
            return RedirectToAction("MeusPacotes", "Clientes");

        }


        [HttpGet]
        public IActionResult ComprarArt()
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
        public IActionResult ComprarArt(Cliente cliente)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var clienteCompra = _context.Cliente.Where(cl => cl.Email_User.Equals(userEmail)).FirstOrDefault();
            var result = false;

            var artesanato = _context.Artesanato.Where(pct => pct.IdArtesanato == cliente.Artesanato[0].IdArtesanato).FirstOrDefault();
            var oldArtesanatos = _context.Artesanato.Where(pc => pc.Cliente.Any(ptc => ptc.IdCliente == clienteCompra.IdCliente)).ToList();

            if (clienteCompra != null && artesanato != null)
            {
                foreach (var oldArtesanato in oldArtesanatos)
                {
                    if ((artesanato.IdArtesanato == oldArtesanato.IdArtesanato) && (result == false))
                    {
                        result = true;

                        TempData["msg"] = "Esse artesanato já foi adquirido por você.";
                        return RedirectToAction("Artesanatos", "Pages");
                    }
                }
            }

            clienteCompra.Artesanato = new List<Artesanato> { artesanato };
            _context.Cliente.Update(clienteCompra);
            _context.SaveChanges();
            return RedirectToAction("MeusArtesanatos", "Clientes");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}