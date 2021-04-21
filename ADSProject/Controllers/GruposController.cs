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
    public class GruposController : Controller
    {
        public ServiceGrupo servicio = new ServiceGrupo();

        public GruposController() { }


        [HttpGet]
        public ActionResult Index()
        {
            var grupo = servicio.obtenerTodos();
            return View(grupo);
        }

        [HttpGet]
        public ActionResult Form(int? id, Operacion operacion)
        {
            var grupo = new Grupo();
            // Si el id tiene un valor; entonces se procede  a buscar un estudiante
            if (id.HasValue)
            {
                grupo = servicio.obtenerPorID(id.Value);
            }
            // Indica la operacion que estamos realizando en el formulario
            
            ViewData["Operacion"] = operacion;
            return View(grupo);
        }

        [HttpPost]
        public ActionResult Form(Grupo grupo)
        {
            try
            {
                // Validamos que el modelo carrera sea valido
                // segun las validaciones que le agregamos anteriormente
                if (ModelState.IsValid)
                {
                    // Si el ID es 0; entonces se esta insertando
                    if (grupo.id == 0)
                    {
                        servicio.insertar(grupo);
                    }
                    else
                    {
                        // Si el ID es distinto de cero entonces estamos modificando
                        servicio.modificar(grupo.id, grupo);
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
                // Eliminar un grupo
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