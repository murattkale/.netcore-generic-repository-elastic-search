using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DataModels;
using GenericRepository;
using Entity;

namespace Services
{
    public interface ICityService : IGenericRepo<City>
    {
        RModel<City> InsertOrUpdate(City model);
    }
}
