using Acerpro.Ui.AcerproService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Acerpro.Ui.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ICountryCurrency service = new CountryCurrencyClient();
            var countryList = await service.GetCountryListAsync();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var selectListItem in countryList.Result)
            {
                listItems.Add(new SelectListItem
                {
                    Text = selectListItem.Name,
                    Value = selectListItem.ISOCode
                });
            }
            ViewBag.CoutryList = listItems;
            return View();
        }
    }
}