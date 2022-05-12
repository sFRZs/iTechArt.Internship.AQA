using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI
{
    public interface IWebApiSystemService
    {
        public Task<IRestResponse<T>> GetAllSystems<T>();
        public Task<IRestResponse> GetAllSystems();
        public Task<IRestResponse<T>> PostSystem<T>(object body);
        public Task<IRestResponse> PostSystem(object body);
    }
}