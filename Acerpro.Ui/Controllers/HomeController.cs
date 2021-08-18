using Acerpro.Business.Abstruct.UiServices;
using Acerpro.Business.Concreate.UiServices;
using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using Acerpro.Shared.Results;
using Acerpro.Ui.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Acerpro.Ui.Controllers
{
    public class HomeController : Controller
    {
        private ICountryCurrencyUiService service;
        public async Task<ActionResult> Index()
        {
            service = new CountryCurrencyUiService();
            var countryList = service.GetCountryList();
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var selectListItem in (countryList as SuccessResult<IList<CountryCodeAndNameDto>>).Result)
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
            service = new CountryCurrencyUiService();
            var list = service.GetCountryCurrencyList(isoCode);
            List<CountryModel> countryCurrencyList = new List<CountryModel>();
            foreach (var item in (list as SuccessResult<IList<CountryCurrencyDto>>).Result)
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
            service = new CountryCurrencyUiService();
            var serviceResult = service.Save(new CountryCurrencyCreateDto
            {
                CurrencyName = model.CountryCurrency,
                CapitalCityName = model.CapitalCity,
                CountryCode = model.CountryIsoCode,
                CountryName = model.Country
            });
            return Json(serviceResult.Message, JsonRequestBehavior.AllowGet);
        }
    }
}