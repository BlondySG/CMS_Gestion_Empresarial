using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TbDatosVentaDALImpl : ITbDatosVentaDAL
    {
        private UnidadDeTrabajo<TbDatosVenta> unidad;
        GestionBuenCosermuContext context;
        public TbDatosVentaDALImpl(GestionBuenCosermuContext context)
        {
            this.context = context;
        }
        public bool Add(TbDatosVenta entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbDatosVenta>(context))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<TbDatosVenta> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbDatosVenta> Find(Expression<Func<TbDatosVenta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TbDatosVenta Get(int id)
        {
            try
            {
                TbDatosVenta venta = null;
                using (unidad = new UnidadDeTrabajo<TbDatosVenta>(context))
                {
                    venta = unidad.genericDAL.Get(id);
                }
                return venta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbDatosVenta> GetAll()
        {
            try
            {
                IEnumerable<TbDatosVenta> ventas = null;
                using (unidad = new UnidadDeTrabajo<TbDatosVenta>(context))
                {
                    ventas = unidad.genericDAL.GetAll();
                }
                return ventas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TbDatosVenta entity)
        {
            bool result = false;
            try
            {
                using (unidad = new UnidadDeTrabajo<TbDatosVenta>(context))
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

        public void RemoveRange(IEnumerable<TbDatosVenta> entities)
        {
            throw new NotImplementedException();
        }

        public TbDatosVenta SingleOrDefault(Expression<Func<TbDatosVenta, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbDatosVenta entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbDatosVenta> unidad = new UnidadDeTrabajo<TbDatosVenta>(context))
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
    }
}
