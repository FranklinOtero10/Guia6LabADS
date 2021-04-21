using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class MateriaDAL
    {
        // Listado de Materias, a nivel de memoria del proyecto
        public static List<Materia> lstMateria = new List<Materia>();

        public MateriaDAL() { }

        public int insertarMateria(Materia materia)
        {
            try
            {
                // Si el listado tiene elementos entonces se genera el ID.
                if (lstMateria.Count > 0)
                {
                    materia.id = lstMateria.Last().id + 1;
                }
                else
                {
                    // Si el listado esta vacio entonces el id será por default 1
                    materia.id = 1;
                }
                lstMateria.Add(materia);
                return materia.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarMateria(int id, Materia materia)
        {
            try
            {
                // Buscando el indice en la lista
                lstMateria[lstMateria.FindIndex(temp => temp.id == id)] = materia;
                return materia.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminarMateria(int id)
        {
            try
            {
                lstMateria.RemoveAt(lstMateria.FindIndex(aux => aux.id == id));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Materia> obtenerTodos()
        {
            return lstMateria;
        }
        
        public Materia obtenerPorID(int id)
        {
            try
            {
                var elementos = lstMateria.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}