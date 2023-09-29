using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbClientesHelper
    {

        #region GetAll
        public List<TbClientesViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbclientes");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbClientesViewModel> scliente =
                    JsonConvert.DeserializeObject<List<TbClientesViewModel>>(content);

                return scliente;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Read
        public TbClientesViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClientesViewModel tbClientesViewModel = response.Content.ReadAsAsync<TbClientesViewModel>().Result;

                return tbClientesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Update

        public TbClientesViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClientesViewModel tbClientesViewModel = response.Content.ReadAsAsync<TbClientesViewModel>().Result;

                return tbClientesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public TbClientesViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbclientes/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbClientesViewModel tbClientesViewModel = response.Content.ReadAsAsync<TbClientesViewModel>().Result;

                return tbClientesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}