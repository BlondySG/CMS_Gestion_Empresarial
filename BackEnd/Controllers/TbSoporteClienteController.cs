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
    public class TbSoporteClienteController : ControllerBase
    {



        private ITbSoporteClienteDAL tcsoporteDAL;

        public TbSoporteClienteController()
        {
            tcsoporteDAL = new TbSoporteClienteDALImpl(new GestionBuenCosermuContext());
        }

        TbSoporteCliente Convertir(TbSoporteClienteModel scliente)
        {
         
            return new TbSoporteCliente
            {
                IdSoporteCliente = scliente.IdSoporteCliente,
                IdSoporte = scliente.IdSoporte,
                IdCliente = scliente.IdCliente




    };
          
        }

        TbSoporteClienteModel Convertir(TbSoporteCliente csoporte)
        {
            
            return new TbSoporteClienteModel
            {
                IdSoporteCliente = csoporte.IdSoporteCliente,
                IdSoporte = csoporte.IdSoporte,
                IdCliente = csoporte.IdCliente

            };

         
        }


        [HttpGet]
        public JsonResult Get()
        {
            List<TbSoporteCliente> csoporte = new List<TbSoporteCliente>();

            csoporte = tcsoporteDAL.GetAll().ToList();

            List<TbSoporteClienteModel> resultado = new List<TbSoporteClienteModel>();

            foreach (TbSoporteCliente tipo in csoporte)
            {
                resultado.Add(Convertir(tipo));
            }

            return new JsonResult(resultado);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try { 

            TbSoporteCliente tipoC = tcsoporteDAL.Get(id);


            return new JsonResult(Convertir(tipoC));
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPost]
        public JsonResult Post([FromBody] TbSoporteClienteModel tipoc)
        {
            try { 

            TbSoporteCliente entity = Convertir(tipoc);
            tcsoporteDAL.Add(entity);

            return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {
                throw;
            }
        }


        // PUT api/<TbscliController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbSoporteClienteModel scli)
        {
            try { 

            TbSoporteCliente entity = Convertir(scli);
            tcsoporteDAL.Update(entity);

            return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {
                throw;
            }
        }


        // DELETE api/<TbscliController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbSoporteCliente tipoc = new TbSoporteCliente { IdSoporteCliente = id };
                tcsoporteDAL.Remove(tipoc);
                return new JsonResult(tipoc);
            }
            catch (Exception)
            {
                throw;
            }
        }



        // GET: api/<TbSoporteClienteController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<TbSoporteClienteController>/5
      

        // POST api/<TbSoporteClienteController>
     /*  [HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // PUT api/<TbSoporteClienteController>/5
      /*  [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<TbSoporteClienteController>/5
      /*  [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
