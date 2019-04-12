//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Data.Common;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entity
//{
//    public class CustomDbConfiguration : IConfiguration
//    {
//        public CustomDbConfiguration()
//        {
//            //SetManifestTokenResolver(new CustomManifestTokenResolver());
//        }
//    }

//    public class CustomManifestTokenResolver : IManifestTokenResolver
//    {
//        public string ResolveManifestToken(DbConnection connection)
//        {
//            return "2016";
//        }
//    }
//}
