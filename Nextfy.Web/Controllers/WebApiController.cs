using Nexify.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nexify.Web.Models;
using Nexify.Web.Models.ViewModel;
using Nexify.DataAccess.DataModel;
using Newtonsoft.Json;
namespace Nexify.Web.Controllers
{
    public class WebApiController : Controller
    {
        private readonly IUerRepository uerRepository;
        // GET: User
        public WebApiController(IUerRepository uerRepository)
        {
            if (uerRepository == null)
                throw new ArgumentNullException("uerRepository is null");

            this.uerRepository = uerRepository;
        }
        // GET: Api
        public ActionResult Index()
        {
            return View();
        }

        public string getUsertData()
        {
            WebApiViewModel<IEnumerable<UserViewModel>> resp = new WebApiViewModel<IEnumerable<UserViewModel>>();
            try
            {
                IEnumerable<UserDataModel> userdata = this.uerRepository.Query();
                IEnumerable<UserViewModel> respData = null;
                if (userdata != null && userdata.Any()) {
                    respData = userdata.Select(p => new UserViewModel
                    {
                        Name = p.Name,
                        DateOfBirth = p.DateOfBirth.ToString("MM/dd/yyyy"),
                        Salary = p.Salary,
                        Address = p.Address
                    });
                }
                resp.status = 1;               
                resp.Data = respData;
            }
            catch(Exception ex) {
                resp.status = 0;
                resp.errorMessage = ex.Message;
                resp.Data = null;
            }
            return JsonConvert.SerializeObject(resp);
        }
    }
}