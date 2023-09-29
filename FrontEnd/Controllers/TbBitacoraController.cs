using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbBitacoraController : Controller
    {


        TbBitacoraHelper _tbBitacoraHelper;

        public TbBitacoraController()
        {
            _tbBitacoraHelper = new TbBitacoraHelper();
        }




        #region Read
        // GET: TbBitacoraController
        public ActionResult Index()
        {
            try
            {
                List<TbBitacoraViewModel> tipos = _tbBitacoraHelper.GetAll();

                ViewBag.Title = "Bitacoras";
                return View(tipos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbRolController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                TbBitacoraViewModel bitacoraViewModel = _tbBitacoraHelper.Details(id);

                return View(bitacoraViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Create
        // GET: TbRolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TbRolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbBitacoraViewModel tipo)
        {
           


            try
            {
                TbBitacoraViewModel tbBitacoraViewModel = _tbBitacoraHelper.Create(tipo);

                return View(tbBitacoraViewModel);
            }
            catch (Exception)
            {
                throw;
            }


        }
        #endregion


        #region Update
        // GET: TbRolController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbBitacoraViewModel tbBitacoraViewModel = _tbBitacoraHelper.Edit(id);

                return View(tbBitacoraViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbRolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbBitacoraViewModel tipo)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbbitacora", tipo);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = tipo.IdBitacora });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        //GET: TbRolController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbBitacoraViewModel tbBitacoraViewModel = _tbBitacoraHelper.Delete(id);
                return View(tbBitacoraViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbRolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbBitacoraViewModel tipo)
        {
            try
            {
                int id = tipo.IdBitacora;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbbitacora/" + id.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}

//        // GET: TbTipoController
//        public ActionResult Index()
//        {
//            try
//            {
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/");
//                response.EnsureSuccessStatusCode();
//                var content = response.Content.ReadAsStringAsync().Result;
//                List<TbTipoViewModel> tsoporte = JsonConvert.DeserializeObject<List<TbTipoViewModel>>(content);

//                ViewBag.Title = "Todos los Tipos de Sopote";
//                return View(tsoporte);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        // GET: TbArticulosController/Details/5
//        public ActionResult Details(int id)
//        {
//            ServiceRepository serviceObj = new ServiceRepository();
//            HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
//            response.EnsureSuccessStatusCode();
//            TbTipoViewModel tsoporteViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

//            return View(tsoporteViewModel);
//        }

//        // GET: TbTipoController/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: TbArticulosController/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(TbTipoViewModel tsoporte)
//        {
//            try
//            {
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.PostResponse("api/tbtipo", tsoporte);
//                response.EnsureSuccessStatusCode();
//                TbTipoViewModel tsoporteViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;
//                return RedirectToAction("Details", new { id = tsoporteViewModel.IdTipo });
//            }
//            catch (HttpRequestException
//          )
//            {
//                return RedirectToAction("Error", "Home");
//            }

//            catch (Exception
//            )
//            {

//                throw;
//            }
//        }

//        // GET: TbTipoController/Edit/5
//        public ActionResult Edit(int id)
//        {
//            try
//            {
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
//                response.EnsureSuccessStatusCode();
//                TbTipoViewModel tsoporteViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

//                return View(tsoporteViewModel);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        // POST: TbTipoController/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(TbTipoViewModel tsoporte)
//        {
//            try
//            {
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.PutResponse("api/tbtipo", tsoporte);
//                response.EnsureSuccessStatusCode();
//                TbTipoViewModel tsoporteViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;
//                return RedirectToAction("Details", new { id = tsoporteViewModel.IdTipo });
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: TbTipoController/Delete/5
//        [HttpGet]
//        public ActionResult Delete(int id)
//        {
//            try
//            {
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.GetResponse("api/tbtipo/" + id.ToString());
//                response.EnsureSuccessStatusCode();
//                TbTipoViewModel tsoporteViewModel = response.Content.ReadAsAsync<TbTipoViewModel>().Result;

//                return View(tsoporteViewModel);

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        // POST: TbTipoController/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(TbTipoViewModel tsoporte)
//        {
//            try
//            {
//                int id = tsoporte.IdTipo;
//                ServiceRepository serviceObj = new ServiceRepository();
//                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbtipo/" + id.ToString());
//                response.EnsureSuccessStatusCode();
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }

//    }
//}
