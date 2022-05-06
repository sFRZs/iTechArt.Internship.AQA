using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor
{
    public interface IDataTypeService
    {
        public Task<IRestResponse> GetAllDataTypes();
        public Task<IRestResponse<T>> GetAllDataTypes<T>();
    }
}