using Microsoft.AspNetCore.Mvc;
using Tribo.Models;

namespace Tribo.Controllers
{
    public class ClientesController : Controller
    {
        private readonly TriboDbContext _context;

        public ClientesController(TriboDbContext context)
        {
            _context = context;
        }
                              
        /*Crud Clientes*/

        /* Retorna Dados do Cliente */
        public IActionResult MeusDados(int id)
        {
           var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {

                return RedirectToAction("Home", "Pages");
            }


        }



        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {



            var clienteTeste = _context.Cliente.Where(c => c.Email.Equals(cliente.Email) || c.IdCliente.Equals(cliente.IdCliente)).FirstOrDefault();

            if (clienteTeste == null)
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


            if (cliente == null)
            {
                return NotFound();
            }

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

            return RedirectToAction("Home", "Pages");
        }






        /* Retorna Dados do Cliente e a Pacote */
        [HttpGet]
        public IActionResult MeuPacote(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();


            if ((cliente != null) && (cliente.Id_Pacote != null))
            {
                ViewBag.pacote = _context.Pacote.Where(p => p.IdPacote == cliente.Id_Pacote).FirstOrDefault();
                return View(cliente);
            }
            else if (cliente != null)
            {
                return RedirectToAction("Tribos", "Pages", new { id = cliente.IdCliente });
            }
            else
            {
                return RedirectToAction("Tribos", "Pages");
            }
        }

        [HttpGet]
        public IActionResult DetailPacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.pacote = _context.Pacote.Where(p => p.IdPacote == cliente.Id_Pacote).FirstOrDefault();
            };

            return PartialView("_ModalPacoteClDetalhes", cliente);
        }

        [HttpGet]
        public IActionResult DeletePacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();
            }

            return PartialView("_ModalPacoteClDelete", cliente);
        }

        [HttpPost]
        public IActionResult DeletePacoteCliente(Cliente cliente)
        {
            var clienteDel = _context.Cliente.Where(cl => cl.IdCliente == cliente.IdCliente).FirstOrDefault();

            if ((cliente.IdCliente > 0) && (cliente.IdCliente != null))
            {
                clienteDel.Id_Pacote = null;
                _context.Cliente.Update(clienteDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("MeusDados", new { id = clienteDel.IdCliente });
        }
    }
}