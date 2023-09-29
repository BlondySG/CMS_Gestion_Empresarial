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
    public class TbSoporteDALImpl : ITbSoporteDAL
    {

        GestionBuenCosermuContext context;

        public TbSoporteDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext();
        }


        public TbSoporteDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }

        public bool Add(TbSoporte entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbSoporte> unidad = new UnidadDeTrabajo<TbSoporte>(context))
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

        public TbSoporte Get(int idSoporte)
        {
            try
            {
                TbSoporte soporte;
                using (UnidadDeTrabajo<TbSoporte> unidad = new UnidadDeTrabajo<TbSoporte>(context))
                {
                    soporte = unidad.genericDAL.Get(idSoporte);
                }
                return soporte;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<TbSoporte> GetAll()
        {
            try
            {
                IEnumerable<TbSoporte> soportes;
                using (UnidadDeTrabajo<TbSoporte> unidad = new UnidadDeTrabajo<TbSoporte>(context))
                {
                    soportes = unidad.genericDAL.GetAll();
                }
                return soportes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(TbSoporte entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbSoporte> unidad = new UnidadDeTrabajo<TbSoporte>(context))
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

        
        public bool Update(TbSoporte entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbSoporte> unidad = new UnidadDeTrabajo<TbSoporte>(context))
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


        public void AddRange(IEnumerable<TbSoporte> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbSoporte> Find(Expression<Func<TbSoporte, bool>> predicate)
        {
            throw new NotImplementedException();

        }
        public void RemoveRange(IEnumerable<TbSoporte> entities)
        {
            throw new NotImplementedException();
        }

        public TbSoporte SingleOrDefault(Expression<Func<TbSoporte, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
