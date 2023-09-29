using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TbBitacoraHelper 
    {
        private readonly ILogger<TbBitacoraHelper> logger;

      


        #region Read
        public List<TbBitacoraViewModel> GetAll()
        {
            try
            {


               // logger.LogInformation("Index from FRONT END called");
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/tbbitacora");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TbBitacoraViewModel> tipo =
                    JsonConvert.DeserializeObject<List<TbBitacoraViewModel>>(content);

                return tipo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TbBitacoraViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbbitacora/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbBitacoraViewModel tbBitacoraViewModel = response.Content.ReadAsAsync<TbBitacoraViewModel>().Result;

                return tbBitacoraViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public TbBitacoraViewModel Edit(int id)
        {

            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbbitacora/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbBitacoraViewModel tbBitacoraViewModel = response.Content.ReadAsAsync<TbBitacoraViewModel>().Result;

                return tbBitacoraViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region create

        public TbBitacoraViewModel Create(TbBitacoraViewModel tipo)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbbitacora", tipo);
                response.EnsureSuccessStatusCode();
                TbBitacoraViewModel tbBitacoraViewModel = response.Content.ReadAsAsync<TbBitacoraViewModel>().Result;
              
                return tbBitacoraViewModel;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



        #region Delete
        public TbBitacoraViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/tbbitacora/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TbBitacoraViewModel tbBitacoraViewModel = response.Content.ReadAsAsync<TbBitacoraViewModel>().Result;

                return tbBitacoraViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

    }

}