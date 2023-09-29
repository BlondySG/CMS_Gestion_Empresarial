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
    public class TbDatosVentaController : ControllerBase
    {

        ITbDatosVentaDAL ventaDAL;
        private readonly ILogger<TbDatosVentaController> logger;

        public TbDatosVentaController(ILogger<TbDatosVentaController> logger)
        {
            ventaDAL = new TbDatosVentaDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }

        TbDatosVenta Convertir(TbDatosVentaModel venta)
        {
            return new TbDatosVenta
            {
                IdVenta = venta.IdVenta,
                NumFacturaVenta = venta.NumFacturaVenta,
                FechaCompra = venta.FechaCompra,
                Cantidad = venta.Cantidad,
                PrecioUnitario = venta.PrecioUnitario,
                ImpuestoVenta = venta.ImpuestoVenta,
                SubTotalVenta = venta.PrecioUnitario * (venta.ImpuestoVenta / 100) + venta.PrecioUnitario,
                TotalVenta = venta.SubTotalVenta * venta.Cantidad,
                FechaVenta = venta.FechaVenta,
                IdArticulo = venta.IdArticulo,
                IdCliente = venta.IdCliente

            };
        }

        TbDatosVentaModel Convertir(TbDatosVenta venta)
        {
            return new TbDatosVentaModel
            {
                IdVenta = venta.IdVenta,
                NumFacturaVenta = venta.NumFacturaVenta,
                FechaCompra = venta.FechaCompra,
                Cantidad = venta.Cantidad,
                PrecioUnitario = venta.PrecioUnitario,
                ImpuestoVenta = venta.ImpuestoVenta,
                SubTotalVenta = venta.PrecioUnitario * (venta.ImpuestoVenta / 100) + venta.PrecioUnitario,
                TotalVenta = venta.SubTotalVenta * venta.Cantidad,
                FechaVenta = venta.FechaVenta,
                IdArticulo = venta.IdArticulo,
                IdCliente = venta.IdCliente

            };
        }

        #region Obtener
        // GET: api/<TbDatosVentaController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogInformation("GET - Datos Venta Get all");
                List<TbDatosVenta> ventas = new List<TbDatosVenta>();
                ventas = ventaDAL.GetAll().ToList();

                List<TbDatosVentaModel> resultado = new List<TbDatosVentaModel>();

                foreach (TbDatosVenta venta in ventas)
                {
                    resultado.Add(Convertir(venta));
                }

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(resultado)}");
                logger.LogInformation("GET - Datos Venta Get Salida");

                return new JsonResult(resultado);

            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Datos");
            }
        }


        // GET api/<TbDatosVentaController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbDatosVenta venta = ventaDAL.Get(id);

                return new JsonResult(Convertir(venta));

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Crear
        // POST api/<TbDatosVentaController>
        [HttpPost]
        public JsonResult Post([FromBody] TbDatosVentaModel venta)
        {
            try
            {
                logger.LogInformation("PoST - Tipo Datos Venta Post");
                TbDatosVenta entity = Convertir(venta);
                ventaDAL.Add(entity);
                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(venta)}");

                return new JsonResult(Convertir(entity));

            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(venta)}");
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<TbDatosVentaController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbDatosVentaModel venta)
        {
            try
            {
                TbDatosVenta entity = Convertir(venta);
                ventaDAL.Update(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TbDatosVentaController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbDatosVenta venta = new TbDatosVenta { IdVenta = id };
                ventaDAL.Remove(venta);
                return new JsonResult(venta);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
