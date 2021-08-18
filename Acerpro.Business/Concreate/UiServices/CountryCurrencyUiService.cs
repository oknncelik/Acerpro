using Acerpro.Business.Abstruct;
using Acerpro.Business.Abstruct.UiServices;
using Acerpro.Business.CountryCurrencyWcfService;
using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using Acerpro.Shared.Results;
using Acerpro.Shared.Results.Abstruct;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acerpro.Business.Concreate.UiServices
{
    public class CountryCurrencyUiService : ICountryCurrencyUiService
    {
        private readonly ICountryCurrencyService _countryCurrencyService;
        private readonly ICountryCurrency _countryCurrencyWcfService;
        public CountryCurrencyUiService()
        {
            _countryCurrencyService = new CountryCurrencyService();
            _countryCurrencyWcfService = new CountryCurrencyClient();
        }


        public IResult GetCountryCurrencyList(string isoCode)
        {
            ServiceResultOfArrayOfCountryCurrencyDtoNGKS6tMi serviceResult;
            serviceResult = _countryCurrencyWcfService.GetCountryCurrencyList(isoCode);
            if (serviceResult.IsSuccess)
            {
                var result = serviceResult.Result.Select(x => new CountryCurrencyDto
                {
                    CurrencyName = x.CurrencyName,
                    CapitalCityName = x.CapitalCityName,
                    CountryCode = x.CountryCode,
                    CountryName = x.CountryName
                }).ToList();

                return new SuccessResult<IList<CountryCurrencyDto>>(result, "List of Countries and Currencies");
            }
            else
            {
                return new ErrorResult(serviceResult.Message);
            }
        }

        public IResult GetCountryList()
        {
            ServiceResultOfArrayOfCountryCodeAndNameDtoJLzdrnDW serviceResult;
            serviceResult = _countryCurrencyWcfService.GetCountryList();

            if (serviceResult.IsSuccess)
            {
                var result = serviceResult.Result.Select(x => new CountryCodeAndNameDto
                {
                    ISOCode = x.ISOCode,
                    Name = x.Name
                }).ToList();

                return new SuccessResult<IList<CountryCodeAndNameDto>>(result, "List of Countries");
            }
            else
            {
                return new ErrorResult(serviceResult.Message);
            }
        }

        public IResult Save(CountryCurrencyCreateDto createDto)
        {
            ServiceResultOfCountryCurrencyDtoNGKS6tMi serviceResult;
            serviceResult = _countryCurrencyWcfService.Save(createDto);

            if (serviceResult.IsSuccess)
            {

                var result = new CountryCurrencyDto
                {
                    CurrencyName = serviceResult.Result.CountryName,
                    CapitalCityName = serviceResult.Result.CapitalCityName,
                    CountryCode = serviceResult.Result.CountryCode,
                    CountryName = serviceResult.Result.CountryName
                };

                return new SuccessResult<CountryCurrencyDto>(result, "List of Countries");
            }
            else
            {
                return new ErrorResult(serviceResult.Message);
            }
        }
    }
}
