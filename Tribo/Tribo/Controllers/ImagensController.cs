using Microsoft.AspNetCore.Mvc;
using Tribo.Models;

namespace AspNetCore_EnviaExibeImagem.Controllers
{
    public class ImagensController : Controller
    {
    
        private TriboDbContext _context;

        public ImagensController(TriboDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<int> imagens = _context.Imagens.Select(m => m.IdImg).ToList();
            return View(imagens);
        }

        [HttpPost]
        public IActionResult UploadImagem(IList<IFormFile> arquivos)
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
                _context.Imagens.Add(imagemEntity);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public FileStreamResult VerImagem(int id)
        {
            Imagem imagem = _context.Imagens.FirstOrDefault(m => m.IdImg == id);
            MemoryStream ms = new MemoryStream(imagem.Dados);
            return new FileStreamResult(ms, imagem.ContentType);
        }
    }
}