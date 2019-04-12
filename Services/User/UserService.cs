using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using DataModels;
using GenericRepository;
using Entity;

namespace Services
{
    public class UserService : GenericRepo<Users>, IUserService
    {
        public UserService(EFContext context, IBaseSession sessionInfo) : base(context, sessionInfo)
        {
        }
        public RModel<Users> InsertOrUpdate(Users model)
        {
            //Duplicate Control
            var modelControl = FirstOrDefault(o => o.Id != model.Id && o.EMail == model.EMail);
            if (modelControl.ResultRow != null)
            {
                modelControl.ResultType = RType.Warning;
                modelControl.MessageList.Add("User Name Is Already Taken");
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
