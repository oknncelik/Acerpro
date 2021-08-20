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


        //Index sayfa Vieını döner.
        public async Task<ActionResult> Index()
        {
            service = new CountryCurrencyUiService();
            var countryList = await service.GetCountryList(); // Ülkeler listesini businesstan çeker.
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

        //Ülke ve para birimi bilgisi tablosunu döner. (Örnek ekranda tablo içindeydi o yüzden tablo yaptım.)
        public async Task<PartialViewResult> GetCountryInfo(string isoCode)
        {
            service = new CountryCurrencyUiService();
            var list = await service.GetCountryCurrencyList(isoCode); // Seçilen ülke bilgilerini businesstan çeker.
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

        //Ülke bilgileri Post işlemi.
        // https://stackoverflow.com/questions/6768978/ajax-actionlink-repeating-the-same-exact-get-request-multiple-times/6769211
        // Linkteki gibi bir ajax hatası var static değişkenlerle çözüm uyguladım. (Çok vaktimi aldı araştırmayı bıraktım..:()
        public async Task<JsonResult> PostCountryInfo(CountryModel model)
        {
            if (IsoCode != model.CountryIsoCode)
            {
                IsoCode = model.CountryIsoCode;
                service = new CountryCurrencyUiService();

                //Ülke bilgileri kaydetme.
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