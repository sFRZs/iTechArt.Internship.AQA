using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces
{
    public interface IDataTypeService
    {
        public Task<IRestResponse> GetAllDataTypes();
        public Task<IRestResponse<T>> GetAllDataTypes<T>();
    }
}