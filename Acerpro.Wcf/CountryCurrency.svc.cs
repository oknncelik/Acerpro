using Acerpro.Business.Abstruct;
using Acerpro.Business.Concreate;
using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using Acerpro.Shared.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acerpro.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ApplicationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ApplicationService.svc or ApplicationService.svc.cs at the Solution Explorer and start debugging.
    public class CountryCurrency : ICountryCurrency
    {
        private readonly ICountryCurrencyService _countryCurrencyService;

        public CountryCurrency()
        {
            _countryCurrencyService = new Business.Concreate.CountryCurrencyService();
        }

        public async Task<ServiceResult<IList<CountryCurrencyDto>>> GetAsync()
        {
            var result = await _countryCurrencyService.Get();
            return new ServiceResult<IList<CountryCurrencyDto>>
            {
                Code = result.Code,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                ResultType = result.ResultType,
                Result = (result as SuccessResult<IList<CountryCurrencyDto>>)?.Result
            };
        }

        public async Task<ServiceResult<CountryCurrencyDto>> GetByIdAsync(int id)
        {
            var result = await _countryCurrencyService.GetById(id);
            return new ServiceResult<CountryCurrencyDto>
            {
                Code = result.Code,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                ResultType = result.ResultType,
                Result = (result as SuccessResult<CountryCurrencyDto>)?.Result
            };
        }

        public async Task<ServiceResult<CountryCurrencyDto>> SaveAsync(CountryCurrencyCreateDto createDto)
        {
            var result = await _countryCurrencyService.Save(createDto);
            return new ServiceResult<CountryCurrencyDto>
            {
                Code = result.Code,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                ResultType = result.ResultType,
                Result = (result as SuccessResult<CountryCurrencyDto>)?.Result
            };
        }

        public async Task<ServiceResult<CountryCurrencyDto>> UpdateAsync(CountryCurrencyDto updateDto)
        {
            var result = await _countryCurrencyService.Update(updateDto);
            return new ServiceResult<CountryCurrencyDto>
            {
                Code = result.Code,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                ResultType = result.ResultType,
                Result = (result as SuccessResult<CountryCurrencyDto>)?.Result
            };
        }

        public async Task<ServiceResult<IList<CountryCodeAndNameDto>>> GetCountryListAsync()
        {
            var result = await _countryCurrencyService.GetCountryList();
            return new ServiceResult<IList<CountryCodeAndNameDto>>
            {
                Code = result.Code,
                Message = result.Message,
                IsSuccess = result.IsSuccess,
                ResultType = result.ResultType,
                Result = (result as SuccessResult<IList<CountryCodeAndNameDto>>)?.Result
            };
        }
    }
}
