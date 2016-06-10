using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCComADO.WebService;
using MVCComADO.Models;

namespace MVCComADO.Controllers
{
    public class TimeController : Controller
    {

        private WebServiceHelper helper;

        [HttpGet]
        public ActionResult ObterTimes()
        {
            this.helper = new WebServiceHelper();
            
            ModelState.Clear();

            return View(this.helper.ObterTimes());
        }

        [HttpGet]
        public ActionResult IncluirTime()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IncluirTime(Time time)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this.helper = new WebServiceHelper();
                    if (this.helper.AdicionaTime(time))
                    {
                        ViewBag.Mensagem = "Time cadastrado com sucesso.";
                    }
                }

                return View();
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
            
        }

        [HttpGet]
        public ActionResult EditarTime(int id)
        {
            this.helper = new WebServiceHelper();
            return View(this.helper.ObterTimes().Find(t => t.Id == id));
        }

        [HttpPost]
        public ActionResult EditarTime(int id, Time time)
        {
            try
            {
                this.helper = new WebServiceHelper();
                this.helper.AtualizarTime(time);
                return RedirectToAction("ObterTimes");

               
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }

        }

        public ActionResult ExcluirTime(int id)
        {
            try
            {
                this.helper = new WebServiceHelper();
                if (this.helper.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time Exluído com sucesso.";
                }

                return RedirectToAction("ObterTimes");
            }
            catch (Exception)
            {
                return View("ObterTimes");
            }
            
        }
    }
}