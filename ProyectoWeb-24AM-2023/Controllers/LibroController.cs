using Microsoft.AspNetCore.Mvc;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;
using ProyectoWeb_24AM_2023.Services.Service;

namespace ProyectoWeb_24AM_2023.Controllers
{
    public class LibroController : Controller
    {

        private readonly ILibroServices _libroServices;
        public LibroController(ILibroServices libroServices)
        {
            _libroServices = libroServices;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                var response = await _libroServices.GetLibro();

                return View(response);


            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }

        }
        [HttpGet]

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro request)
        {
            var response = _libroServices.CrearLibro(request);
            return RedirectToAction(nameof(Index));
        }

        //hacer tryca

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var response = _libroServices.EliminarLibro(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
