using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BasicASPCore2.Controllers
{
    public class DefaultController:Controller
    {
        public IActionResult List()
        {
            var model = new List<(string, string)>()
            {
                ("Donald","Trump"),
                ("Barack","Obama"),
                ("George W.","Bush")
            };

            return View("/Views/DefaultList.cshtml",model);
            
            //view.ViewData.Model = model;
            //return view;
        }
        public string Index(int id)
        {
            var welcome = "Welcome to ASP.net core MVC";
            if (id==0)
            {
                return welcome;
            }
            return $"Hello, {id}! " + welcome;
        }
    }
}
