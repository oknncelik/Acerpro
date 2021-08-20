using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using Acerpro.Integrations.Abstruct;
using Acerpro.Integrations.CountryInfoService;
using System.Collections.Generic;
using System.Linq;

namespace Acerpro.Integrations.Concreate
{
    //CountryInfoService entegre olunur.
    public class CountryInfoIntegration : ICountryInfoIntegration
    {
        private CountryInfoService.CountryInfoService _service; 
        public CountryInfoIntegration()
        {
            _service = new CountryInfoService.CountryInfoService();
        }
        public IList<CountryCodeAndNameDto> ListOfCountryNamesByCode()
        {
            try
            {
                var serviceResult = _service.ListOfCountryNamesByCode();
                // Log...
                return serviceResult.Select(ToModel).ToList();
            }
            catch 
            {
                // Log...
                return null;
            }         
        }

        public string CountryISOCode(string countryName)
        {
            try
            {
                var serviceResult = _service.CountryISOCode(countryName);
                // Log...
                return serviceResult;
            }
            catch
            {
                // Log...
                return null;
            }
        }

        public string CapitalCity(string countryISOCode)
        {
            try
            {
                var serviceResult = _service.CapitalCity(countryISOCode);
                // Log...
                return serviceResult;
            }
            catch
            {
                // Log...
                return null;
            }
        }
      
        public CurrencyDto CountryCurrency(string countryISOCode)
        {
            try
            {
                var serviceResult = _service.CountryCurrency(countryISOCode);
                // Log...
                return ToModel(serviceResult);
            }
            catch
            {
                // Log...
                return null;
            }
        }

        private CountryCodeAndNameDto ToModel(tCountryCodeAndName value)
        {
            if (value == null)
                return null;

            return new CountryCodeAndNameDto
            {
                ISOCode = value.sISOCode,
                Name = value.sName
            };
        }

        private CurrencyDto ToModel(tCurrency value)
        {
            if (value == null)
                return null;

            return new CurrencyDto
            {
                ISOCode = value.sISOCode,
                Name = value.sName
            };
        }
    }
}
