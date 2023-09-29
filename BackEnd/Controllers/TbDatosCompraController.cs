using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbDatosCompraController : ControllerBase
    {
        TbDatosCompra Convertir(TbDatosCompraModel compra)
        {
            return new TbDatosCompra
            {
                IdCompra = compra.IdCompra,
                NumFacturaCompra = compra.NumFacturaCompra,
                Cantidad = compra.Cantidad,
                PrecioUnitario = compra.PrecioUnitario,
                ImpuestoCompra = compra.ImpuestoCompra,
                SubTotalCompra = compra.PrecioUnitario * (compra.ImpuestoCompra / 100) + compra.PrecioUnitario,
                TotalCompra = compra.SubTotalCompra * compra.Cantidad,
                FechaCompra = compra.FechaCompra,
                IdProveedor = compra.IdProveedor,
                IdArticulo = compra.IdArticulo

            };
        }

        TbDatosCompraModel Convertir(TbDatosCompra compra)
        {
            return new TbDatosCompraModel
            {
                IdCompra = compra.IdCompra,
                NumFacturaCompra = compra.NumFacturaCompra,
                Cantidad = compra.Cantidad,
                PrecioUnitario = compra.PrecioUnitario,
                ImpuestoCompra = compra.ImpuestoCompra,
                SubTotalCompra = compra.PrecioUnitario * (compra.ImpuestoCompra / 100) + compra.PrecioUnitario,
                TotalCompra = compra.SubTotalCompra * compra.Cantidad,
                FechaCompra = compra.FechaCompra,
                IdProveedor = compra.IdProveedor,
                IdArticulo = compra.IdArticulo

            };
        }

        ITbDatosCompraDAL compraDAL;

        private readonly ILogger<TbDatosCompraController> logger;

        public TbDatosCompraController(ILogger<TbDatosCompraController> logger)
        {
            compraDAL = new TbDatosCompraDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }

        #region Obtener

        // GET: api/<TbDatosCompraController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogInformation("GET - Datos Compra Get all");
                List<TbDatosCompra> compras = new List<TbDatosCompra>();
                compras = compraDAL.GetAll().ToList();

                List<TbDatosCompraModel> resultado = new List<TbDatosCompraModel>();

                foreach (TbDatosCompra compra in compras)
                {
                    resultado.Add(Convertir(compra));
                }
                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(resultado)}");
                logger.LogInformation("GET - Datos Compra Get Salida");
                return new JsonResult(resultado);

            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Datos");
            }
        }


        // GET api/<TbDatosCompraController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbDatosCompra compra = compraDAL.Get(id);

                return new JsonResult(Convertir(compra));

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region Crear
        // POST api/<TbDatosCompraController>
        [HttpPost]
        public JsonResult Post([FromBody] TbDatosCompraModel compra)
        {
            try
            {
                logger.LogInformation("PoST - Tipo Datos Compra Post");
                TbDatosCompra entity = Convertir(compra);
                compraDAL.Add(entity);
                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(compra)}");
                return new JsonResult(Convertir(entity));

            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(compra)}");
            }
        }
        #endregion


        #region Actualizar
        // PUT api/<TbDatosCompraController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbDatosCompraModel compra)
        {
            try
            {
                TbDatosCompra entity = Convertir(compra);
                compraDAL.Update(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TbDatosCompraController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    TbDatosCompra compra = new TbDatosCompra { IdCompra = id };
        //    compraDAL.Remove(compra);
        //}
        

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbDatosCompra compra = new TbDatosCompra { IdCompra= id };
                //category = categoryDAL.Get(id);
                compraDAL.Remove(compra);
                return new JsonResult(compra);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
