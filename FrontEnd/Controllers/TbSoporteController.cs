using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbSoporteController : Controller
    {
        #region Constructor
        TbSoporteHelper _tbSoportehelper;
        TbClientesHelper _tbClienteHelper;
        TbEmpleadoHelper _tbEmpleadoHelper;
        TbTipoHelper _tbTipoHelper;

        public TbSoporteController()
        {
            _tbSoportehelper = new TbSoporteHelper();
            _tbClienteHelper = new TbClientesHelper();
            _tbEmpleadoHelper = new TbEmpleadoHelper();
            _tbTipoHelper = new TbTipoHelper();
        }
        #endregion

        #region Obtiene Cliente
        private TbClientesViewModel GetCliente(int id)
        {
            try
            {
                TbClientesViewModel clienteViewModel = _tbClienteHelper.Details(id);
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
            List<TbClientesViewModel> clientes = _tbClienteHelper.GetAll();

            return clientes;
        }
        #endregion

        #region Obtiene Empleado
        private TbEmpleadoViewModel GetEmpleado(int id)
        {
            try
            {
                TbEmpleadoViewModel empleadoViewModel = _tbEmpleadoHelper.Details(id);
                return empleadoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Empleados
        private List<TbEmpleadoViewModel> GetEmpleados()
        {
            List<TbEmpleadoViewModel> empleados = _tbEmpleadoHelper.GetAll();

            return empleados;
        }
        #endregion

        #region Obtiene Tipo
        private TbTipoViewModel GetTipo(int id)
        {
            try
            {
                TbTipoViewModel tipoViewModel = _tbTipoHelper.Details(id);
                return tipoViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Tipos
        private List<TbTipoViewModel> GetTipos()
        {
            List<TbTipoViewModel> tipos = _tbTipoHelper.GetAll();

            return tipos;
        }
        #endregion

        #region Read
        // GET: TbSoporteController
        public ActionResult Index()
        {
            try
            {
                List<TbSoporteViewModel> soportes = _tbSoportehelper.GetAll();

                foreach (var item in soportes)
                {
                    item.TbCliente = _tbClienteHelper.Details(item.IdCliente);
                }

                foreach (var item in soportes)
                {
                    item.TbEmpleado = _tbEmpleadoHelper.Details(item.IdEmpleado);
                }

                foreach (var item in soportes)
                {
                    item.TbTipo = _tbTipoHelper.Details(item.IdTipo);
                }

                return View(soportes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbSoporteController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                TbSoporteViewModel soporteViewModel = _tbSoportehelper.Details(id);

                return View(soporteViewModel);

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
 
        #region Create
        // GET: TbSoporteController/Create
        public ActionResult Create()
        {
            try
            {
                TbSoporteViewModel soporte = new TbSoporteViewModel { };
                soporte.Clientes = this.GetClientes();
                soporte.Empleados = this.GetEmpleados();
                soporte.Tipos = this.GetTipos();

                return View(soporte);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbSoporteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbSoporteViewModel soporte)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbsoporte", soporte);
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel tbSoporteViewModel = response.Content.ReadAsAsync<TbSoporteViewModel>().Result;
                return RedirectToAction("Details", new { id = tbSoporteViewModel.IdSoporte });
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region Update
        // GET: TbSoporteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TbSoporteViewModel tbSoporteViewModel = _tbSoportehelper.Edit(id);
                return View(tbSoporteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbSoporteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbSoporteViewModel soporte)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbsoporte", soporte);
                response.EnsureSuccessStatusCode();
                TbSoporteViewModel tbSoporteViewModel = response.Content.ReadAsAsync<TbSoporteViewModel>().Result;
                return RedirectToAction("Details", new { id = tbSoporteViewModel.IdSoporte });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbSoporteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TbSoporteViewModel tbSoporteViewModel = _tbSoportehelper.Delete(id);
                return View(tbSoporteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbSoporteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbSoporteViewModel soporte)
        {
            try
            {
                int id = soporte.IdSoporte;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/tbsoporte/" + id.ToString());
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
