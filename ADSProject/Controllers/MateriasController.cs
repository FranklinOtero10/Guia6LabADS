using ADSProject.Models;
using ADSProject.Services;
using ADSProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADSProject.Controllers
{
    public class MateriasController : Controller
    {
        public ServiceMateria servicio = new ServiceMateria();

        public MateriasController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var materia = servicio.obtenerTodos();
            return View(materia);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var materia = new Materia();
            
            if (id.HasValue)
            {
                materia = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operacion;
            return View(materia);
        }

        [HttpPost]
        public ActionResult Form(Materia materia)
        {
            try
            {
                // Validamos que el modelo carrera sea valido
                // segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid)
                {
                    // Si el ID es 0; entonces se esta insertando
                    if (materia.id == 0)
                    {
                        servicio.insertar(materia);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                        servicio.modificar(materia.id, materia);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                servicio.eliminar(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}