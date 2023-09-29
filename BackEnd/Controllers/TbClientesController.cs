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
    public class TbClientesController : ControllerBase
    {

        private ITbClienteDAL clienteDAL;
        private readonly ILogger<TbArticulosController> logger;

        public TbClientesController(ILogger<TbArticulosController> logger)
        {
            clienteDAL = new TbClienteDALImpl(new GestionBuenCosermuContext());
            this.logger = logger;
        }



        TbCliente Convertir(TbClienteModel cliente)
        {
            return new TbCliente
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                CorreoCliente = cliente.CorreoCliente,
                PersonaContacto = cliente.PersonaContacto,
                DireccionCliente = cliente.DireccionCliente,
                TelefonoCliente = cliente.TelefonoCliente,
                Activo = cliente.Activo
            };

        }

        TbClienteModel Convertir(TbCliente cliente)
        {
            return new TbClienteModel
            {
                IdCliente = cliente.IdCliente,
                NombreCliente = cliente.NombreCliente,
                CorreoCliente = cliente.CorreoCliente,
                PersonaContacto = cliente.PersonaContacto,
                DireccionCliente = cliente.DireccionCliente,
                TelefonoCliente = cliente.TelefonoCliente,
                Activo = cliente.Activo
            };
        }




        #region Agregar cliente
        // POST api/<TbClientesController>
        [HttpPost]
        public JsonResult Post([FromBody] TbClienteModel cliente)
        {

            try
            {
                logger.LogInformation("PoST - Clientes Post");
                TbCliente nuevo = Convertir(cliente);
                clienteDAL.Add(nuevo);

                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(cliente)}");
                return new JsonResult(Convertir(nuevo));


            }
            catch (Exception e)
            {

                logger.LogError(e.Message);
                throw new Exception("Erro al Post Datos" + $"RESPUESTA  {JsonConvert.SerializeObject(cliente)}"); 
            }
        }

        #endregion

        #region Obteber Clientes
        // GET: api/<TbClientesController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                logger.LogInformation("GET - Clientes Get all");
                IEnumerable<TbCliente> clientes;
                clientes = clienteDAL.GetAll();

                List<TbClienteModel> result = new List<TbClienteModel>();
                foreach (TbCliente cliente in clientes)
                {
                    result.Add(Convertir(cliente));
                }

                logger.LogInformation($"RESPUESTA  {JsonConvert.SerializeObject(clientes)}");
                logger.LogInformation("GET - Clientes Get Salida");
                return new JsonResult(result);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw new Exception("Erro al Obtener Datos Clientes");
            }
        }

        // GET api/<TbClientesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
             
            TbCliente cliente;
            cliente = clienteDAL.Get(id);

            return new JsonResult(Convertir(cliente));
        }
        #endregion


        #region Actualizar Cliente
        // PUT api/<TbClientesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbClienteModel cliente)
        {
            try
            {
                logger.LogInformation("PUT - Clientes Put");
                TbCliente cli = Convertir(cliente);
                clienteDAL.Update(cli);


                logger.LogDebug($"RESPUESTA  {JsonConvert.SerializeObject(cliente)}");
                return new JsonResult(Convertir(cli));

            }
            catch (Exception e)
            {

                logger.LogError(e.Message + $"RESPUESTA  {JsonConvert.SerializeObject(cliente)}");
                throw new Exception("Erro al Put Datos");
            }

        }


        #endregion


        #region Eliminar cliente

        // DELETE api/<TbClientesController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                logger.LogInformation("DELETE - Clientes Delete");

                TbCliente cliente = new TbCliente { IdCliente = id };

                clienteDAL.Remove(cliente);
                return new JsonResult(cliente);

                logger.LogDebug("DELETE - Tipo Soporte Delet" + id);

            }
            catch (Exception e)
            {

                logger.LogError(e.Message + id);
                throw new Exception("Erro al Obtener Datos" + id);
            }


        }

        #endregion 
    }
}
