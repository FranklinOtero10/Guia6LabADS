using ADSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADSProject.DAL
{
    public class GrupoDAL
    {
        public static List<Grupo> lstGrupos = new List<Grupo>();

        public GrupoDAL() { }

        public int insertarGrupo(Grupo grupo)
        {
            try
            {
                // Si el listado tiene elementos entonces se genera el ID.
                if (lstGrupos.Count > 0)
                {
                    grupo.id = lstGrupos.Last().id + 1;
                }
                else
                {
                    // Si el listado esta vacio entonces el id será por default 1
                    grupo.id = 1;
                }
                lstGrupos.Add(grupo);
                return grupo.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int modificarGrupo(int id, Grupo grupo)
        {
            try
            {
                // Buscando el indice en la lista
                lstGrupos[lstGrupos.FindIndex(temp => temp.id == id)] = grupo;
                return grupo.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool eliminarGrupo(int id)
        {
            try
            {
                lstGrupos.RemoveAt(lstGrupos.FindIndex(aux => aux.id == id));
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Para listar todos los grupos
        public List<Grupo> obtenerTodos()
        {
            return lstGrupos;
        }

        public Grupo obtenerPorID(int id)
        {
            try
            {
                var elementos = lstGrupos.Find(temp => temp.id == id);
                return elementos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}