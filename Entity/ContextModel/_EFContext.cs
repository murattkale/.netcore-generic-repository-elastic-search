//using DataModels.ContextModel;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entity
//{
//    //[DbConfigurationType(typeof(CustomDbConfiguration))]
//    public class _EFContext : Model1
//    {
//        public _EFContext()
//        {
//            //this.Database.CommandTimeout = Int32.MaxValue;
//            this.Configuration.LazyLoadingEnabled = false;
//            this.Configuration.AutoDetectChangesEnabled = false;
//            this.Configuration.ProxyCreationEnabled = false;
//        }
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            Database.SetInitializer<_EFContext>(null);
//            base.OnModelCreating(modelBuilder);
//        }

//    }
//}
