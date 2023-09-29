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
    public class TbEmpleadoController : ControllerBase
    {
        TbEmpleado Convertir(TbEmpleadoModel empleado)
        {
            return new TbEmpleado
            {
                IdEmpleado = empleado.IdEmpleado,
                Cedula = empleado.Cedula,
                Foto = empleado.Foto,
                Nombre = empleado.Nombre,
                Apellido1 = empleado.Apellido1,
                Apellido2 = empleado.Apellido2,
                TelefonoEmpleado = empleado.TelefonoEmpleado,
                CorreoEmpleado = empleado.CorreoEmpleado,
                Direccion = empleado.Direccion,
                Contrasena = empleado.Contrasena,
                NombreContacto = empleado.NombreContacto,
                TelefonoContacto = empleado.TelefonoContacto,
                Activo = empleado.Activo,
                IdRol = empleado.IdRol

            };
        }

        TbEmpleadoModel Convertir(TbEmpleado empleado)
        {
            return new TbEmpleadoModel
            {
                IdEmpleado = empleado.IdEmpleado,
                Cedula = empleado.Cedula,
                Foto = empleado.Foto,
                Nombre = empleado.Nombre,
                Apellido1 = empleado.Apellido1,
                Apellido2 = empleado.Apellido2,
                TelefonoEmpleado = empleado.TelefonoEmpleado,
                CorreoEmpleado = empleado.CorreoEmpleado,
                Direccion = empleado.Direccion,
                Contrasena = empleado.Contrasena,
                NombreContacto = empleado.NombreContacto,
                TelefonoContacto = empleado.TelefonoContacto,
                Activo = empleado.Activo,
                IdRol = empleado.IdRol

            };
        }

        ITbEmpleadoDAL empleadoDAL;

        public TbEmpleadoController()
        {
            empleadoDAL = new TbEmpleadoDALImpl(new GestionBuenCosermuContext());
        }

        #region Obtener

        // GET: api/<TbEmpleadoController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                List<TbEmpleado> empleados = new List<TbEmpleado>();
                empleados = empleadoDAL.GetAll().ToList();

                List<TbEmpleadoModel> resultado = new List<TbEmpleadoModel>();

                foreach (TbEmpleado empleado in empleados)
                {
                    resultado.Add(Convertir(empleado));
                }

                return new JsonResult(resultado);

            }
            catch (Exception)
            {

                throw;
            }
        }


        // GET api/<TbEmpleadoController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                TbEmpleado empleado = empleadoDAL.Get(id);

                return new JsonResult(Convertir(empleado));

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region Crear
        // POST api/<TbEmpleadoController>
        [HttpPost]
        public JsonResult Post([FromBody] TbEmpleadoModel empleado)
        {
            try
            {
                TbEmpleado entity = Convertir(empleado);
                empleadoDAL.Add(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region Actualizar
        // PUT api/<TbEmpleadoController>/5
        [HttpPut]
        public JsonResult Put([FromBody] TbEmpleadoModel empleado)
        {
            try
            {
                TbEmpleado entity = Convertir(empleado);
                empleadoDAL.Update(entity);

                return new JsonResult(Convertir(entity));

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<TbEmpleadoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    TbEmpleado empleado = new TbEmpleado { IdEmpleado = id };
        //    empleadoDAL.Remove(empleado);
        //}


        // DELETE api/<TbEmpleadoController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                TbEmpleado empleado = new TbEmpleado { IdEmpleado = id };
                //category = categoryDAL.Get(id);
                empleadoDAL.Remove(empleado);
                return new JsonResult(empleado);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
