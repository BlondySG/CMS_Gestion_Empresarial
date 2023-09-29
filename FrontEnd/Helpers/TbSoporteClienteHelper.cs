using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbSoporteClienteHelper
    {

        #region Obtiene Clientes
        public TbClientesViewModel GetClientes(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClientesViewModel clientesViewModel =
                    response.Content.ReadAsAsync<TbClientesViewModel>().Result;
                return clientesViewModel;
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
            List<TbClientesViewModel> scliente =
                JsonConvert.DeserializeObject<List<TbClientesViewModel>>(content);

            return scliente;
        }
        #endregion
        #region Obtiene Soporte
        public TbSoporteViewModel GetSoporte(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoporte/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel soporteViewModel =
                    response.Content.ReadAsAsync<TbSoporteViewModel>().Result;
                return soporteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Soporte
        public List<TbSoporteViewModel> GetSoporte()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbsoporte/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbSoporteViewModel> ssoporte =
                JsonConvert.DeserializeObject<List<TbSoporteViewModel>>(content);

            return ssoporte;
        }
        #endregion


        #region GetAll
        public List<TbSoporteClienteViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbsoportecliente");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbSoporteClienteViewModel> scliente =
                    JsonConvert.DeserializeObject<List<TbSoporteClienteViewModel>>(content);

                return scliente;
            }
            catch (Exception)
            {
                throw;
            }






        } 
        #endregion

        #region Read
        public TbSoporteClienteViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoportecliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteClienteViewModel tbSoporteClienteViewModel = response.Content.ReadAsAsync<TbSoporteClienteViewModel>().Result;

                tbSoporteClienteViewModel.TbSoporte = this.GetSoporte(tbSoporteClienteViewModel.IdSoporte);
                tbSoporteClienteViewModel.TbClientes = this.GetClientes(tbSoporteClienteViewModel.IdCliente);

                return tbSoporteClienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update

        public TbSoporteClienteViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoportecliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteClienteViewModel tbSoporteClienteViewModel = response.Content.ReadAsAsync<TbSoporteClienteViewModel>().Result;

                

                tbSoporteClienteViewModel.Clientes = this.GetClientes();
                tbSoporteClienteViewModel.Soporte = this.GetSoporte();

                return tbSoporteClienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public TbSoporteClienteViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbsoportecliente/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbSoporteClienteViewModel tbSoporteClienteViewModel = response.Content.ReadAsAsync<TbSoporteClienteViewModel>().Result;

                return tbSoporteClienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}