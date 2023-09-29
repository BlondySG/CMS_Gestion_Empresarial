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
    public class TbDatosCompraDALImpl : ITbDatosCompraDAL
    {
        private UnidadDeTrabajo<TbDatosCompra> unidad;
        GestionBuenCosermuContext context;
        public TbDatosCompraDALImpl(GestionBuenCosermuContext context)
        {
            this.context = context;
        }

        public bool Add(TbDatosCompra entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbDatosCompra>(context))
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

        public void AddRange(IEnumerable<TbDatosCompra> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbDatosCompra> Find(Expression<Func<TbDatosCompra, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TbDatosCompra Get(int id)
        {
            try
            {
                TbDatosCompra compra = null;
                using (unidad = new UnidadDeTrabajo<TbDatosCompra>(context))
                {
                    compra = unidad.genericDAL.Get(id);
                }
                return compra;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<TbDatosCompra> GetAll()
        {
            try
            {
                IEnumerable<TbDatosCompra> compras = null;
                using (unidad = new UnidadDeTrabajo<TbDatosCompra>(context))
                {
                    compras = unidad.genericDAL.GetAll();
                }
                return compras;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TbDatosCompra entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbDatosCompra>(context))
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

        public void RemoveRange(IEnumerable<TbDatosCompra> entities)
        {
            throw new NotImplementedException();
        }

        public TbDatosCompra SingleOrDefault(Expression<Func<TbDatosCompra, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbDatosCompra entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbDatosCompra> unidad = new UnidadDeTrabajo<TbDatosCompra>(context))
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
