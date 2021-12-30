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

        /* Retorna Dados do Cliente e a Viagem */
        public IActionResult ViagemCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.viagem = _context.Viagem.Where(v => v.IdViagem == cliente.Id_Viagem).FirstOrDefault();
            }

            return View();
        }

        [HttpGet]
        public IActionResult EditViagemCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();
            
            if(cliente != null)
            {
                ViewBag.viagem = _context.Viagem.Where(v => v.IdViagem == cliente.Id_Viagem).FirstOrDefault();

            }

            if (cliente == null)
            {
                return NotFound();
            }

            return PartialView("_ModalViagemClEdit", cliente);
        }


        [HttpPost]
        public IActionResult EditViagemCliente(Cliente cliente)
        {

            var IdV = cliente.Id_Viagem;
            var viagem = _context.Viagem.Find(IdV);

            if (viagem != null)
            {
                _context.Viagem.Remove(viagem);

            }
            _context.Cliente.Update(cliente);
            _context.SaveChanges();

            return RedirectToAction("ViagemCliente");
        }



        [HttpGet]
        public IActionResult DetailViagemCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                ViewBag.viagem = _context.Viagem.Where(v => v.IdViagem == cliente.Id_Viagem).FirstOrDefault();
            };

            return PartialView("_ModalViagemClDetalhes", cliente);
        }

        [HttpGet]
        public IActionResult DeleteViagemCliente(int id)
        {

            var cliente = _context.Cliente.Where(cl => cl.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                var viagem = _context.Viagem.Where(v => v.IdViagem == cliente.Id_Viagem).FirstOrDefault();
            }

            return PartialView("_ModalViagemClDelete", cliente); 
        }

        [HttpPost]
        public IActionResult DeleteViagemCliente(Cliente cliente)
        {
            var clienteDel = _context.Cliente.Where(cl => cl.IdCliente == cliente.IdCliente).FirstOrDefault();
            var viagem = _context.Viagem.Where(v => v.IdViagem == cliente.Id_Viagem).FirstOrDefault();

            if ((cliente.IdCliente > 0) && (cliente.IdCliente != null))
            {
                _context.Cliente.Remove(clienteDel);
                _context.Viagem.Remove(viagem);
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
                <label asp-for="Viagem.Origem" class="control-label"></label>
                <input asp-for="Viagem.Origem" class="form-control" />
                <span asp-validation-for="Viagem.Origem" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Viagem.Pacote.Destino" class="control-label"></label>
                <input asp-for="Viagem.Pacote.Destino" class="form-control" />
                <span asp-validation-for="Viagem.Pacote.Destino" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Viagem.Pacote.Valor" class="control-label"></label>
                <input asp-for="Viagem.Pacote.Valor" class="form-control" />
                <span asp-validation-for="Viagem.Pacote.Valor" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Viagem.Pacote.DataInicio" class="control-label"></label>
                <input asp-for="Viagem.Pacote.DataInicio" class="form-control" />
                <span asp-validation-for="Viagem.Pacote.DataInicio" class="text-danger"></span>
            </div>
            <div class="form-group">
                <label asp-for="Viagem.Pacote.DataFim" class="control-label"></label>
                <input asp-for="Viagem.Pacote.DataFim" class="form-control" />
                <span asp-validation-for="Viagem.Pacote.DataFim" class="text-danger"></span>
            </div>
         */