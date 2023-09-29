using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbProveedorController : Controller
    {

        #region Constructor
        TbProveedorHelper _tbProveedorHelper;

        public TbProveedorController()
        {
            _tbProveedorHelper = new TbProveedorHelper();
        } 
        #endregion

        #region Create
        // GET: TbProveedorController/Create
        public ActionResult Create()
        {
            try
            {
                TbProveedorViewModel proveedor = new TbProveedorViewModel { };
                return View(proveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbProveedorViewModel proveedor)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbproveedor", proveedor);
                response.EnsureSuccessStatusCode();
                TbProveedorViewModel tbProveedorViewModel = response.Content.ReadAsAsync<TbProveedorViewModel>().Result;
                return RedirectToAction("Details", new { id = tbProveedorViewModel.IdProveedor });
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
                List<TbProveedorViewModel> proveedores = _tbProveedorHelper.GetAll();

                return View(proveedores);
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
                TbProveedorViewModel proveedorViewModel = _tbProveedorHelper.Details(id);
                return View(proveedorViewModel);
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
                TbProveedorViewModel tbProveedorViewModel = _tbProveedorHelper.Edit(id);

                return View(tbProveedorViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbProveedorViewModel proveedor)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbproveedor", proveedor);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = proveedor.IdProveedor });
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
                TbProveedorViewModel tbProveedorViewModel = _tbProveedorHelper.Delete(id);

                return View(tbProveedorViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbProveedorViewModel proveedor)
        {
            try
            {
                int id = proveedor.IdProveedor;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbproveedor/" + id.ToString());
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
