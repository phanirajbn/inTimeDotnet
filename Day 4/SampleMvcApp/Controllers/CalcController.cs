using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ViewResult Index()
        {
            //Returns a ViewObject whose name is matching to the name of the Action...
            return View(new CalcModel { Value1 = 123, Value2 = 234, Operation = "Subtract" });
        }

        //The data that is posted to this action....
        [HttpPost]
        public ViewResult Index(CalcModel model)
        {
            switch (model.Operation)
            {
                case "Add":
                    model.Result = model.Value1 + model.Value2;
                    break;
                case "Subtract":
                    model.Result = model.Value1 - model.Value2;
                    break;
                default:
                    model.Result = model.Value1 * model.Value2;
                    break;
            }
            return View(model);
        }
    }
}