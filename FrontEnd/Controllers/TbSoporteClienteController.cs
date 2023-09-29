using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TbSoporteClienteController : Controller
    {

        TbSoporteClienteHelper _tbSoporteClientehelper;
        TbClientesHelper _tbClienteshelper;
        TbSoporteHelper _tbSoporteHelper;


        public TbSoporteClienteController()
        {
            _tbSoporteClientehelper = new TbSoporteClienteHelper();
            _tbClienteshelper = new TbClientesHelper();
            _tbSoporteHelper = new TbSoporteHelper();

        }

        private TbClientesViewModel GetClientes(int id)
        {
            try
            {
                TbClientesViewModel clientesViewModel = _tbClienteshelper.Details(id);
                return clientesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Obtiene Clientes
        private List<TbClientesViewModel> GetClientes()
        {
            List<TbClientesViewModel> scliente = _tbClienteshelper.GetAll();

            return scliente;
        }


        private TbSoporteViewModel GetSoporte(int id)
        {
            try
            {
                TbSoporteViewModel soporteViewModel = _tbSoporteHelper.Details(id);
                return soporteViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Obtiene Clientes
        private List<TbSoporteViewModel> GetSoporte()
        {
            List<TbSoporteViewModel> ssoporte = _tbSoporteHelper.GetAll();

            return ssoporte;
        }

        #endregion

        #region Read
        public ActionResult Index()
        {

            List<TbSoporteClienteViewModel> scliente = _tbSoporteClientehelper.GetAll();

        

            foreach (var item in scliente)
            {
                item.TbClientes = _tbClienteshelper.Details(item.IdCliente);
            }
            foreach (var item in scliente)
            {
                item.TbSoporte = _tbSoporteHelper.Details(item.IdSoporte);
            }
            return View(scliente);
          

        }

        // GET: TbSoporteClienteController/Details/5
        public ActionResult Details(int id)
        {
            TbSoporteClienteViewModel clienteViewModel = _tbSoporteClientehelper.Details(id);

            return View(clienteViewModel);
        }



        #endregion

        #region create

        // GET: TbSoporteClienteController/Create
        public ActionResult Create()
        {
            try
            {
                TbSoporteClienteViewModel scliente = new TbSoporteClienteViewModel { };
                scliente.Clientes = this.GetClientes();
                scliente.Soporte = this.GetSoporte();


                return View(scliente);

            }
            catch (Exception)
            {

                throw;
            }
        }
        // POST: TbSoporteClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbSoporteClienteViewModel csoporte)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/tbsoportecliente", csoporte);
                response.EnsureSuccessStatusCode();
                TbSoporteClienteViewModel tbSoporteClienteViewModel = response.Content.ReadAsAsync<TbSoporteClienteViewModel>().Result;
                return RedirectToAction("Details", new { id = tbSoporteClienteViewModel.IdSoporteCliente});
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region update csoporte

        public ActionResult Edit(int id)
        {
            try
            {
                TbSoporteClienteViewModel tbSoporteclienteViewModel = _tbSoporteClientehelper.Edit(id);
                return View(tbSoporteclienteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbDatosCompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TbSoporteClienteViewModel csoporte)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/tbsoportecliente", csoporte);
                response.EnsureSuccessStatusCode();
                TbSoporteClienteViewModel tbSoporteClienteViewModel = response.Content.ReadAsAsync<TbSoporteClienteViewModel>().Result;
                return RedirectToAction("Details", new { id = tbSoporteClienteViewModel.IdSoporteCliente });
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region delete


        // GET: TbSoporteClienteController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {

            try
            {
                TbSoporteClienteViewModel tbSoporteClienteViewModel = _tbSoporteClientehelper.Delete(id);
                return View(tbSoporteClienteViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbSoporteClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TbSoporteClienteViewModel csoporte)
        {
            {
                try
                {
                    int id = csoporte.IdSoporteCliente;
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.DeleteResponse("api/tbsoportecliente/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        }

            #endregion
        }
}



//hasta aca clientes





// GET: TbSoporteClienteController




#endregion

