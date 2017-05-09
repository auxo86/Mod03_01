using Mod02_01.DAL;
using Mod02_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod02_01.Controllers
{
    public class OperaController : Controller
    {
        // GET: Opera
        //public ActionResult Index(Opera opera)
        //{
        //    //var test = ModelState.IsValid;
        //    //Opera o = new Opera()
        //    //{
        //    //    OperaID = opera.OperaID,
        //    //    Title = opera.Title,
        //    //    Year = opera.Year,
        //    //    Composer = opera.Composer
        //    //};

        //    return View(opera);
        //} Lab2_4
        // GET:Opera/Index
        public ActionResult Index()
        {
            OperaContext context = new OperaContext();
            return View(context.Operas.ToList());
        }
    }
}