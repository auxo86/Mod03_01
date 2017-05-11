using Mod02_01.DAL;
using Mod02_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }
        //Get:Opera/Create
        //預設是Http get，這裡是get表單
        //這裡的做法是get取下面這個Create
        //post取[HttpPost]後面的Create
        public ActionResult Create() {
            return View();
        }
        //post送出form的資料
        //opera是Data自動bind
        [HttpPost]
        public ActionResult Create(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext context = new OperaContext();
                context.Operas.Add(opera);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }
        //LAB 3-6 修改時先顯示要修改那一筆
        //GET: Opera/Edit/1
        //GET: Opera/Edit?id=1
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperaContext context = new OperaContext();
            Opera o = context.Operas.Find(id);
            if (o == null)
                return HttpNotFound();
            return View(o);
        }
        [HttpPost]
        public ActionResult Edit(Opera opera)
        {
            if (ModelState.IsValid)
            {
                OperaContext context = new OperaContext();
                context.Entry(opera).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opera);
        }

    }
}