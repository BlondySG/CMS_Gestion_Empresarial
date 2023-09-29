using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbSoporteController : ControllerBase
    {

        private ITbSoporteDAL soporteDAL;

        public TbSoporteController()
        {
            soporteDAL = new TbSoporteDALImpl(new GestionBuenCosermuContext());
        }

        TbSoporte Convertir(TbSoporteModel soporte)
        {
            return new TbSoporte
            {
                IdSoporte = soporte.IdSoporte,
                DescripcionSoporte = soporte.DescripcionSoporte,
                FechaAgendada = soporte.FechaAgendada,
                FechaCierreSoporte = soporte.FechaCierreSoporte,
                Estatus = soporte.Estatus,
                IdCliente = soporte.IdCliente,
                IdEmpleado = soporte.IdEmpleado,
                IdTipo = soporte.IdTipo
            };
        }



        TbSoporteModel Convertir(TbSoporte soporte)
        {

            return new TbSoporteModel
            {
                IdSoporte = soporte.IdSoporte,
                DescripcionSoporte = soporte.DescripcionSoporte,
                FechaAgendada = soporte.FechaAgendada,
                FechaCierreSoporte = soporte.FechaCierreSoporte,
                Estatus = soporte.Estatus,
                IdCliente = soporte.IdCliente,
                IdEmpleado = soporte.IdEmpleado,
                IdTipo = soporte.IdTipo
            };
        }

        #region Obtener
        // GET: api/<TbSoporteController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<TbSoporte> soportes = new List<TbSoporte>();
                soportes = soporteDAL.GetAll().ToList();

                List<TbSoporteModel> resultado = new List<TbSoporteModel>();

                foreach (TbSoporte soporte in soportes)
                {
                    resultado.Add(Convertir(soporte));
                }

                return new JsonResult(resultado);

            }
            catch (Exception)
            {
                throw;
            }
        }


        // GET api/<TbDatosVentaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbSoporte soporte = soporteDAL.Get(id);

                return new JsonResult(Convertir(soporte));

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Crear
        // POST api/<TbSoporteController>
        [HttpPost]
        public JsonResult Post([FromBody] TbSoporteModel soporte)
        {
            try
            {
                TbSoporte entity = Convertir(soporte);
                soporteDAL.Add(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<TbSoporteController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbSoporteModel soporte)
        {
            try
            {
                TbSoporte entity = Convertir(soporte);
                soporteDAL.Update(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TbSoporteController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbSoporte soporte = new TbSoporte { IdSoporte = id };
                soporteDAL.Remove(soporte);
                return new JsonResult(soporte);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
