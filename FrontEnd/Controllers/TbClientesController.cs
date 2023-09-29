using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbClientesController : Controller
    {

        #region Constructor
        TbClientesHelper _tbClientesHelper;

        public TbClientesController()
        {
            _tbClientesHelper = new TbClientesHelper();
        }
        #endregion

        #region Create
        // GET: TbProveedorController/Create
        public ActionResult Create()
        {
            try
            {
                TbClientesViewModel scliente = new TbClientesViewModel { };
                return View(scliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbClientesViewModel scliente)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbclientes", scliente);
                response.EnsureSuccessStatusCode();
                TbClientesViewModel tbClientesViewModel = response.Content.ReadAsAsync<TbClientesViewModel>().Result;
                return RedirectToAction("Details", new { id = tbClientesViewModel.IdCliente });
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }
        #endregion

        #region Read
        // GET: TbProveedorController
        public ActionResult Index()
        {
            try
            {
                List<TbClientesViewModel> scliente = _tbClientesHelper.GetAll();

                return View(scliente);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbProveedorController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                TbClientesViewModel tbClientesViewModel = _tbClientesHelper.Details(id);
                return View(tbClientesViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update
        // GET: TbProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbClientesViewModel tbClientesViewModel = _tbClientesHelper.Edit(id);

                return View(tbClientesViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbClientesViewModel scliente)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbclientes", scliente);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = scliente.IdCliente });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        //GET: TbProveedorController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbClientesViewModel tbClientesViewModel = _tbClientesHelper.Delete(id);

                return View(tbClientesViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbClientesViewModel scliente)
        {
            try
            {
                int id = scliente.IdCliente;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbclientes/" + id.ToString());
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
