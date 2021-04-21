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
    public class ProfesoresController : Controller
    {
        public ServiceProfesor servicio = new ServiceProfesor();

        public ProfesoresController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var profesor = servicio.obtenerTodos();
            return View(profesor);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var profesor = new Profesor();
            // Si el id tiene un valor; entonces se procede  a buscar un estudiante
            if (id.HasValue)
            {
                profesor = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            ViewData["Operacion"] = operacion;
            return View(profesor);
        }

        [HttpPost]
        public ActionResult Form(Profesor profesor)
        {
            try
            {
                // Validamos que el modelo carrera sea valido
                // segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid)
                {
                    // Si el ID es 0; entonces se esta insertando
                    if (profesor.id == 0)
                    {
                        servicio.insertar(profesor);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                        servicio.modificar(profesor.id, profesor);
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
                // Eliminar un profesor
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