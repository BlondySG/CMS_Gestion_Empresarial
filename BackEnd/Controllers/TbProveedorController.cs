using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbProveedorController : ControllerBase
    {
        TbProveedor Convertir(TbProveedorModel proveedor)
        {
            return new TbProveedor
            {
                IdProveedor = proveedor.IdProveedor,
                NombreProveedor = proveedor.NombreProveedor,
                CorreoProveedor = proveedor.CorreoProveedor,
                NombreContacto = proveedor.NombreContacto,
                DireccionProveedor = proveedor.DireccionProveedor,
                TelefonoProveedor = proveedor.TelefonoProveedor,
                ProductoProveedor = proveedor.ProductoProveedor,
                Activo = proveedor.Activo
            };
        }

        TbProveedorModel Convertir(TbProveedor proveedor)
        {
            return new TbProveedorModel
            {
                IdProveedor = proveedor.IdProveedor,
                NombreProveedor = proveedor.NombreProveedor,
                CorreoProveedor = proveedor.CorreoProveedor,
                NombreContacto = proveedor.NombreContacto,
                DireccionProveedor = proveedor.DireccionProveedor,
                TelefonoProveedor = proveedor.TelefonoProveedor,
                ProductoProveedor = proveedor.ProductoProveedor,
                Activo = proveedor.Activo

            };
        }

        ITbProveedorDAL proveedorDAL;
        private readonly ILogger<TbProveedorController> logger;

        public TbProveedorController(ILogger<TbProveedorController> logger)
        {
            proveedorDAL = new TbProveedorDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }

        #region Obtener

        // GET: api/<TbProveedorController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogInformation("GET - Datos Proveedor Get all");
                List<TbProveedor> proveedores = new List<TbProveedor>();
                proveedores = proveedorDAL.GetAll().ToList();

                List<TbProveedorModel> resultado = new List<TbProveedorModel>();

                foreach (TbProveedor proveedor in proveedores)
                {
                    resultado.Add(Convertir(proveedor));
                }

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(resultado)}");
                logger.LogInformation("GET - Proveedores Get Salida");
                return new JsonResult(resultado);
            }
                catch(Exception e)
                    {
                logger.LogError(e.Message);
                throw new Exception("Erro al Proveedor");
            }
        }


        // GET api/<TbProveedorController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TbProveedor proveedor = proveedorDAL.Get(id);

            return new JsonResult(Convertir(proveedor));
        }

        #endregion


        #region Crear
        // POST api/<TbProveedorController>
        [HttpPost]
        public JsonResult Post([FromBody] TbProveedorModel proveedor)
        {
            try
            {
                logger.LogInformation("PoST - Proveedor Compra Post");
                TbProveedor entity = Convertir(proveedor);
                proveedorDAL.Add(entity);

                return new JsonResult(Convertir(entity));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(proveedor)}");
            }
        }
        #endregion


        #region Actualizar
        // PUT api/<TbProveedorController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbProveedorModel proveedor)
        {
            TbProveedor entity = Convertir(proveedor);
            proveedorDAL.Update(entity);

            return new JsonResult(Convertir(entity));
        }
        #endregion

       #region Eliminar

        // DELETE api/<TbProveedorController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbProveedor proveedor = new TbProveedor { IdProveedor= id };
                proveedorDAL.Remove(proveedor);
                return new JsonResult(proveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
