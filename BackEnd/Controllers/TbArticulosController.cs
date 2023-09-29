using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbArticulosController : ControllerBase
    {

        private ITbArticuloDAL articuloDAL;
        private readonly ILogger<TbArticulosController> logger;

        public TbArticulosController(ILogger<TbArticulosController> logger)
        {
            articuloDAL = new TbArticuloDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }

        TbArticulo Convertir(TbArticuloModel articulo)
        {
            return new TbArticulo
            {
                IdArticulo = articulo.IdArticulo,
                NombreArticulo = articulo.NombreArticulo,
                Descripcion = articulo.Descripcion,
                Cantidad = articulo.Cantidad,
                CostoArticulo = articulo.CostoArticulo,
                PuntoReorden = articulo.PuntoReorden,
                NumPlaca = articulo.NumPlaca,
                NumParte = articulo.NumParte,
                NumSerie = articulo.NumSerie,
                VidaUtil = articulo.VidaUtil,
                FechaFinGarantia = articulo.FechaFinGarantia,
                Activo = articulo.Activo,
                Idproveedor = articulo.Idproveedor
            };
        }



        TbArticuloModel Convertir(TbArticulo articulo)
        {

            return new TbArticuloModel
            {
                IdArticulo = articulo.IdArticulo,
                NombreArticulo = articulo.NombreArticulo,
                Descripcion = articulo.Descripcion,
                Cantidad = articulo.Cantidad,
                CostoArticulo = articulo.CostoArticulo,
                PuntoReorden = articulo.PuntoReorden,
                NumPlaca = articulo.NumPlaca,
                NumParte = articulo.NumParte,
                NumSerie = articulo.NumSerie,
                VidaUtil = articulo.VidaUtil,
                FechaFinGarantia = articulo.FechaFinGarantia,
                Activo = articulo.Activo,
                Idproveedor = articulo.Idproveedor
            };
        }


        #region Agregar artículo
        // POST api/<TbArticulosController>
        [HttpPost]
        public JsonResult Post([FromBody] TbArticuloModel articulo)
        {

            try
            {
                logger.LogInformation("PoST TbArticulosController  Post");
                TbArticulo nuevo = Convertir(articulo);
                articuloDAL.Add(nuevo);

                logger.LogDebug("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(articulo)}");
                return new JsonResult(Convertir(nuevo));
               
            }
            catch (Exception e) 
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(articulo)}");
            }
        }

        #endregion

        #region Obtener artículo
        // GET: api/<TbArticulosController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<TbArticulo> articulos;
                articulos = articuloDAL.GetAll();

                List<TbArticuloModel> result = new List<TbArticuloModel>();
                foreach (TbArticulo articulo in articulos)
                {
                    result.Add(Convertir(articulo));
                }

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(result)}");
                logger.LogInformation("GET - Tipo Soporte Get Salida");

                return new JsonResult(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Articulos" );
            }
        }

        //[Authorize]
        // GET api/<TbArticulosController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            { 
            TbArticulo articulo;
            articulo = articuloDAL.Get(id);

            return new JsonResult(Convertir(articulo));
        }catch(Exception e)
        {
                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Articulos" + id);

            }
        }
        #endregion

        #region Actualizar artículo
        // PUT api/<TbArticulosController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbArticuloModel articulo)
        {
            try
            {
                logger.LogInformation("PUT - Articulo Put");
                TbArticulo art = Convertir(articulo);
                articuloDAL.Update(art);

                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(articulo)}");
                return new JsonResult(Convertir(art));

            }
            catch (Exception e)
            {

                logger.LogError(e.Message + $"RESPUESTA  {JsonConvert.SerializeObject(articulo)}");
                throw new Exception("Erro al Post Articulos");
            }

        }
        #endregion

        #region Eliminar artículo

        // DELETE api/<TbArticulosController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                logger.LogInformation("DELETE - Articulo Delete");

                TbArticulo articulo = new TbArticulo { IdArticulo = id };

                articuloDAL.Remove(articulo);
                return new JsonResult(articulo);


            }
            catch (Exception e)
            {

                logger.LogError(e.Message + id);
                throw new Exception("Error al Delete Articulos");
            }


        }
        #endregion
    }
}

