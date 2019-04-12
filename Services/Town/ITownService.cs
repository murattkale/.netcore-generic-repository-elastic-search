using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DataModels;
using GenericRepository;
using Entity;

namespace Services
{
    public interface ITownService : IGenericRepo<Town>
    {
        RModel<Town> InsertOrUpdate(Town model);
    }
}
