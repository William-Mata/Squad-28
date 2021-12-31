#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult DadosCliente(int id)
        {
            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            return View();
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


            return RedirectToAction("DadosCliente");
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

            return RedirectToAction("Home");
        }

        /* Retorna Dados do Cliente e a Pacote */
        public IActionResult PacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditPacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            
            if(cliente != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();

            }

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_ModalPacoteClEdit", cliente);
        }


        [HttpPost]
        public IActionResult EditPacoteCliente(Cliente cliente)
        {

            var IdV = cliente.Id_Pacote;
            var pacote = _context.Pacote.Find(IdV);

            if (pacote != null)
            {
                _context.Pacote.Remove(pacote);

            }
            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return RedirectToAction("PacoteCliente");
        }



        [HttpGet]
        public IActionResult DetailPacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();
            };

            return PartialView("_ModalPacoteClDetalhes", cliente);
        }

        [HttpGet]
        public IActionResult DeletePacoteCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                var pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();
            }

            return PartialView("_ModalPacoteClDelete", cliente); 
        }

        [HttpPost]
        public IActionResult DeletePacoteCliente(Cliente cliente)
        {
            var clienteDel = _context.Cliente.Where(cl => cl.IdCliente == cliente.IdCliente).FirstOrDefault();
            var pacote = _context.Pacote.Where(v => v.IdPacote == cliente.Id_Pacote).FirstOrDefault();

            if ((cliente.IdCliente > 0) && (cliente.IdCliente != null))
            {
                _context.Cliente.Remove(clienteDel);
                _context.Pacote.Remove(pacote);
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Home");
        }
    }
}


/*
            <div class="form-group">
                <label asp-for="Pacote.Origem" class="control-label"></label>
                <input asp-for="Pacote.Origem" class="form-control" />
                <span asp-validation-for="Pacote.Origem" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Pacote.Pacote.Destino" class="control-label"></label>
                <input asp-for="Pacote.Pacote.Destino" class="form-control" />
                <span asp-validation-for="Pacote.Pacote.Destino" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Pacote.Pacote.Valor" class="control-label"></label>
                <input asp-for="Pacote.Pacote.Valor" class="form-control" />
                <span asp-validation-for="Pacote.Pacote.Valor" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Pacote.Pacote.DataInicio" class="control-label"></label>
                <input asp-for="Pacote.Pacote.DataInicio" class="form-control" />
                <span asp-validation-for="Pacote.Pacote.DataInicio" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Pacote.Pacote.DataFim" class="control-label"></label>
                <input asp-for="Pacote.Pacote.DataFim" class="form-control" />
                <span asp-validation-for="Pacote.Pacote.DataFim" class="text-danger"></span>
            </div>
         */