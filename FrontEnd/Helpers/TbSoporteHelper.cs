using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbSoporteHelper
    {
        #region Obtiene Cliente
        public TbClientesViewModel GetCliente(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClientesViewModel clienteViewModel =
                    response.Content.ReadAsAsync<TbClientesViewModel>().Result;
                return clienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Clientes
        public List<TbClientesViewModel> GetClientes()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbClientesViewModel> clientes =
                JsonConvert.DeserializeObject<List<TbClientesViewModel>>(content);

            return clientes;
        }
        #endregion

        #region Obtiene Empleado
        public TbEmpleadoViewModel GetEmpleado(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbempleado/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbEmpleadoViewModel empleadoViewModel =
                    response.Content.ReadAsAsync<TbEmpleadoViewModel>().Result;
                return empleadoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Empleados
        public List<TbEmpleadoViewModel> GetEmpleados()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbempleado/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbEmpleadoViewModel> empleados =
                JsonConvert.DeserializeObject<List<TbEmpleadoViewModel>>(content);

            return empleados;
        }
        #endregion

        #region Obtiene Tipo
        public TbTipoViewModel GetTipo(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbTipoViewModel tipoViewModel =
                    response.Content.ReadAsAsync<TbTipoViewModel>().Result;
                return tipoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Tipos
        public List<TbTipoViewModel> GetTipos()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbTipoViewModel> tipos =
                JsonConvert.DeserializeObject<List<TbTipoViewModel>>(content);

            return tipos;
        }
        #endregion

        #region GetAll
        public List<TbSoporteViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbsoporte");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbSoporteViewModel> soportes =
                    JsonConvert.DeserializeObject<List<TbSoporteViewModel>>(content);

                return soportes;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public TbSoporteViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoporte/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel tbSoporteViewModel = response.Content.ReadAsAsync<TbSoporteViewModel>().Result;

                tbSoporteViewModel.TbCliente = this.GetCliente(tbSoporteViewModel.IdCliente);
                tbSoporteViewModel.TbEmpleado = this.GetEmpleado(tbSoporteViewModel.IdEmpleado);
                tbSoporteViewModel.TbTipo = this.GetTipo(tbSoporteViewModel.IdTipo);
                return tbSoporteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public TbSoporteViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoporte/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel tbSoporteViewModel = response.Content.ReadAsAsync<TbSoporteViewModel>().Result;

                tbSoporteViewModel.Clientes = this.GetClientes();
                tbSoporteViewModel.Empleados = this.GetEmpleados();
                tbSoporteViewModel.Tipos = this.GetTipos();
                return tbSoporteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbSoporteViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoporte/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel tbSoporteViewModel = response.Content.ReadAsAsync<TbSoporteViewModel>().Result;

                tbSoporteViewModel.TbCliente = this.GetCliente(tbSoporteViewModel.IdCliente);
                tbSoporteViewModel.TbEmpleado = this.GetEmpleado(tbSoporteViewModel.IdEmpleado);
                tbSoporteViewModel.TbTipo = this.GetTipo(tbSoporteViewModel.IdTipo);
                return tbSoporteViewModel;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
