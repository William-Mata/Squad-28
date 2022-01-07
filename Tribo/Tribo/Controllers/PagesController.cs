using Tribo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


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


        [HttpGet]
        public IActionResult Logar(string email, string senha)
        {

            var cliente = _context.Cliente.Where(c => c.Email.Equals(email) && c.Senha.Equals(senha)).FirstOrDefault();
            var tribo = _context.TriboParceira.Where(t => t.Email.Equals(email) && t.Senha.Equals(senha)).FirstOrDefault();
            var admin = _context.Admin.Where(a => a.Email.Equals(email) && a.Senha.Equals(senha)).FirstOrDefault();



            if (cliente != null)
            {

                return RedirectToAction("MeusDados", "Clientes", new { id = cliente.IdCliente });
            }
            else if (tribo != null)
            {
                return RedirectToAction("DadosTribo", "Tribos", new { id = tribo.IdTribo });
            }
            else if (admin != null)
            {
                return RedirectToAction("AdministracaoContatos", "Administracao");
            }

            ModelState.AddModelError("CustomError", "E-mail ou Senha inválida.");
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

            //var idc = Convert.ToInt64(ids.Substring(0, ids.IndexOf(".")));
            //var idp = Convert.ToInt64(ids.Substring(ids.IndexOf("."), ids.Length));

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
            // ViewBag.pacote = _context.Pacote.Where(pc => pc.IdPacote == idp).FirstOrDefault();
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