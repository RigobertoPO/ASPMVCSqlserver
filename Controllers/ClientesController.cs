using MVCSqlserver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCSqlserver.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult ObtenerDatos()
        {
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                var listaClientes = _context.Clientes.ToList();
                return View(listaClientes);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                if (!ModelState.IsValid)
                {
                    return View(cliente);
                }

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction(nameof(ObtenerDatos));
            }
        }
       
        public ActionResult Delete(string id)
        {
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                var usuario = _context.Clientes.Find(id);

                if (usuario == null)
                    return NotFound();

                return View(usuario);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                var usuario = _context.Clientes.Find(id);

                if (usuario != null)
                {
                    _context.Clientes.Remove(usuario);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(ObtenerDatos));
            }
        }
        public ActionResult Edit(string id)
        {
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                var usuario = _context.Clientes.Find(id);

                if (usuario == null)
                    return NotFound();

                return View(usuario);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);
            using (Models.ClientesModelo _context = new Models.ClientesModelo())
            {
                var c = (from cl in _context.Clientes
                         where cl.IdCliente == cliente.IdCliente
                         select cl).FirstOrDefault();
                if (c != null)
                {
                    c = cliente;
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(ObtenerDatos));
            }
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}