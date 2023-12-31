﻿using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TbArticuloDALImpl : ITbArticuloDAL
    {

        GestionBuenCosermuContext context;

        public TbArticuloDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext();
        }


        public TbArticuloDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }



        //Método para crear un articulo
        public bool Add(TbArticulo entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbArticulo> unidad = new UnidadDeTrabajo<TbArticulo>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }
        }



        //Obtener articulo  por un id
        public TbArticulo Get(int idArticulo)
        {
            try
            {
                TbArticulo articulo;
                using (UnidadDeTrabajo<TbArticulo> unidad = new UnidadDeTrabajo<TbArticulo>(context))
                {
                    articulo = unidad.genericDAL.Get(idArticulo);
                }
                return articulo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbArticulo> GetAll()
        {
            try
            {
                IEnumerable<TbArticulo> articulos;
                using (UnidadDeTrabajo<TbArticulo> unidad = new UnidadDeTrabajo<TbArticulo>(context))
                {
                    articulos = unidad.genericDAL.GetAll();
                }
                return articulos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Eliminar un articulo
        public bool Remove(TbArticulo entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbArticulo> unidad = new UnidadDeTrabajo<TbArticulo>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }



        //Actualizar un articulo
        public bool Update(TbArticulo entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbArticulo> unidad = new UnidadDeTrabajo<TbArticulo>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }

        public void AddRange(IEnumerable<TbArticulo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbArticulo> Find(Expression<Func<TbArticulo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TbArticulo> entities)
        {
            throw new NotImplementedException();
        }

        public TbArticulo SingleOrDefault(Expression<Func<TbArticulo, bool>> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
