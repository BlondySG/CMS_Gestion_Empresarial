using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbArticulosController : Controller
    {
        #region Constructor
        TbArticulosHelper _tbArticulosHelper;
        TbProveedorHelper _proveedorHelper;

        public TbArticulosController()
        {
            _tbArticulosHelper = new TbArticulosHelper();
            _proveedorHelper = new TbProveedorHelper();
        }
        #endregion


        #region Obtiene Proveedor
        private TbProveedorViewModel GetProveedor(int id)
        {
            try
            {
                TbProveedorViewModel proveedorViewModel = _proveedorHelper.Details(id);

                return proveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Lista Proveedores
        private List<TbProveedorViewModel> GetProveedores()
        {
            List<TbProveedorViewModel> proveedores = _proveedorHelper.GetAll();

            return proveedores;

        }
        #endregion

        #region Create
        // GET: TbArticulosController/Create
        public ActionResult Create()
        {
            try
            {
                TbArticulosViewModel proveedor = new TbArticulosViewModel { };
                proveedor.Proveedores = this.GetProveedores();

                return View(proveedor);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbArticulosViewModel articulo)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbarticulos", articulo);
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel articulosViewModel = response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                return RedirectToAction("Details", new { id = articulosViewModel.IdArticulo });
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
        // GET: TbArticulosController
        public ActionResult Index()
        {
            try
            {
                List<TbArticulosViewModel> articulos = _tbArticulosHelper.GetAll();

                foreach (var item in articulos)
                {
                    item.TbProveedor = _proveedorHelper.Details(item.Idproveedor);
                }
                return View(articulos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult GraficoBarra()
        {
            try
            {
                List<TbArticulosViewModel> articulos = _tbArticulosHelper.GetAll();

                foreach (var item in articulos)
                {
                    item.TbProveedor = _proveedorHelper.Details(item.Idproveedor);
                }
                return View(articulos);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult GraficoPie()
        {
            try
            {
                List<TbArticulosViewModel> articulos = _tbArticulosHelper.GetAll();

                foreach (var item in articulos)
                {
                    item.TbProveedor = _proveedorHelper.Details(item.Idproveedor);
                }
                return View(articulos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbArticulosController/Details/5
        public ActionResult Details(int id)
        {
            
            TbArticulosViewModel articulosViewModel = _tbArticulosHelper.Details(id);

            return View(articulosViewModel);

        }
        #endregion

        #region Update
        // GET: TbArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbArticulosViewModel articuloViewModel = _tbArticulosHelper.Edit(id);
                return View(articuloViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        } 

        // POST: TbArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbArticulosViewModel articulo)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbarticulos", articulo);
                response.EnsureSuccessStatusCode();
                TbArticulosViewModel articulosViewModel = response.Content.ReadAsAsync<TbArticulosViewModel>().Result;
                return RedirectToAction("Details", new { id = articulosViewModel.IdArticulo });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbArticulosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                TbArticulosViewModel articulosViewModel = _tbArticulosHelper.Delete(id);

                return View(articulosViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbArticulosViewModel articulo)
        {
            try
            {
                int id = articulo.IdArticulo;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbarticulos/" + id.ToString());
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
