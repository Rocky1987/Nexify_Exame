using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nexify.DataAccess.DataModel;
namespace Nexify.DataAccess.Repository
{   
         public interface IUerRepository
        {
            void Creat();

            int Add(UserDataModel userDataModel);

             IEnumerable<UserDataModel> Query();
        }   
}
