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
    public class TbRolController : ControllerBase
    {
        TbRol Convertir(TbRolModel rol)
        {
            return new TbRol
            {
                IdRol = rol.IdRol,
                NombreRol = rol.NombreRol,
                Activo = rol.Activo
            };
        }

        TbRolModel Convertir(TbRol rol)
        {
            return new TbRolModel
            {
                IdRol = rol.IdRol,
                NombreRol = rol.NombreRol,
                Activo = rol.Activo

            };
        }

        ITbRolDAL rolDAL;

        public TbRolController()
        {
            rolDAL = new TbRolDALImpl(new GestionBuenCosermuContext());
        }

        #region Obtener

        // GET: api/<TbRolController>
        [HttpGet]
        public JsonResult Get()
        {
            List<TbRol> roles = new List<TbRol>();
            roles = rolDAL.GetAll().ToList();

            List<TbRolModel> resultado = new List<TbRolModel>();

            foreach (TbRol rol in roles)
            {
                resultado.Add(Convertir(rol));
            }

            return new JsonResult(resultado) ;
        }


        // GET api/<TbRolController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            TbRol rol = rolDAL.Get(id);


            return new JsonResult(Convertir(rol));
        }

        #endregion


        #region Crear
        // POST api/<TbRolController>
        [HttpPost]
        public JsonResult Post([FromBody] TbRolModel rol)
        {
            TbRol entity = Convertir(rol);
            rolDAL.Add(entity);

            return new JsonResult(Convertir(entity));
        }
        #endregion


        #region Actualizar
        // PUT api/<TbRolController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbRolModel rol)
        {
            TbRol entity = Convertir(rol);
            rolDAL.Update(entity);

            return new JsonResult(Convertir(entity));
        }
        #endregion

        #region Eliminar

        // DELETE api/<TbRolController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbRol rol = new TbRol { IdRol= id };
                rolDAL.Remove(rol);
                return new JsonResult(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
