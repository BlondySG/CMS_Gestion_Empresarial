using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbTipoHelper
    {
        #region Read
        public List<TbTipoViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbtipo");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbTipoViewModel> tipo =
                    JsonConvert.DeserializeObject<List<TbTipoViewModel>>(content);

                return tipo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TbTipoViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbTipoViewModel tbTipoViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

                return tbTipoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public TbTipoViewModel Edit(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbTipoViewModel tbTipoViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

                return tbTipoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete
        public TbTipoViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbTipoViewModel tbTipoViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

                return tbTipoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

    }

}