﻿using Acerpro.Business.Abstruct.UiServices;
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
    //Ui dan gelen istekler için WCF e istek atılır.
    public class CountryCurrencyUiService : ICountryCurrencyUiService
    {
        private readonly ICountryCurrency _countryCurrencyWcfService;

        public CountryCurrencyUiService()
        {
            _countryCurrencyWcfService = new CountryCurrencyClient();
        }

        public async Task<IResult> GetCountryCurrencyList(string isoCode)
        {
            //Kayıtlıysa dbden çek.
            var dbResult = await Task.Run(()=> _countryCurrencyWcfService.GetByIsoCode(isoCode));
            if (dbResult.Result != null)
            {
                var list = new List<CountryCurrencyDto>()
                {
                    new CountryCurrencyDto
                    {
                        CurrencyName = dbResult.Result.CountryName,
                        CapitalCityName = dbResult.Result.CapitalCityName,
                        CountryCode = dbResult.Result.CountryCode,
                        CountryName = dbResult.Result.CountryName,
                        ActiveFlag = dbResult.Result.ActiveFlag
                    }
                };
                return new SuccessResult<IList<CountryCurrencyDto>>(list, "List of Countries and Currencies");
            }


            ServiceResultOfArrayOfCountryCurrencyDtoNGKS6tMi serviceResult;
            serviceResult = await Task.Run(() => _countryCurrencyWcfService.GetCountryCurrencyList(isoCode));
            if (serviceResult.IsSuccess)
            {
                var result = serviceResult.Result.Select(x => new CountryCurrencyDto
                {
                    CurrencyName = x.CurrencyName,
                    CapitalCityName = x.CapitalCityName,
                    CountryCode = x.CountryCode,
                    CountryName = x.CountryName,
                    CountryIsoCode = x.CountryIsoCode
                }).ToList();

                return new SuccessResult<IList<CountryCurrencyDto>>(result, "List of Countries and Currencies");
            }
            else
                return new ErrorResult(serviceResult.Message);
        }

        public async Task<IResult> GetCountryList()
        {
            ServiceResultOfArrayOfCountryCodeAndNameDtoJLzdrnDW serviceResult;
            serviceResult = await Task.Run(() => _countryCurrencyWcfService.GetCountryList());

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
                return new ErrorResult(serviceResult.Message);
        }

        public async Task<IResult> Save(CountryCurrencyCreateDto createDto)
        {
            ServiceResultOfCountryCurrencyDtoNGKS6tMi serviceResult;
            serviceResult = await Task.Run(()=> _countryCurrencyWcfService.Save(createDto));

            if (serviceResult.IsSuccess)
            {
                var result = new CountryCurrencyDto
                {
                    CurrencyName = serviceResult.Result.CountryName,
                    CapitalCityName = serviceResult.Result.CapitalCityName,
                    CountryCode = serviceResult.Result.CountryCode,
                    CountryName = serviceResult.Result.CountryName,
                    CountryIsoCode = serviceResult.Result.CountryIsoCode
                };

                return new SuccessResult<CountryCurrencyDto>(result, "Added.");
            }
            else
                return new ErrorResult(serviceResult.Message);
        }
    }
}
