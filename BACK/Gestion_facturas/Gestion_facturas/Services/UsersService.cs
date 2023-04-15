using Gestion_facturas.Models.DataModels;
using Gestion_facturas.ServicesInterface;

namespace Gestion_facturas.Services
{
    public class UsersService : IUsersService
    {
        public IEnumerable<Users> GetUsersAdmins()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUsersbyEmail()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUsersNotAdmins()
        {
            throw new NotImplementedException();
        }
    }
}
