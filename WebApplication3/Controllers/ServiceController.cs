using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Models.ViewModel;

namespace WebApplication3.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult List()
        {
            List<ListServiceViewModel> lts = new List<ListServiceViewModel>();
            using (Models.pruebaEntities db = new Models.pruebaEntities())
            {
                lts =
                    (from d in db.services
                     orderby d.id descending
                     select new ListServiceViewModel
                     {
                         Id = d.id,
                         Name = d.name,
                         Description = d.description,
                         State = d.state
                     }).ToList();
            }
            
            return View(lts);
        }

        public ActionResult New()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(ServiceViewModel model)
        {
            try
            {
                using (Models.pruebaEntities db = new Models.pruebaEntities())
                {
                    var newS = new services();
                    newS.name = model.Name;
                    newS.description = model.Description;
                    newS.state = 1;
                    db.services.Add(newS);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
        

        public ActionResult Edit(int Id)
        {
            try
            {
                ServiceViewModel model = new ServiceViewModel();
                using (Models.pruebaEntities db = new Models.pruebaEntities())
                {
                    var newS = db.services.Find(Id);
                    model.Name = newS.name;
                    model.Description = newS.description;
                    model.State = newS.state;
                    model.Id = newS.id;
                }

                return View(model);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Update(ServiceViewModel model)
        {
            try
            {
                using (Models.pruebaEntities db = new Models.pruebaEntities())
                {
                    var newS = db.services.Find(model.Id);
                    newS.name = model.Name;
                    newS.description = model.Description;
                    newS.state = model.State;
                    db.Entry(newS).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                using (Models.pruebaEntities db = new Models.pruebaEntities())
                {
                    var newS = db.services.Find(Id);
                    db.services.Remove(newS);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}