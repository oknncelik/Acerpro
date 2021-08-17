using Acerpro.Business.Abstruct;
using Acerpro.Data.Abstruct.Repositories;
using Acerpro.Data.Concreate.Repositories;
using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using Acerpro.Entities.Concreate.Entities;
using Acerpro.Integrations.Abstruct;
using Acerpro.Integrations.Concreate;
using Acerpro.Shared.Results;
using Acerpro.Shared.Results.Abstruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acerpro.Business.Concreate
{
    public class CountryCurrencyService : ICountryCurrencyService
    {
        private readonly ICountryCurrencyRepository _countryCurrencyRepository;
        private readonly ICountryInfoIntegration _countryInfoIntegration;
        public CountryCurrencyService()
        {
            _countryCurrencyRepository = new CountryCurrencyRepository();
            _countryInfoIntegration = new CountryInfoIntegration();
        }
        public async Task<IResult> Get()
        {
            try
            {
                var resultList = await _countryCurrencyRepository.GetList();
                return new SuccessResult<IList<CountryCurrencyDto>>(resultList.Select(EntityToData).ToList(), "List of Countries and Currencies");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> GetById(int id)
        {
            try
            {
                var resultList = await _countryCurrencyRepository.Get(x=> x.Id == id);
                return new SuccessResult<CountryCurrencyDto>(EntityToData(resultList), "Country and Currency");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Save(CountryCurrencyCreateDto createDto)
        {
            try
            {
                var resultList = await _countryCurrencyRepository.Add(DataToEntity(createDto));
                return new SuccessResult<CountryCurrencyDto>(EntityToData(resultList), "Currency Created.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> Update(CountryCurrencyDto updateDto)
        {
            try
            {
                var resultList = await _countryCurrencyRepository.Update(DataToEntity(updateDto));
                return new SuccessResult<CountryCurrencyDto>(EntityToData(resultList), "Currency Updated.");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> CountryCurrency(string countryIsoCode)
        {
            try
            {
                return new SuccessResult<CurrencyDto>(await Task.Run(() => _countryInfoIntegration.CountryCurrency(countryIsoCode)),
                    "Country and Currency");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> CapitalCity(string countryIsoCode)
        {
            try
            {
                return new SuccessResult<string>(await Task.Run(() => _countryInfoIntegration.CapitalCity(countryIsoCode)),
                    "Capital City");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> GetCountryList()
        {
            try
            {
                return new SuccessResult<IList<CountryCodeAndNameDto>>(await Task.Run(() => _countryInfoIntegration.ListOfCountryNamesByCode()), 
                    "List of Country");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        public async Task<IResult> CountryIsoCode(string countryName)
        {
            try
            {
                return new SuccessResult<string>(await Task.Run(() => _countryInfoIntegration.CountryISOCode(countryName)),
                    "Country ISO Code");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        private CountryCurrencyDto EntityToData(CountryCurrency currency)
        {
            if (currency == null)
                return null;

            return new CountryCurrencyDto
            {
                Id = currency.Id,
                CountryCode = currency.CountryCode,
                CountryName = currency.CountryName,
                CapitalCityName = currency.CapitalCityName,
                CurrencyName = currency.CurrencyName
            };
        }

        private CountryCurrency DataToEntity(CountryCurrencyCreateDto currency)
        {
            if (currency == null)
                return null;

            return new CountryCurrency
            {
                CountryCode = currency.CountryCode,
                CountryName = currency.CountryName,
                CapitalCityName = currency.CapitalCityName,
                CurrencyName = currency.CurrencyName,
                ActiveFlag = true
            };
        }

        private CountryCurrency DataToEntity(CountryCurrencyDto currency)
        {
            if (currency == null)
                return null;

            return new CountryCurrency
            {
                Id = currency.Id,
                CountryCode = currency.CountryCode,
                CountryName = currency.CountryName,
                CapitalCityName = currency.CapitalCityName,
                CurrencyName = currency.CurrencyName,
                ActiveFlag = true
            };
        }
    }
}
