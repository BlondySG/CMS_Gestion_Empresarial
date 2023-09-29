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
    public class TbSoporteClienteDALImpl : ITbSoporteClienteDAL
    {


        GestionBuenCosermuContext context;

        public TbSoporteClienteDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext();
        }

        public TbSoporteClienteDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }



        public bool Add(TbSoporteCliente entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbSoporteCliente> unidad = new UnidadDeTrabajo<TbSoporteCliente>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)                   //SoporteCliente
            {

                return false;
            }
        }

        public void AddRange(IEnumerable<TbSoporteCliente> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbSoporteCliente> Find(Expression<Func<TbSoporteCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TbSoporteCliente Get(int idSCli)
        {
            try
            {
                TbSoporteCliente tsoportec;
                using (UnidadDeTrabajo<TbSoporteCliente> unidad = new UnidadDeTrabajo<TbSoporteCliente>(context))
                {
                    tsoportec = unidad.genericDAL.Get(idSCli);
                }
                return tsoportec;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbSoporteCliente> GetAll()
        {
            try
            {
                IEnumerable<TbSoporteCliente> tsoportec;
                using (UnidadDeTrabajo<TbSoporteCliente> unidad = new UnidadDeTrabajo<TbSoporteCliente>(context))
                {
                    tsoportec = unidad.genericDAL.GetAll();
                }
                return tsoportec;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(TbSoporteCliente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbSoporteCliente> unidad = new UnidadDeTrabajo<TbSoporteCliente>(context))
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

        public void RemoveRange(IEnumerable<TbSoporteCliente> entities)
        {
            throw new NotImplementedException();
        }

        public TbSoporteCliente SingleOrDefault(Expression<Func<TbSoporteCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(TbSoporteCliente entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbSoporteCliente> unidad = new UnidadDeTrabajo<TbSoporteCliente>(context))
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
