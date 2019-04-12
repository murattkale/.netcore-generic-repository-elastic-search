using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DataModels;
using GenericRepository;
using Entity;

namespace Services
{
    public class CityService : GenericRepo<City>, ICityService
    {
        public CityService(EFContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<City> InsertOrUpdate(City model)
        {
            //Duplicate Control
            var modelControl = FirstOrDefault(o => o.Id != model.Id && o.Name == model.Name);
            if (modelControl.ResultRow != null)
            {
                modelControl.ResultType = RType.Warning;
                modelControl.MessageList.Add("Name Is Already Taken");
                return modelControl;
            }
           
            if (model.Id > 0)//Edit
            {
                modelControl.ResultRow = Update(model);
            }
            else//Insert
            {
                modelControl.ResultRow = Add(model);
            }
            SaveChanges();//DB Send
            modelControl.ResultType = RType.OK;
            return modelControl;
        }


    }
}
