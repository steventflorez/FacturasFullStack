using Gestion_facturas.Models.DataModels;

namespace Gestion_facturas.ServicesInterface
{
    public interface IUsersService
    {
        IEnumerable<Users> GetUsersbyEmail();
        IEnumerable<Users> GetUsersAdmins();
        IEnumerable<Users> GetUsersNotAdmins();
    }
}
