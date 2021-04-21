using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceProfesor
    {
        public ProfesorDAL profesorDal = new ProfesorDAL();

        // Para insertar profesor
        public int insertar(Profesor profesor)
        {
            try
            {
                return profesorDal.insertarProfesor(profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificar(int id, Profesor profesor)
        {
            try
            {
                return profesorDal.modificarProfesor(id, profesor);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para eliminar
        public bool eliminar(int id)
        {
            try
            {
                return profesorDal.eliminarProfesor(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Profesor> obtenerTodos()
        {
            return profesorDal.obtenerTodos();
        }

        // Para obtener por ID.
        public Profesor obtenerPorID(int id)
        {
            try
            {
                return profesorDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}