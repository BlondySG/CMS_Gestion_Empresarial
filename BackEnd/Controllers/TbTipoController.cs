using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Entities.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]



    public class TbTipoController : ControllerBase
    {
       
        private ITbTipoDAL tsoporteDAL;
         private readonly ILogger<TbTipoController> logger;

        public TbTipoController(ILogger<TbTipoController> logger)
        {
            tsoporteDAL = new TbTipoDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }


        TbTipo Convertir(TbTipoModel stipo)
        {
            return new TbTipo
            {
                IdTipo = stipo.IdTipo,
                NombreSoporte = stipo.NombreSoporte
               
            };
        }

        TbTipoModel Convertir(TbTipo stipo)
        {
            return new TbTipoModel
            {
                IdTipo = stipo.IdTipo,
                NombreSoporte = stipo.NombreSoporte

            };
        }

        [HttpGet]
        public  JsonResult Get()
        {
            try {

                logger.LogInformation("GET - Tipo Soporte Get all");

                List<TbTipo> tipos = new List<TbTipo>();

                tipos = tsoporteDAL.GetAll().ToList();

                List<TbTipoModel> resultado = new List<TbTipoModel>();

                foreach (TbTipo tipo in tipos)
                {
                    resultado.Add(Convertir(tipo));
                }

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(resultado)}");
                logger.LogInformation("GET - Tipo Soporte Get Salida");


                return new JsonResult(resultado);
            }
            catch(Exception e)
            {
              
                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Datos");
            }

           
        }

        // GET api/<TbTipoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {

                logger.LogInformation("GET - Tipo Soporte Get Id");
                TbTipo tipo = tsoporteDAL.Get(id);


                return new JsonResult(Convertir(tipo));
                logger.LogInformation($"RESPUESTA{JsonConvert.SerializeObject(tipo)}");

            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Datos" + id);

            }
        }


        [HttpPost]
        public JsonResult Post([FromBody] TbTipoModel tipo)
        {
            try
            {
                logger.LogInformation("PoST - Tipo Soporte Post");
                TbTipo entity = Convertir(tipo);
                tsoporteDAL.Add(entity);


                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(tipo)}");
                return new JsonResult(Convertir(entity));
          

            } catch (Exception e)
            {
                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(tipo)}");

            }
        }

        // PUT api/<TbTipoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbTipoModel tipo)
        {
            try
            {
                logger.LogInformation("PUT - Tipo Soporte Put");
                TbTipo entity = Convertir(tipo);
                tsoporteDAL.Update(entity);

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(tipo)}");
                return new JsonResult(Convertir(entity));
              
            }
            catch (Exception e)
            {
                logger.LogError(e.Message+ $"RESPUESTA  {JsonConvert.SerializeObject(tipo)}");
                throw new Exception("Erro al Post Datos" );
            }
        }


        // DELETE api/<TbTipoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            logger.LogInformation("DELETE - Tipo Soporte Delet");

            try
            {
                TbTipo tipo = new TbTipo { IdTipo = id };
                tsoporteDAL.Remove(tipo);
                return new JsonResult(tipo);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message + id);
                throw new Exception("Erro al Obtener Datos"+id);
            }
        }

     
    }
}
