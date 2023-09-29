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
    public class TbRolDALImpl : ITbRolDAL
    {
        private UnidadDeTrabajo<TbRol> unidad;
        GestionBuenCosermuContext context;
        public TbRolDALImpl(GestionBuenCosermuContext context)
        {
            this.context = context;
        }

        public bool Add(TbRol entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
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

        public void AddRange(IEnumerable<TbRol> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbRol> Find(Expression<Func<TbRol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TbRol Get(int id)
        {
            try
            {
                TbRol rol = null;
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
                {
                    rol = unidad.genericDAL.Get(id);
                }
                return rol;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<TbRol> GetAll()
        {
            try
            {
                IEnumerable<TbRol> roles = null;
                using (unidad = new UnidadDeTrabajo<TbRol>(context))
                {
                    roles = unidad.genericDAL.GetAll();
                }
                return roles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TbRol entity)
        {
            bool result = false;
            try
            {
                using ( unidad = new UnidadDeTrabajo<TbRol>(context))
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

        public void RemoveRange(IEnumerable<TbRol> entities)
        {
            throw new NotImplementedException();
        }

        public TbRol SingleOrDefault(Expression<Func<TbRol, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbRol entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbRol> unidad = new UnidadDeTrabajo<TbRol>(context))
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
