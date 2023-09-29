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
    public class TbBitacoraDALImpl :ITbBitacoraDAL                              
        //soporte
    {

        GestionBuenCosermuContext context;

        public TbBitacoraDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new GestionBuenCosermuContext();
        }

        public TbBitacoraDALImpl(GestionBuenCosermuContext gestionBuenCosermuContext) //recibe por parametro la conexión
        {
            this.context = gestionBuenCosermuContext;
        }



        //Método para crear un tiposoporte                                   //Tsoporte

        public bool Add(TbBitacora entity)
        {
            try
            {
                using (UnidadDeTrabajo<TbBitacora> unidad = new UnidadDeTrabajo<TbBitacora>(context))
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
        public TbBitacora Get(int idbitacora)
        {
            try
            {
                TbBitacora tbitacora;
                using (UnidadDeTrabajo<TbBitacora> unidad = new UnidadDeTrabajo<TbBitacora>(context))
                {
                    tbitacora = unidad.genericDAL.Get(idbitacora);
                }
                return tbitacora;
            }
            catch (Exception)
            {

                throw;
            }
        }

                                                //todo

    
     
     

        public IEnumerable<TbBitacora> GetAll()
        {
            try
            {
                IEnumerable<TbBitacora> tbitacora;
                using (UnidadDeTrabajo<TbBitacora> unidad = new UnidadDeTrabajo<TbBitacora>(context))
                {
                    tbitacora = unidad.genericDAL.GetAll();
                }
                return tbitacora;
            }
            catch (Exception)
            {

                throw;
            }
        }   
                                                                                  //remove
        public bool Remove(TbBitacora entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TbBitacora> unidad = new UnidadDeTrabajo<TbBitacora>(context))
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
        public bool Update(TbBitacora entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TbBitacora> unidad = new UnidadDeTrabajo<TbBitacora>(context))
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

        public void RemoveRange(IEnumerable<TbBitacora> entities)
        {
            throw new NotImplementedException();
        }

        public TbBitacora SingleOrDefault(Expression<Func<TbBitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TbBitacora> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TbBitacora> Find(Expression<Func<TbBitacora, bool>> predicate)
        {
            throw new NotImplementedException();
        }

     
    }
}
