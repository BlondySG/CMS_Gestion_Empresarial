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
    public class TbProveedorDALImpl : ITbProveedorDAL
    {
        private UnidadDeTrabajo<TbProveedor> unidad;
        GestionBuenCosermuContext context;
        public TbProveedorDALImpl(GestionBuenCosermuContext context)
        {
            this.context = context;
        }

        public bool Add(TbProveedor entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbProveedor>(context))
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

        public void AddRange(IEnumerable<TbProveedor> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbProveedor> Find(Expression<Func<TbProveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TbProveedor Get(int id)
        {
            try
            {
                TbProveedor proveedor = null;
                using (unidad = new UnidadDeTrabajo<TbProveedor>(context))
                {
                    proveedor = unidad.genericDAL.Get(id);
                }
                return proveedor;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<TbProveedor> GetAll()
        {
            try
            {
                IEnumerable<TbProveedor> proveedores = null;
                using (unidad = new UnidadDeTrabajo<TbProveedor>(context))
                {
                    proveedores = unidad.genericDAL.GetAll();
                }
                return proveedores;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TbProveedor entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbProveedor>(context))
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

        public void RemoveRange(IEnumerable<TbProveedor> entities)
        {
            throw new NotImplementedException();
        }

        public TbProveedor SingleOrDefault(Expression<Func<TbProveedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbProveedor entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbProveedor> unidad = new UnidadDeTrabajo<TbProveedor>(context))
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
