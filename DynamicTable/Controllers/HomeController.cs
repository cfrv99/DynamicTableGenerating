using DynamicTable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicTable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var rm = DynamicTable.GenerateDynamicTable(1, context);
            return View(rm);
        }


        public IActionResult CreateView()
        {
            var headersForFormValue = context.TableHeaders
                .Where(i => i.TableId == 1)
                .ToList();
            CreateModel model = new CreateModel()
            {
                TableHeaders = headersForFormValue
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateView(CreateModel model)
        {
            var lastRowNum = context.TableValues.Select(i => i.RowNum).Max();
            var newRowNum = lastRowNum + 1;
            foreach (var item in model.Parameters)
            {
                TableValue tv = new TableValue()
                {
                    RowNum = newRowNum,
                    HeaderId = item.Key,
                    Value = item.Value
                };
                context.TableValues.Add(tv);
            }
            context.SaveChanges();

            return RedirectToAction("CreateView","Home");
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
