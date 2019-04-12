using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DataModels;
using GenericRepository;
using Entity;

namespace Services
{
    public interface IUserService : IGenericRepo<Users>
    {
        RModel<Users> InsertOrUpdate(Users model);
    }
}
