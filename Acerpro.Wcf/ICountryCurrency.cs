using Acerpro.Entities.Concreate.Dtos;
using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Acerpro.Wcf
{
    [ServiceContract]
    public interface ICountryCurrency
    {
        [OperationContract]
        Task<ServiceResult<IList<CountryCurrencyDto>>> GetAsync();

        [OperationContract]
        Task<ServiceResult<CountryCurrencyDto>> GetByIdAsync(int id);

        [OperationContract]
        Task<ServiceResult<CountryCurrencyDto>> SaveAsync(CountryCurrencyCreateDto createDto);

        [OperationContract]
        Task<ServiceResult<CountryCurrencyDto>> UpdateAsync(CountryCurrencyDto updateDto);

        [OperationContract]
        Task<ServiceResult<IList<CountryCodeAndNameDto>>> GetCountryListAsync();

        [OperationContract]
        Task<ServiceResult<CurrencyDto>> CountryCurrencyAsync(string countryIsoCode);

        [OperationContract]
        Task<ServiceResult<string>> CapitalCityAsync(string countryIsoCode);

        [OperationContract]
        Task<ServiceResult<string>> CountryIsoCodeAsync(string countryName);

        [OperationContract]
        Task<ServiceResult<IList<CountryCurrencyDto>>> GetCountryCurrencyListAsync(string isoCode);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ServiceResult<T>
    {
        string _resultType;
        int _code;
        bool _isSuccess;
        string _message;

        T _result; 


        [DataMember]
        public string ResultType
        {
            get { return _resultType; }
            set { _resultType = value; }
        }

        [DataMember]
        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

        [DataMember]
        public bool IsSuccess
        {
            get { return _isSuccess; }
            set { _isSuccess = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        [DataMember]
        public T Result
        {
            get { return _result; }
            set { _result = value; }
        }
    }
}
