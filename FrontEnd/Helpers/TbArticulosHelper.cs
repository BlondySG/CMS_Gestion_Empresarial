using FrontEnd.Controllers;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbArticulosHelper
    {

        #region Obtiene Proveedor 
        public TbProveedorViewModel GetProveedor(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel proveedorViewModel = response.Content.ReadAsAsync<TbProveedorViewModel>().Result;
                return proveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Lista Proveedores
        public List<TbProveedorViewModel> GetProveedores()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbProveedorViewModel> proveedores = JsonConvert.DeserializeObject<List<TbProveedorViewModel>>(content);

            return proveedores;

        }
        #endregion

        #region GetAll
        public List<TbArticulosViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbarticulos");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbArticulosViewModel> articulos = JsonConvert.DeserializeObject<List<TbArticulosViewModel>>(content);

                return articulos;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public TbArticulosViewModel Details(int id)
        {
            try
            {
                //string token = HttpContext.Session.GetString("token");
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbarticulos/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel tbArticulosViewModel = response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                tbArticulosViewModel.TbProveedor = this.GetProveedor(tbArticulosViewModel.Idproveedor);
                return tbArticulosViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update

        public TbArticulosViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbarticulos/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel tbArticulosViewModel = response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                tbArticulosViewModel.Proveedores = this.GetProveedores();
                return tbArticulosViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public TbArticulosViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbarticulos/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel tbArticulosViewModel = response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                tbArticulosViewModel.TbProveedor = this.GetProveedor(tbArticulosViewModel.Idproveedor);
                return tbArticulosViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
