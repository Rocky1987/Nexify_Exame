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
            }

            //IEnumerable<UserDataModel> users = this.uerRepository.Query();

            return View();
        }
    }
}