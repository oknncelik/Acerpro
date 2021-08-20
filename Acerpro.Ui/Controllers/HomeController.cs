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
            var countryList = await service.GetCountryList();
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

        public async Task<PartialViewResult> GetCountryInfo(string isoCode)
        {
            service = new CountryCurrencyUiService();
            var list = await service.GetCountryCurrencyList(isoCode);
            List<CountryModel> countryCurrencyList = new List<CountryModel>();
            foreach (var item in (list as SuccessResult<IList<CountryCurrencyDto>>).Result)
            {
                countryCurrencyList.Add(new CountryModel
                {
                    Country = item.CountryName,
                    CapitalCity = item.CapitalCityName,
                    CountryCurrency = item.CurrencyName,
                    CountryCode = item.CountryCode,
                    CountryIsoCode = item.CountryIsoCode,
                    ActiveFlag = item.ActiveFlag
                });
            }
            return PartialView("_CountryCurrencyList", countryCurrencyList);
        }

        public static string IsoCode;
        public static string Message;

        // https://stackoverflow.com/questions/6768978/ajax-actionlink-repeating-the-same-exact-get-request-multiple-times/6769211
        // Linkteki gibi bir ajax hatası var static değişkenlerle çözüm uyguladım şimdilik.
        public async Task<JsonResult> PostCountryInfo(CountryModel model)
        {
            if (IsoCode != model.CountryIsoCode)
            {
                IsoCode = model.CountryIsoCode;
                service = new CountryCurrencyUiService();
                var serviceResult = await Task.Run(() => service.Save(new CountryCurrencyCreateDto
                {
                    CurrencyName = model.CountryCurrency,
                    CapitalCityName = model.CapitalCity,
                    CountryCode = model.CountryCode,
                    CountryIsoCode = model.CountryIsoCode,
                    CountryName = model.Country
                }));
                Message = serviceResult.Message;
            }

            return Json(Message, JsonRequestBehavior.AllowGet);
        }
    }
}