using Microsoft.AspNetCore.Mvc;
using Tribo.Models;

namespace Tribo.Controllers
{
    public class TribosController : Controller
    {
        private readonly TriboDbContext _context;

        public TribosController(TriboDbContext context)
        {
            _context = context;
        }



        /*Crud Tribos*/

        /* Retorna Dados do Tribo */
        public IActionResult DadosTribo(int id)
        {
            var tribo_parceira = _context.TriboParceira.Where(t => t.IdTribo == id).FirstOrDefault();
            return View();
        }

        [HttpGet]
        public IActionResult EditDadosTribo(int id)
        {
            var tribo_parceira = _context.TriboParceira.Where(t => t.IdTribo == id).FirstOrDefault();

            if (tribo_parceira == null)
            {
                return NotFound();
            }

            return PartialView("_ModalDadosTrbEdit", tribo_parceira);
        }


        [HttpPost]
        public IActionResult EditDadosTribo(TriboParceira tribo_parceira)
        {
            _context.TriboParceira.Update(tribo_parceira);
            _context.SaveChanges();

            return RedirectToAction("DadosTribo");
        }


        [HttpGet]
        public IActionResult DetailDadosTribo(int id)
        {
            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();

            return PartialView("_ModalDadosTrbDetalhes", tribo_parceira);
        }

        [HttpGet]
        public IActionResult DeleteDadosTribo(int id)
        {
            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();


            return PartialView("_ModalDadosTrbDelete", tribo_parceira);
        }

        [HttpPost]
        public IActionResult DeleteDadosTribo(TriboParceira tribo_parceira)
        {
            var id = tribo_parceira.IdTribo;

            var tribo_parceiraDel = _context.TriboParceira.Find(id);

            if ((id > 0) && (id != null))
            {
                _context.TriboParceira.Remove(tribo_parceiraDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Home");
        }

        /* Retorna Dados do Tribo e a Pacote */
        public IActionResult PacoteTribo(int id)
        {

            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();

            if (tribo_parceira != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditPacoteTribo(int id)
        {

            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();

            if (tribo_parceira != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
                ViewBag.imagem = _context.Imagem.Where(i => i.IdImg == tribo_parceira.Pacote.Id_Imagem).FirstOrDefault();
            }

            if (tribo_parceira == null)
            {
                return NotFound();
            }

            return PartialView("_ModalPacoteTrbEdit", tribo_parceira);
        }


        [HttpPost]
        public IActionResult EditPacoteTribo(TriboParceira tribo_parceira)
        {

            var IdV = tribo_parceira.Id_Pacote;
            var pacote = _context.Pacote.Find(IdV);



            if (pacote != null)
            {
                _context.Pacote.Update(pacote);

            }

            _context.SaveChanges();

            return RedirectToAction("PacoteTribo");
        }



        [HttpGet]
        public IActionResult DetailPacoteTribo(int id)
        {

            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();

            if (tribo_parceira != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
            };

            return PartialView("_ModalPacoteTrbDetalhes", tribo_parceira);
        }

        [HttpGet]
        public IActionResult DeletePacoteTribo(int id)
        {

            var tribo_parceira = _context.TriboParceira.Where(cl => cl.IdTribo == id).FirstOrDefault();

            if (tribo_parceira != null)
            {
                var pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
            }

            return PartialView("_ModalPacoteTrbDelete", tribo_parceira);
        }

        [HttpPost]
        public IActionResult DeletePacoteTribo(TriboParceira tribo_parceira)
        {
            var tribo_parceiraDel = _context.TriboParceira.Where(cl => cl.IdTribo == tribo_parceira.IdTribo).FirstOrDefault();
            var pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceiraDel.Id_Pacote).FirstOrDefault();

            if ((tribo_parceira.IdTribo > 0) && (tribo_parceira.IdTribo != null))
            {
                _context.Pacote.Remove(pacote);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("PacotesTribo");
        }
    }
}

