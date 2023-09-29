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



    public class TbBitacoraController : ControllerBase
    {

         private ITbBitacoraDAL tbitacoraDAL;
         private readonly ILogger<TbBitacoraController> logger;

        public TbBitacoraController(ILogger<TbBitacoraController> logger)
        {
            tbitacoraDAL = new TbBitacoraDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }


        TbBitacora Convertir(TbBitacoraModel sbitacora)
        {
            return new TbBitacora
            {
                IdBitacora = sbitacora.IdBitacora,
                CodError = sbitacora.CodError,
                Descripcion = sbitacora.Descripcion,
                FechaHora = sbitacora.FechaHora,
                Origen = sbitacora.Origen,
                IdEmpleado= sbitacora.IdEmpleado

    };
        }

        TbBitacoraModel Convertir(TbBitacora sbitacora)
        {
            return new TbBitacoraModel
            {
                IdBitacora = sbitacora.IdBitacora,
                CodError = sbitacora.CodError,
                Descripcion = sbitacora.Descripcion,
                FechaHora = sbitacora.FechaHora,
                Origen = sbitacora.Origen,
                IdEmpleado = sbitacora.IdEmpleado

            };
        }

        [HttpGet]
        public JsonResult Get()
        {

            logger.LogDebug("Get All List tipo Soporte");
            logger.LogInformation("Index from HomeController called"); 

            List<TbBitacora> bitacoras = new List<TbBitacora>();

            bitacoras = tbitacoraDAL.GetAll().ToList();

            List<TbBitacoraModel> resultado = new List<TbBitacoraModel>();

            foreach (TbBitacora bit in bitacoras)
            {
                resultado.Add(Convertir(bit));
            }

            return new JsonResult(resultado);
        }

        // GET api/<TbTipoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TbBitacora bita = tbitacoraDAL.Get(id);


            return new JsonResult(Convertir(bita));
        }


        [HttpPost]
        public JsonResult Post([FromBody] TbBitacoraModel bitacora)
        {

            try { 
            TbBitacora entity = Convertir(bitacora);
                tbitacoraDAL.Add(entity);

            return new JsonResult(Convertir(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<TbTipoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbBitacoraModel bitacora)
        {
            TbBitacora entity = Convertir(bitacora);
            tbitacoraDAL.Update(entity);

            return new JsonResult(Convertir(entity));
        }


        // DELETE api/<TbTipoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbBitacora bita = new TbBitacora { IdBitacora = id };
                tbitacoraDAL.Remove(bita);
                return new JsonResult(bita);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/<TbTipoController>
        /*  [HttpGet]
          public IEnumerable<string> Get()
          {
              return new string[] { "value1", "value2" };
          }

          // GET api/<TbTipoController>/5
          [HttpGet("{id}")]
          public string Get(int id)
          {
              return "value";
          }*/


        // POST api/<TbTipoController>
        /*  [HttpPost]
          public void Post([FromBody] string value)
          {
          }*/

        // PUT api/<TbTipoController>/5
        /* [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

        // DELETE api/<TbTipoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
