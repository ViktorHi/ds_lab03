using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using ServiceReference1;
using System.ServiceModel.Channels;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private User user;
        private PolyclinicServiceClient  service = new PolyclinicServiceClient();
        private int crutch = -42069;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        #region login

        public IActionResult Login()
        {
            return View("login");
        }

        public IActionResult SignUP()
        {
            return View("sign_up");
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            var usr = new User(login, password);
            //if (!service.IsUser(usr))
            //{
            //    return Login();
            //}
            user = usr;

            return Index();
        }


        [HttpPost]
        public IActionResult SignUp(string login, string password1, string password2)
        {

            //if (login!= null && password1 != null && password2 != null && login.Trim() != "" && password1.Trim() != "" && password2.Trim() != "" && password1.Trim() == password2.Trim())
            //{
                
            //    service.AddUser(new Models.User(login.Trim(), password2.Trim()));
            //    return Login();
            //}

            return SignUP();
        }
        #endregion

        #region view

        public IActionResult Index()
        {
            return View("Index");
        }

        #region token bought
        [HttpPost]
        public IActionResult BoughtToken(DateTime day1, DateTime day2)
        {
            var get = getCheckBoxValue("get");
            var edit = getCheckBoxValue("edit");
            var create = getCheckBoxValue("create");
            var delete = getCheckBoxValue("delete");

            if (day1 > day2)
                return PayForToken();

            if (get)
                service.PayTokenAsync(new TokenPaymentDto(Functions.Get, day1, day2));
            if (edit)
                service.PayTokenAsync(new TokenPaymentDto(Functions.Update, day1, day2));

            if (create)
                service.PayTokenAsync(new TokenPaymentDto(Functions.Create, day1, day2));

            if (delete)
                service.PayTokenAsync(new TokenPaymentDto(Functions.Delete, day1, day2));


            return Index();
        }

        private bool getCheckBoxValue(String line)
        {
            var form = Request.Form[line];
            if (form.Count == 0)
            {
                return false;
            }

            return form[0] == "on";
        }


        public IActionResult PayForToken()
        {
            if (CheckUser())
            {
                return Login();
            }

            Token[] t = service.getTokenPaymentsAsync().Result;

            ViewBag.tokens = t;
            return View("bought_page");
        }
        #endregion

        #region update and create
        public IActionResult Order()
        {
            if (CheckUser())
            {
                return Login();
            }

            if (!service.IsTokenExistsAsync(Functions.Create).Result)
            {
                return PayForToken();
            }

            ViewBag.visit = new Visit(crutch, "", "", DateTime.MinValue, "");
            return View("create_or_update");
        }

        public IActionResult Update(int id)
        {
            if (CheckUser())
            {
                return Login();
            }

            if (!service.IsTokenExistsAsync(Functions.Update).Result)
            {
                return PayForToken();
            }

            Visit vis = service.GetVisitsAsync().Result.Where(p => p.Id.Equals(id)).FirstOrDefault();
            ViewBag.visit = vis;

            return View("create_or_update");
        }

        [HttpPost]
        public IActionResult AppllyUpdate(int Id, string doctor_fio, string patient_fio, DateTime day_time, string speciality)
        {
            if (Id == crutch)
            {
                service.CreateVisitAsync( new Visit(0, doctor_fio, patient_fio, day_time, speciality));
            }
            else
            {
                service.UpdateVisitAsync(new Visit(Id, doctor_fio, patient_fio, day_time, speciality));
            }


            return Index();
        }
        #endregion

        #region get
        public IActionResult Visits()
        {
            if (CheckUser())
            {
                return Login();
            }

            if (!service.IsTokenExistsAsync(Functions.Get).Result)
            {
                return PayForToken();
            }


            ViewBag.visits = service.GetVisitsAsync().Result;

            return View("visits");
        }

        #endregion

        #region delete

        public IActionResult Delete(int id)
        {
            if (CheckUser())
            {
                return Login();
            }
            if (!service.IsTokenExistsAsync(Functions.Delete).Result)
            {
                return PayForToken();
            }
            service.DeleteVisitAsync(new Visit(id,"","",DateTime.Now, ""));

            return Visits();
        }

        #endregion

        #endregion

        private bool CheckUser()
        {
            return false;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
