using KJMC.BL.DTOs.ServicioDTOs;
using KJMC.BL.Interfaces;
using KJMC.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace KJMC.UI.WebMVC.Controllers
{
    public class ServicioController : Controller
    {
        readonly IServicioBL _servicioBL;
        public ServicioController(IServicioBL servicioBL)
        {
            _servicioBL = servicioBL;
        }
        // GET: ServicioController
        public async Task<IActionResult> Index(ServicioSearchInputDTO servicio)
        {
            var list = await _servicioBL.Search(servicio);
            return View(list);
        }

        // GET: ServicioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            ServicioGetByIdDTO servicio = await _servicioBL.GetById(id);
            return View(servicio);
        }

        // GET: ServicioController/Create
        public ActionResult Create()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        // POST: ServicioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicioAddDTO xservicio)
        {
            try
            {
                int result = await _servicioBL.Create(xservicio);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE REGISTRO";
                    return View(xservicio);
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: ServicioController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ServicioGetByIdDTO servicio = await _servicioBL.GetById(id);
            var Servicio = new ServicioUpdateDTO()
            {
                Id = servicio.Id
            };
            return View(Servicio);
        }

        // POST: ServicioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicioUpdateDTO servicio)
        {
            try
            {
                int result = await _servicioBL.Update(servicio);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE MODIFICO";
                    return View(servicio);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: ServicioController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
          ServicioGetByIdDTO servicio = await _servicioBL.GetById(id);
            return View(servicio);
        }

        // POST: ServicioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ServicioGetByIdDTO servicio)
        {
            try
            {
                int result = await _servicioBL.Delete(id);
                if (result > 0)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.ErrorMessage = "ERROR: NO SE ELIMINO";
                    return View(servicio);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
