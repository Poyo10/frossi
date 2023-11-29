using frossi.Models;

namespace frossi.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Users> GetUsuario(string email, string password);
        Task<Users> SaveUsuario(Users modelo);
    
    }
}
