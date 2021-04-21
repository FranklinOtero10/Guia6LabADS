using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceMateria
    {
        public MateriaDAL materiaDal = new MateriaDAL();

        public int insertar(Materia materia)
        {
            try
            {
                return materiaDal.insertarMateria(materia);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificar(int id, Materia materia)
        {
            try
            {
                return materiaDal.modificarMateria(id, materia);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                return materiaDal.eliminarMateria(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Materia> obtenerTodos()
        {
            return materiaDal.obtenerTodos();
        }

        public Materia obtenerPorID(int id)
        {
            try
            {
                return materiaDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}