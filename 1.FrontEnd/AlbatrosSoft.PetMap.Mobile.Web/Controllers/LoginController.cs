using AlbatrosSoft.PetMap.Domain.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbatrosSoft.PetMap.Mobile.Web.Controllers
{
    public class LoginController : Controller
    {
        [ThreadStatic]
        private AppUserBll _AppUserBll;

        public AppUserBll AppUserBll
        {
            get
            {
                if (this._AppUserBll == null)
                {
                    this._AppUserBll = new AppUserBll();
                }
                return this._AppUserBll;
            }
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            var users = this.AppUserBll.GetAll();
            return View(users);
        }
    }
}