﻿using Microsoft.AspNetCore.Mvc;
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

            ViewBag.tribo_parceira = _context.TriboParceira.Where(tb => tb.IdTribo == id).FirstOrDefault();

            if (ViewBag.tribo_parceira != null)
            {
                return View(ViewBag.tribo_parceira);
            }
            else
            {

                return RedirectToAction("Home", "Pages");
            }

        }


        public IActionResult CadastrarTribo()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CadastrarTribo(TriboParceira triboParceira)
        {

            var triboTeste = _context.TriboParceira.Where(t => t.Email.Equals(triboParceira.Email) || t.IdTribo.Equals(triboParceira.IdTribo)).FirstOrDefault();

            if (triboTeste == null)
            {
                _context.Add(triboParceira);
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

            return RedirectToAction("DadosTribo", new { id = tribo_parceira.IdTribo });
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

            return RedirectToAction("Home", "Pages");
        }

        /* Retorna Dados do Tribo e a Pacote */
        public IActionResult PacoteTribo(int id)
        {

            var tribo_parceira = _context.TriboParceira.Where(pc => pc.IdTribo == id).FirstOrDefault();



            if ((tribo_parceira != null) && (tribo_parceira.Id_Pacote != null))
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
                return View(tribo_parceira);
            }
            else
            {
                return RedirectToAction("CadastrarPacoteTribo", new { id = tribo_parceira.IdTribo });
            }



        }

        [HttpGet]

        public IActionResult CadastrarPacoteTribo(int id)
        {
            var tribo = _context.TriboParceira.Where(tb => tb.IdTribo == id).FirstOrDefault();

            return View(tribo);
        }

        [HttpPost]
        public IActionResult CadastrarPacoteTribo(TriboParceira tribo)
        {

            if ((tribo != null))
            {

                _context.Pacote.Add(tribo.Pacote);
                _context.TriboParceira.Update(tribo);
                _context.SaveChanges();

                return RedirectToAction("PacoteTribo", "Tribos", new { id = tribo.IdTribo });
            }
            else
            {
                ModelState.AddModelError("", "Não foi possivel realizar o cadastro.");
                return View();

            }

        }

        [HttpGet]
        public IActionResult AddImagem(int id)
        {
            var pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();

            return PartialView("_ModalPacoteTrbAddImg", pacote);
        }

        [HttpPost]
        public IActionResult AddImagem(IList<IFormFile> arquivos, Pacote pacote)
        {
            IFormFile imagemEnviada = arquivos.FirstOrDefault();
            if (imagemEnviada != null || imagemEnviada.ContentType.ToLower().StartsWith("image/"))
            {
                MemoryStream ms = new MemoryStream();
                imagemEnviada.OpenReadStream().CopyTo(ms);

                Imagem imagemEntity = new Imagem()
                {
                    Nome = imagemEnviada.Name,
                    Dados = ms.ToArray(),
                    ContentType = imagemEnviada.ContentType
                };


                pacote.Imagem = imagemEntity;

                _context.Update(pacote);
                _context.Imagem.Add(imagemEntity);
                _context.SaveChanges();
            }
            else
            {

            }

            return RedirectToAction("PacoteTribo", new {id = pacote.Tribo.IdTribo});
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

            var IdP = tribo_parceira.Id_Pacote;
            var pacote = _context.Pacote.Find(IdP);

            var IdI = tribo_parceira.Pacote.Id_Imagem;
            var img = _context.Imagem.Find(IdI);


            if (pacote != null)
            {
                _context.Pacote.Update(pacote);


            }

            if (img != null)
            {
                _context.Imagem.Update(img);


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
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == tribo_parceira.Id_Pacote).FirstOrDefault();
            }

            return PartialView("_ModalPacoteTrbDelete", tribo_parceira);
        }

        [HttpPost]
        public IActionResult DeletePacoteTribo(TriboParceira tribo_parceira)
        {
            var tribo_parceiraDel = _context.TriboParceira.Where(tb => tb.IdTribo == tribo_parceira.IdTribo).FirstOrDefault();
            var pacote = _context.Pacote.Where(p => p.IdPacote == tribo_parceiraDel.Id_Pacote).FirstOrDefault();
            var img = _context.Imagem.Where(i => i.IdImg == tribo_parceiraDel.Pacote.Id_Imagem).FirstOrDefault();


            if ((tribo_parceira.IdTribo > 0) && (tribo_parceira.IdTribo != null))
            {
                _context.Pacote.Remove(pacote);
                _context.Imagem.Remove(img);
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

