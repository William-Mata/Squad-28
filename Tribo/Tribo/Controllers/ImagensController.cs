﻿using Microsoft.AspNetCore.Mvc;
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
            List<int> imagens = _context.Imagem.Select(m => m.IdImg).ToList();
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
                _context.Imagem.Add(imagemEntity);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
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
        public IActionResult DeleteContato(Imagem imagem)
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

            return RedirectToAction("PacoteTribo");
        }
    }
}