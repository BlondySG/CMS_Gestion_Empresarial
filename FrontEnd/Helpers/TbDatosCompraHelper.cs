using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbDatosCompraHelper
    {

        #region Obtiene Proveedor
        public TbProveedorViewModel GetProveedor(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel proveedorViewModel =
                    response.Content.ReadAsAsync<TbProveedorViewModel>().Result;
                return proveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Proveedores
        public List<TbProveedorViewModel> GetProveedores()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TbProveedorViewModel> proveedores =
                JsonConvert.DeserializeObject<List<TbProveedorViewModel>>(content);

            return proveedores;
        }
        #endregion

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

        #region GetAll
        public List<TbDatosCompraViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbdatoscompra");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbDatosCompraViewModel> compras =
                    JsonConvert.DeserializeObject<List<TbDatosCompraViewModel>>(content);

                return compras;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Read
        public TbDatosCompraViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatoscompra/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosCompraViewModel tbDatosCompraViewModel = response.Content.ReadAsAsync<TbDatosCompraViewModel>().Result;
                tbDatosCompraViewModel.TbProveedor = this.GetProveedor(tbDatosCompraViewModel.IdProveedor);
                tbDatosCompraViewModel.TbArticulo = this.GetArticulo(tbDatosCompraViewModel.IdArticulo);
                return tbDatosCompraViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update

        public TbDatosCompraViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatoscompra/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosCompraViewModel tbDatosCompraViewModel = response.Content.ReadAsAsync<TbDatosCompraViewModel>().Result;
                tbDatosCompraViewModel.Proveedores = this.GetProveedores();
                tbDatosCompraViewModel.Articulos = this.GetArticulos();
                return tbDatosCompraViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbDatosCompraViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbdatoscompra/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbDatosCompraViewModel tbDatosCompraViewModel = response.Content.ReadAsAsync<TbDatosCompraViewModel>().Result;

                tbDatosCompraViewModel.TbProveedor = this.GetProveedor(tbDatosCompraViewModel.IdProveedor);
                tbDatosCompraViewModel.TbArticulo = this.GetArticulo(tbDatosCompraViewModel.IdArticulo);
                return tbDatosCompraViewModel;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
