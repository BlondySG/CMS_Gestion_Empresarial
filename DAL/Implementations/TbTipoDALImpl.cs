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
    public class TbTipoDALImpl :ITbTipoDAL                                 
        //soporte
    {

        GestionBuenCosermuContext context;

        public TbTipoDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext();
        }

        public TbTipoDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }



        //Método para crear un tiposoporte                                   //Tsoporte

        public bool Add(TbTipo entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbTipo> unidad = new UnidadDeTrabajo<TbTipo>(context))
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

                                                                        //get
        public TbTipo Get(int idTipo)
        {
            try
            {
                TbTipo tsoporte;
                using (UnidadDeTrabajo<TbTipo> unidad = new UnidadDeTrabajo<TbTipo>(context))
                {
                    tsoporte = unidad.genericDAL.Get(idTipo);
                }
                return tsoporte;
            }
            catch (Exception)
            {

                throw;
            }
        }

                                                //todo

    
     
     

        public IEnumerable<TbTipo> GetAll()
        {
            try
            {
                IEnumerable<TbTipo> tsoporte;
                using (UnidadDeTrabajo<TbTipo> unidad = new UnidadDeTrabajo<TbTipo>(context))
                {
                    tsoporte = unidad.genericDAL.GetAll();
                }
                return tsoporte;
            }
            catch (Exception)
            {

                throw;
            }
        }   
                                                                                  //remove
        public bool Remove(TbTipo entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbTipo> unidad = new UnidadDeTrabajo<TbTipo>(context))
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

                                                                                 //update
        public bool Update(TbTipo entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbTipo> unidad = new UnidadDeTrabajo<TbTipo>(context))
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

        public void RemoveRange(IEnumerable<TbTipo> entities)
        {
            throw new NotImplementedException();
        }

        public TbTipo SingleOrDefault(Expression<Func<TbTipo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TbTipo> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbTipo> Find(Expression<Func<TbTipo, bool>> predicate)
        {
            throw new NotImplementedException();
        }

     
    }
}
