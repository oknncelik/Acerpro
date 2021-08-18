using Acerpro.Ui.AcerproService;
using Acerpro.Ui.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Acerpro.Ui.Controllers
{
    public class HomeController : Controller
    {
        private ICountryCurrency service;
        public async Task<ActionResult> Index()
        {
            service = new CountryCurrencyClient();
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

        public PartialViewResult GetCountryInfo(string isoCode)
        {
            service = new CountryCurrencyClient();
            var list = service.GetCountryCurrencyListAsync(isoCode).Result;
            List<CountryModel> countryCurrencyList = new List<CountryModel>();
            foreach (var item in list.Result)
            {
                countryCurrencyList.Add(new CountryModel
                {
                    Country = item.CountryName,
                    CapitalCity = item.CapitalCityName,
                    CountryCurrency = item.CurrencyName,
                    CountryIsoCode = item.CountryCode
                });
            }
            return PartialView("_CountryCurrencyList", countryCurrencyList);
        }

        public JsonResult PostCountryInfo(CountryModel model)
        {
            return Json("Ok.", JsonRequestBehavior.AllowGet);
        }
    }
}