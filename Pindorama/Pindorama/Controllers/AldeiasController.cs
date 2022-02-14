using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Pindorama.Data;
using Pindorama.Models;


namespace Pindorama.Controllers
{
    [Authorize(Roles = "Aldeia")]
    public class AldeiasController : Controller
    {

        private readonly PindoramaDbContext _context;


        public AldeiasController(PindoramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DadosAldeia()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(tb => tb.Email_User.Equals(userEmail)).FirstOrDefault();


            if (userEmail != null)
            {

                if (aldeia_parceira != null)
                {
                    return View(aldeia_parceira);
                }
                else
                {
                    return RedirectToAction("CadastrarAldeia", "Aldeias");
                }
            }
            else
            {
                return RedirectToAction("Pages", "Home");
            }

        }

        [HttpGet]
        public IActionResult CadastrarAldeia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarAldeia(AldeiaParceira aldeiaParceira)
        {

            if (aldeiaParceira != null)
            {
                _context.Add(aldeiaParceira);
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
        public IActionResult EditDadosAldeia(int id)
        {
            var aldeia_parceira = _context.AldeiaParceira.Where(t => t.IdAldeia == id).FirstOrDefault();

            if (aldeia_parceira == null)
            {
                return NotFound();
            }

            return PartialView("_ModalDadosTrbEdit", aldeia_parceira);
        }


        [HttpPost]
        public IActionResult EditDadosAldeia(AldeiaParceira aldeia_parceira)
        {
            _context.AldeiaParceira.Update(aldeia_parceira);
            _context.SaveChanges();

            return RedirectToAction("DadosAldeia", new { id = aldeia_parceira.IdAldeia });
        }


        [HttpGet]
        public IActionResult DetailDadosAldeia(int id)
        {
            var aldeia_parceira = _context.AldeiaParceira.Where(cl => cl.IdAldeia == id).FirstOrDefault();

            return PartialView("_ModalDadosTrbDetalhes", aldeia_parceira);
        }

        [HttpGet]
        public IActionResult DeleteDadosAldeia(int id)
        {
            var aldeia_parceira = _context.AldeiaParceira.Where(cl => cl.IdAldeia == id).FirstOrDefault();


            return PartialView("_ModalDadosTrbDelete", aldeia_parceira);
        }

        [HttpPost]
        public IActionResult DeleteDadosAldeia(AldeiaParceira aldeia_parceira)
        {
            var id = aldeia_parceira.IdAldeia;

            var aldeia_parceiraDel = _context.AldeiaParceira.Find(id);

            if ((id > 0))
            {
                _context.AldeiaParceira.Remove(aldeia_parceiraDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Home", "Pages");
        }

        /* Retorna Dados da Aldeia e a Pacote */
        [HttpGet]
        public IActionResult PacoteAldeia()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();



            if (aldeia_parceira != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.Aldeia.IdAldeia == aldeia_parceira.IdAldeia).ToList();
                return View(aldeia_parceira);
            }
            else if ((aldeia_parceira != null) && (ViewBag.pacote == null))
            {
                return RedirectToAction("CadastrarPacoteAldeia", new { id = aldeia_parceira.IdAldeia });
            }
            else
            {
                return RedirectToAction("Home", "Pages");
            }

        }

        [HttpGet]
        public IActionResult CadastrarPacoteAldeia()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            if (aldeia != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Pages");
            }
        }

        [HttpPost]
        public IActionResult CadastrarPacoteAldeia(Pacote pacote)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            if ((pacote != null) && (aldeia != null))
            {
                pacote.Aldeia = aldeia;
                _context.Pacote.Add(pacote);
                aldeia.Pacote.Add(pacote);
                _context.AldeiaParceira.Update(aldeia);
                _context.SaveChanges();

                return RedirectToAction("PacoteAldeia", "Aldeias", new { id = aldeia.IdAldeia });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Não foi possivel realizar o cadastro.");
                return View();

            }

        }

        [HttpGet]
        public IActionResult AddImagemPct(int id)
        {
            var pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();
            return PartialView("_ModalPacoteTrbAddImg", pacote);

        }

        [HttpPost]
        public IActionResult AddImagemPct(IList<IFormFile> arquivos, int id)
        {

            var pacote = _context.Pacote.Where(pc => pc.IdPacote == id).FirstOrDefault();


            IFormFile imagemEnviada = arquivos.FirstOrDefault();
            if (imagemEnviada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemEnviada.OpenReadStream().CopyTo(ms);
                Imagem imagemEntity = new Imagem()
                {
                    Nome = imagemEnviada.Name,
                    Dados = ms.ToArray(),
                    ContentType = imagemEnviada.ContentType
                };


                if (pacote.Id_Imagem == null)
                {
                    _context.Imagem.Add(imagemEntity);
                    pacote.Imagem = imagemEntity;
                    _context.Pacote.Update(pacote);
                    _context.SaveChanges();
                }
                else if (pacote.Id_Imagem != null)
                {
                    imagemEntity.IdImg = (int)pacote.Id_Imagem;
                    _context.Imagem.Update(imagemEntity);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("PacoteAldeia");
        }


        [HttpGet]
        public IActionResult EditPacoteAldeia(int id)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            var pacote = _context.Pacote.Where(pc => pc.IdPacote == id).FirstOrDefault();


            if (aldeia_parceira == null)
            {
                return NotFound();
            }

            return PartialView("_ModalPacoteTrbEdit", pacote);
        }


        [HttpPost]
        public IActionResult EditPacoteAldeia(Pacote pacote)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();


            if (pacote != null)
            {
                _context.Pacote.Update(pacote);
                _context.SaveChanges();
            }

            return RedirectToAction("PacoteAldeia");
        }



        [HttpGet]
        public IActionResult DetailPacoteAldeia(int id)
        {

            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            if (aldeia_parceira != null)
            {
                ViewBag.pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();
            };

            return PartialView("_ModalPacoteTrbDetalhes", aldeia_parceira);
        }

        [HttpGet]
        public IActionResult DeletePacoteAldeia(int id)
        {
            var pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();
            return PartialView("_ModalPacoteTrbDelete", pacote);
        }

        [HttpPost]
        public IActionResult DeletePacoteAldeia(Pacote pacote)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceiraDel = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            var pacoteDel = _context.Pacote.Where(pd => pd.IdPacote == pacote.IdPacote).FirstOrDefault();


            var img = _context.Imagem.Where(i => i.IdImg == pacoteDel.Id_Imagem).FirstOrDefault();

            if (aldeia_parceiraDel != null)
            {
                if (img != null)
                {
                    pacoteDel.Id_Imagem = null;
                    _context.Imagem.Remove(img);
                }

                _context.Pacote.Remove(pacoteDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("PacoteAldeia", new { id = aldeia_parceiraDel.IdAldeia });
        }


        /* Retorna Dados da Aldeia e Artesanato */
        [HttpGet]
        public IActionResult ArtesanatoAldeia()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();



            if (aldeia_parceira != null)
            {
                ViewBag.artesanatos = _context.Artesanato.Where(v => v.Aldeia.IdAldeia == aldeia_parceira.IdAldeia).ToList();
                return View(aldeia_parceira);
            }
            else if ((aldeia_parceira != null) && (ViewBag.artesanato == null))
            {
                return RedirectToAction("CadastrarArtesanatoAldeia", new { id = aldeia_parceira.IdAldeia });
            }
            else
            {
                return RedirectToAction("Home", "Pages");
            }

        }

        [HttpGet]
        public IActionResult CadastrarArtesanatoAldeia()
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();

            if (aldeia != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Home", "Pages");
            }
        }

        [HttpPost]
        public IActionResult CadastrarArtesanatoAldeia(Artesanato artesanato)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();

            if ((artesanato != null) && (aldeia != null))
            {
                artesanato.Aldeia = aldeia;
                _context.Artesanato.Add(artesanato);
                aldeia.Artesanato.Add(artesanato);
                _context.AldeiaParceira.Update(aldeia);
                _context.SaveChanges();

                return RedirectToAction("ArtesanatoAldeia", "Aldeias", new { id = aldeia.IdAldeia });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Não foi possivel realizar o cadastro.");
                return View();

            }

        }

        [HttpGet]
        public IActionResult AddImagemArt(int id)
        {
            var artesanato = _context.Artesanato.Where(art => art.IdArtesanato == id).FirstOrDefault();
            return PartialView("_ModalArtesanatoTrbAddImg", artesanato);

        }

        [HttpPost]
        public IActionResult AddImagemArt(IList<IFormFile> arquivos, int id)
        {
            var tipo = "Artesanato";

            var artesanato = _context.Artesanato.Where(art => art.IdArtesanato == id).FirstOrDefault();


            IFormFile imagemEnviada = arquivos.FirstOrDefault();
            if (imagemEnviada != null)
            {
                MemoryStream ms = new MemoryStream();
                imagemEnviada.OpenReadStream().CopyTo(ms);
                Imagem imagemEntity = new Imagem()
                {
                    Nome = imagemEnviada.Name,
                    Dados = ms.ToArray(),
                    ContentType = imagemEnviada.ContentType
                };


                if (artesanato.Id_Imagem == null)
                {
                    _context.Imagem.Add(imagemEntity);
                    artesanato.Imagem = imagemEntity;
                    _context.Artesanato.Update(artesanato);
                    _context.SaveChanges();
                }
                else if (artesanato.Id_Imagem != null)
                {
                    imagemEntity.IdImg = (int)artesanato.Id_Imagem;
                    _context.Imagem.Update(imagemEntity);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("ArtesanatoAldeia");
        }


        [HttpGet]
        public IActionResult EditArtesanatoAldeia(int id)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(pc => pc.Email_User == userEmail).FirstOrDefault();

            var artesanato = _context.Artesanato.Where(art=> art.IdArtesanato == id).FirstOrDefault();


            if (aldeia_parceira == null)
            {
                return NotFound();
            }

            return PartialView("_ModalArtesanatoTrbEdit", artesanato);
        }


        [HttpPost]
        public IActionResult EditArtesanatoAldeia(Artesanato artesanato)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();


            if (artesanato != null)
            {
                _context.Artesanato.Update(artesanato);
                _context.SaveChanges();
            }

            return RedirectToAction("ArtesanatoAldeia");
        }



        [HttpGet]
        public IActionResult DetailArtesanatoAldeia(int id)
        {

            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceira = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();

            if (aldeia_parceira != null)
            {
                ViewBag.artesanato = _context.Artesanato.Where(art => art.IdArtesanato == id).FirstOrDefault();
            };

            return PartialView("_ModalArtesanatoTrbDetalhes", aldeia_parceira);
        }

        [HttpGet]
        public IActionResult DeleteArtesanatoAldeia(int id)
        {
            var artesanato = _context.Artesanato.Where(art => art.IdArtesanato == id).FirstOrDefault();
            return PartialView("_ModalArtesanatoTrbDelete", artesanato);
        }

        [HttpPost]
        public IActionResult DeleteArtesanatoAldeia(Artesanato artesanato)
        {
            var userEmail = this.User.FindFirstValue(ClaimTypes.Name);
            var aldeia_parceiraDel = _context.AldeiaParceira.Where(art => art.Email_User == userEmail).FirstOrDefault();

            var artesanatoDel = _context.Artesanato.Where(art => art.IdArtesanato == artesanato.IdArtesanato).FirstOrDefault();


            var img = _context.Imagem.Where(i => i.IdImg == artesanatoDel.Id_Imagem).FirstOrDefault();

            if (aldeia_parceiraDel != null)
            {
                if (img != null)
                {
                    artesanatoDel.Id_Imagem = null;
                    _context.Imagem.Remove(img);
                }

                _context.Artesanato.Remove(artesanatoDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("ArtesanatoAldeia", new { id = aldeia_parceiraDel.IdAldeia });
        }

    }
}
