using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbProveedorHelper
    {

        #region GetAll
        public List<TbProveedorViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbproveedor");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbProveedorViewModel> proveedor =
                    JsonConvert.DeserializeObject<List<TbProveedorViewModel>>(content);

                return proveedor;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Read
        public TbProveedorViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel tbProveedorViewModel = response.Content.ReadAsAsync<TbProveedorViewModel>().Result;

                return tbProveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update

        public TbProveedorViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel tbProveedorViewModel = response.Content.ReadAsAsync<TbProveedorViewModel>().Result;

                return tbProveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public TbProveedorViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbproveedor/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel tbProveedorViewModel = response.Content.ReadAsAsync<TbProveedorViewModel>().Result;

                return tbProveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}