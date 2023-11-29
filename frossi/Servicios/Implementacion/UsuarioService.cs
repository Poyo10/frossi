using Microsoft.EntityFrameworkCore;
using frossi.Data;
using frossi.Models;
using frossi.Servicios.Contrato;

namespace frossi.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _dbContext;
        public UsuarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Users> GetUsuario(string email, string password)
        {
            Users usuario_encontrado = await _dbContext.Users.Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Users> SaveUsuario(Users modelo)
        {
            _dbContext.Users.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;

        }
    }
}
