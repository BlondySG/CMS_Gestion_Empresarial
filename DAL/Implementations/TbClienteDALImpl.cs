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
    public class TbClienteDALImpl : ITbClienteDAL
    {
        GestionBuenCosermuContext context;

        public TbClienteDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext(); 
        }


        public TbClienteDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }


        //Método para crear un Cliente
        public bool Add(TbCliente entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
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


        //Obtener cliente  por un id
        public TbCliente Get(int idCliente)
        {
            try
            {
                TbCliente cliente;
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
                {
                    cliente = unidad.genericDAL.Get(idCliente);
                }
                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TbCliente> GetAll()
        {
            try
            {
                IEnumerable<TbCliente> clientes;
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
                {
                    clientes = unidad.genericDAL.GetAll();
                }
                return clientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Eliminar un cliente
        public bool Remove(TbCliente entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
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


        //Actualizar un cliente
        public bool Update(TbCliente entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbCliente> unidad = new UnidadDeTrabajo<TbCliente>(context))
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



        public void AddRange(IEnumerable<TbCliente> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbCliente> Find(Expression<Func<TbCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TbCliente> entities)
        {
            throw new NotImplementedException();
        }

        public TbCliente SingleOrDefault(Expression<Func<TbCliente, bool>> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
