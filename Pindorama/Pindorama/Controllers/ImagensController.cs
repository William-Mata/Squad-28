using Microsoft.AspNetCore.Mvc;
using Pindorama.Data;
using Pindorama.Models;

namespace Imagens.Controllers
{
    public class ImagensController : Controller
    {

        private PindoramaDbContext _context;

        public ImagensController(PindoramaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<int> imagens = _context.Imagem.Select(m => m.IdImg).ToList();
            return View(imagens);
        }

        [HttpPost]
        public IActionResult UploadImagem(IList<IFormFile> arquivos, int id)
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

                var pacote = _context.Pacote.Where(p => p.IdPacote == id).FirstOrDefault();

                pacote.Imagem = imagemEntity;

                _context.Update(pacote);
                _context.Imagem.Add(imagemEntity);
                _context.SaveChanges();
            }

            return RedirectToAction();
        }

        [HttpGet]
        public FileStreamResult VerImagem(int id)
        {
            Imagem imagem = _context.Imagem.FirstOrDefault(m => m.IdImg == id);

            MemoryStream ms = new MemoryStream(imagem.Dados);
            return new FileStreamResult(ms, imagem.ContentType);


        }


        [HttpGet]
        public IActionResult DeleteImagem(int id)
        {
            var imagem = _context.Imagem.Where(i => i.IdImg == id).FirstOrDefault();


            return View(imagem); ;
        }

        [HttpPost]
        public IActionResult DeleteImagem(Imagem imagem)
        {
            var id = imagem.IdImg;

            var imgDel = _context.Imagem.Find(id);

            if ((id > 0) && (id != null))
            {
                _context.Imagem.Remove(imgDel);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("PacoteAldeia");
        }
    }
}