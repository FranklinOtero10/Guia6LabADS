using ADSProject.DAL;
using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.Services
{
    public class ServiceGrupo
    {
        public GrupoDAL grupoDal = new GrupoDAL();

        // Para insertar estudiante
        public int insertar(Grupo grupo)
        {
            try
            {
                return grupoDal.insertarGrupo(grupo);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificar(int id, Grupo grupo)
        {
            try
            {
                return grupoDal.modificarGrupo(id, grupo);
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
                return grupoDal.eliminarGrupo(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Grupo> obtenerTodos()
        {
            return grupoDal.obtenerTodos();
        }

        // Para obtener por ID.
        public Grupo obtenerPorID(int id)
        {
            try
            {
                return grupoDal.obtenerPorID(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}