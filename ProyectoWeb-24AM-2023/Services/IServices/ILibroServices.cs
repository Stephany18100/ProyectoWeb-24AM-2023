using ProyectoWeb_24AM_2023.Models.Entities;

namespace ProyectoWeb_24AM_2023.Services.IServices
{
    public interface ILibroServices
    {
        public Task<List<Libro>> GetLibro();
        public Task<Libro> GetByIdLibro(int id);

        public Task<Libro> CrearLibro(Libro i);

        public bool EliminarLibro(int id);
    }
}
