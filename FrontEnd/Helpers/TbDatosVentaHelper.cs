using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbDatosVentaHelper
    {
        
        #region Obtiene Articulo
        public TbArticulosViewModel GetArticulo(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbarticulos/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel articuloViewModel =
                    response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                return articuloViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Articulos
        public List<TbArticulosViewModel> GetArticulos()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbarticulos/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbArticulosViewModel> articulos =
                JsonConvert.DeserializeObject<List<TbArticulosViewModel>>(content);

            return articulos;
        }
        #endregion

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

        #region GetAll
        public List<TbDatosVentaViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbdatosventa");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbDatosVentaViewModel> ventas =
                    JsonConvert.DeserializeObject<List<TbDatosVentaViewModel>>(content);

                return ventas;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public TbDatosVentaViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatosventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosVentaViewModel tbDatosVentaViewModel = response.Content.ReadAsAsync<TbDatosVentaViewModel>().Result;
                tbDatosVentaViewModel.TbArticulo = this.GetArticulo(tbDatosVentaViewModel.IdArticulo);
                tbDatosVentaViewModel.TbCliente = this.GetCliente(tbDatosVentaViewModel.IdCliente);
                return tbDatosVentaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public TbDatosVentaViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatosventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosVentaViewModel tbDatosVentaViewModel = response.Content.ReadAsAsync<TbDatosVentaViewModel>().Result;
                tbDatosVentaViewModel.Articulos = this.GetArticulos();
                tbDatosVentaViewModel.Clientes = this.GetClientes();
                return tbDatosVentaViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbDatosVentaViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatosventa/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosVentaViewModel tbDatosVentaViewModel = response.Content.ReadAsAsync<TbDatosVentaViewModel>().Result;

                tbDatosVentaViewModel.TbArticulo = this.GetArticulo(tbDatosVentaViewModel.IdArticulo);
                tbDatosVentaViewModel.TbCliente = this.GetCliente(tbDatosVentaViewModel.IdCliente);
                return tbDatosVentaViewModel;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
