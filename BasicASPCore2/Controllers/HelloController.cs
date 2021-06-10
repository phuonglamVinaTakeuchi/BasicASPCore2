using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BasicASPCore2.Controllers
{
    public class HelloController
    {
        private readonly IModelMetadataProvider _provider;
        public ViewDataDictionary ViewData { get; set; }
        public ModelStateDictionary ModelState = new ModelStateDictionary();

        public HelloController(IModelMetadataProvider provider)
        {
            _provider = provider;
            ViewData = new ViewDataDictionary(_provider, ModelState);
        }
        public string Index()
        {
            return "Test Index MVC";
        }
        //[Route("Hi")]
        public ViewResult WithView()
        {
            return new ViewResult() {ViewName = "/Views/HelloWithView.cshtml"};
            
        }
        
        public ViewResult CreateView(string viewName)
        {
            return new ViewResult() { ViewName = viewName };

        }

        //[HttpGet]
        [Route("Hi")]
        public string Hi() => "Hello World";

        //[HttpPost]
        [Route("Hi/{name}")]
        public string Hi(string name) => $"Hello {name}";
        public ViewResult WithViewData()
        {
            var model = new List<(string, string)>()
            {
                ("Donald", "Trump"),
                ("Barack", "Obama"),
                ("George w.", "Brush")
            };
            var view = CreateView("/Views/HelloWithViewData.cshtml");
            view.ViewData = ViewData;
            view.ViewData.Model = model;
            return view;
        }

        public IActionResult StringModel()
        {
            ViewData.Model = "Hello World from home ";
            var view = new ViewResult()
            {
                ViewName = "/Views/Home/StringModel.cshtml",
                ViewData = ViewData
            };
            view.ViewData = ViewData;
            return view;
        }

        public IActionResult TupleModel()
        {
            ViewData.Model = ("Danald", "Trump", new DateTime(1900, 12, 31));
            var view = new ViewResult
            {
                ViewData = ViewData
            };
            return view;
        }
        
    }
}
