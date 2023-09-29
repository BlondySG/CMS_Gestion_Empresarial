using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbDatosVentaController : Controller
    {
        #region Constructor
        TbDatosVentaHelper _tbDatosVentahelper;
        TbArticulosHelper _tbArticulosHelper;
        TbClientesHelper _tbClientesHelper;

        public TbDatosVentaController()
        {
            _tbDatosVentahelper = new TbDatosVentaHelper();
            _tbArticulosHelper = new TbArticulosHelper();
            _tbClientesHelper = new TbClientesHelper();
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

        #region Obtiene Cliente
        private TbClientesViewModel GetCliente(int id)
        {
            try
            {
                TbClientesViewModel clienteViewModel = _tbClientesHelper.Details(id);
                return clienteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Clientes
        private List<TbClientesViewModel> GetClientes()
        {
            List<TbClientesViewModel> clientes = _tbClientesHelper.GetAll();

            return clientes;
        }
        #endregion

        #region Read
        // GET: TbDatosVentaController
        public ActionResult Index()
        {
            try
            {
                List<TbDatosVentaViewModel> ventas = _tbDatosVentahelper.GetAll();

                foreach (var item in ventas)
                {
                    item.TbArticulo = _tbArticulosHelper.Details(item.IdArticulo);
                }

                foreach (var item in ventas)
                {
                    item.TbCliente = _tbClientesHelper.Details(item.IdCliente);
                }

                return View(ventas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult GraficoLinea()
        {
            try
            {
                List<TbDatosVentaViewModel> ventas = _tbDatosVentahelper.GetAll();

                foreach (var item in ventas)
                {
                    item.TbArticulo = _tbArticulosHelper.Details(item.IdArticulo);
                }

                foreach (var item in ventas)
                {
                    item.TbCliente = _tbClientesHelper.Details(item.IdCliente);
                }

                return View(ventas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbDatosVentaController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbDatosVentaViewModel ventaViewModel = _tbDatosVentahelper.Details(id);

                return View(ventaViewModel);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Create
        // GET: TbDatosVentaController/Create
        public ActionResult Create()
        {
            try
            {
                TbDatosVentaViewModel venta = new TbDatosVentaViewModel { };
                venta.Articulos = this.GetArticulos();
                venta.Clientes = this.GetClientes();

                return View(venta);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbDatosVentaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbDatosVentaViewModel venta)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbdatosventa", venta);
                response.EnsureSuccessStatusCode();
                TbDatosVentaViewModel tbDatosVentaViewModel = response.Content.ReadAsAsync<TbDatosVentaViewModel>().Result;
                return RedirectToAction("Details", new { id = tbDatosVentaViewModel.IdVenta });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Update
        // GET: TbDatosVentaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbDatosVentaViewModel tbDatosVentaViewModel = _tbDatosVentahelper.Edit(id);
                return View(tbDatosVentaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbDatosVentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbDatosVentaViewModel venta)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbdatosventa", venta);
                response.EnsureSuccessStatusCode();
                TbDatosVentaViewModel tbDatosVentaViewModel = response.Content.ReadAsAsync<TbDatosVentaViewModel>().Result;
                return RedirectToAction("Details", new { id = tbDatosVentaViewModel.IdVenta });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbDatosVentaController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbDatosVentaViewModel tbDatosVentaViewModel = _tbDatosVentahelper.Delete(id);
                return View(tbDatosVentaViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbDatosCompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbDatosVentaViewModel venta)
        {
            try
            {
                int id = venta.IdVenta;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbdatosventa/" + id.ToString());
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
