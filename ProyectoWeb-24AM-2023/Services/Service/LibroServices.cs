using Microsoft.EntityFrameworkCore;
using ProyectoWeb_24AM_2023.Context;
using ProyectoWeb_24AM_2023.Models.Entities;
using ProyectoWeb_24AM_2023.Services.IServices;

namespace ProyectoWeb_24AM_2023.Services.Service
{
    public class LibroServices : ILibroServices
    {
        private readonly ApplicationDbContext _context;
        public LibroServices(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<List<Libro>> GetLibro()
        {
            try
            {

                return await _context.Libros.ToListAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Libro> GetByIdLibro(int id)
        {
            try
            {
                //Articulo response = await _context.Articulos.FindAsync(id);

                Libro response = await _context.Libros.FirstOrDefaultAsync(x => x.PkLibro== id);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public async Task<Libro> CrearLibro(Libro i)
        {
            try
            {
                Libro request = new Libro()
                {
                    Titulo = i.Titulo,
                   // Descripcion = i.Descripcion,
                    Images = i.Images,
                    Activo = i.Activo,
                };

                var result = _context.Libros.Add(request);
                await _context.SaveChangesAsync();

                return request;


            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error" + ex.Message);
            }

        }

        public bool EliminarLibro(int id)
        {
            try
            {
                Libro libro = _context.Libros.Find(id);
                var res = _context.Libros.Remove(libro);
                _context.SaveChanges();
                if (libro != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error " + ex.Message);
            }
        }

    }
}