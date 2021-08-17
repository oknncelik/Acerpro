using Acerpro.Entities.Concreate.Dtos.ServiceDtos;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Acerpro.Wcf
{
    [ServiceContract]
    public interface IApplicationService
    {

        [OperationContract]
        Task<ServiceResult<IList<CountryCodeAndNameDto>>> GetCountryListAsync();
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
