using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.TaskProcessor
{
    public interface IDataTypesService
    {
        public Task<IRestResponse> GetAllDataTypes();
        public Task<IRestResponse<T>> GetAllDataTypes<T>();
        string AuthToken { get; set; }
    }
}