using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbDatosCompraController : Controller
    {
        #region Constructor
        TbDatosCompraHelper _tbDatosComprahelper;
        TbProveedorHelper _tbProveedorHelper;
        TbArticulosHelper _tbArticulosHelper;

        public TbDatosCompraController()
        {
            _tbDatosComprahelper = new TbDatosCompraHelper();
            _tbProveedorHelper = new TbProveedorHelper();
            _tbArticulosHelper = new TbArticulosHelper();    
        }
        #endregion

        #region Obtiene Proveedor
        private TbProveedorViewModel GetProveedor(int id)
        {
            try
            {
                TbProveedorViewModel proveedorViewModel = _tbProveedorHelper.Details(id);
                return proveedorViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Proveedores
        private List<TbProveedorViewModel> GetProveedores()
        {
            List<TbProveedorViewModel> proveedores = _tbProveedorHelper.GetAll();

            return proveedores;
        }
        #endregion

        #region Obtiene Articulo
        private TbArticulosViewModel GetArticulo(int id)
        {
            try
            {
                TbArticulosViewModel articuloViewModel = _tbArticulosHelper.Details(id);
                return articuloViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Articulos
        private List<TbArticulosViewModel> GetArticulos()
        {
            List<TbArticulosViewModel> articulos = _tbArticulosHelper.GetAll();

            return articulos;
        }
        #endregion

        #region Read
        // GET: TbDatosCompraController
        public ActionResult Index()
        {
            try
            {
                List<TbDatosCompraViewModel> compras = _tbDatosComprahelper.GetAll();

                foreach (var item in compras)
                {
                    item.TbProveedor = _tbProveedorHelper.Details(item.IdProveedor);
                }

                foreach (var item in compras)
                {
                    item.TbArticulo = _tbArticulosHelper.Details(item.IdArticulo);
                }

                return View(compras);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Grafico()
        {
            try
            {
                List<TbDatosCompraViewModel> compras = _tbDatosComprahelper.GetAll();

                foreach (var item in compras)
                {
                    item.TbProveedor = _tbProveedorHelper.Details(item.IdProveedor);
                }

                foreach (var item in compras)
                {
                    item.TbArticulo = _tbArticulosHelper.Details(item.IdArticulo);
                }

                return View(compras);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbDatosCompraController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbDatosCompraViewModel compraViewModel = _tbDatosComprahelper.Details(id);

                return View(compraViewModel);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Create
        // GET: TbDatosCompraController/Create
        public ActionResult Create()
        {
            try
            {
                TbDatosCompraViewModel compra = new TbDatosCompraViewModel { };
                compra.Proveedores = this.GetProveedores();
                compra.Articulos = this.GetArticulos();
                return View(compra);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbDatosCompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbDatosCompraViewModel compra)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbdatoscompra", compra);
                response.EnsureSuccessStatusCode();
                TbDatosCompraViewModel tbDatosCompraViewModel = response.Content.ReadAsAsync<TbDatosCompraViewModel>().Result;
                return RedirectToAction("Details", new { id = tbDatosCompraViewModel.IdCompra });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Update
        // GET: TbDatosCompraController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbDatosCompraViewModel tbDatosCompraViewModel = _tbDatosComprahelper.Edit(id);
                return View(tbDatosCompraViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbDatosCompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbDatosCompraViewModel compra)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbdatoscompra", compra);
                response.EnsureSuccessStatusCode();
                TbDatosCompraViewModel tbDatosCompraViewModel = response.Content.ReadAsAsync<TbDatosCompraViewModel>().Result;
                return RedirectToAction("Details", new { id = tbDatosCompraViewModel.IdCompra });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbDatosCompraController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbDatosCompraViewModel tbDatosCompraViewModel = _tbDatosComprahelper.Delete(id);
                return View(tbDatosCompraViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbDatosCompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbDatosCompraViewModel compra)
        {
            try
            {
                int id = compra.IdCompra;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbdatoscompra/" + id.ToString());
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
