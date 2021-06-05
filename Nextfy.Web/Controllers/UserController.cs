using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nexify.DataAccess.Repository;
using Nexify.DataAccess.DataModel;
namespace Nextfy.Web.Controllers
{
    public class UserController : Controller
    {
        //private readonly IUerRepository uerRepository = new UserRepository(cnStr);
       
        private readonly IUerRepository uerRepository;
        // GET: User
        public UserController(IUerRepository uerRepository)
        {
            if (uerRepository == null)
                throw new ArgumentNullException("uerRepository is null");

            this.uerRepository = uerRepository;
        }


        public ActionResult Index()
        {
            string dbPath = System.Web.HttpContext.Current.Server.MapPath("~/Dbdata/User.sqlite");
            string cnStr = "data source=" + dbPath;
            if (!System.IO.File.Exists(dbPath))
            {
                this.uerRepository.Creat();
                //List<UserDataModel> userDataModelList = new List<UserDataModel>();

                //UserDataModel a = new UserDataModel
                //{
                //    Name = "ASD",
                //    DateOfBirth = new DateTime(2019, 5, 13),
                //    Salary = 40000,
                //    Address = "ASD"
                //};

                //userDataModelList.Add(a);
                //UserDataModel b = new UserDataModel
                //{
                //    Name = "Jay",
                //    DateOfBirth = new DateTime(1995, 7, 21),
                //    Salary = 100000,
                //    Address = "新北市"
                //};

                //userDataModelList.Add(b);
                //UserDataModel c = new UserDataModel
                //{
                //    Name = "Leo",
                //    DateOfBirth = new DateTime(1993, 7, 1),
                //    Salary = 50000,
                //    Address = "新北市"
                //};

                //userDataModelList.Add(c);
                //UserDataModel d = new UserDataModel
                //{
                //    Name = "Test",
                //    DateOfBirth = new DateTime(2019, 5, 13),
                //    Salary = 50000,
                //    Address = "台北市"
                //};

                //userDataModelList.Add(d);
         
                //UserDataModel e = new UserDataModel
                //{
                //    Name = "ZXC",
                //    DateOfBirth = new DateTime(2019, 5, 13),
                //    Salary = 40000,
                //    Address = "ZXC"
                //};

                //userDataModelList.Add(e);

                //foreach (UserDataModel item in userDataModelList) {
                //    this.uerRepository.Add(item);
                //}
            }

            //IEnumerable<UserDataModel> users = this.uerRepository.Query();

            return View();
        }
    }
}