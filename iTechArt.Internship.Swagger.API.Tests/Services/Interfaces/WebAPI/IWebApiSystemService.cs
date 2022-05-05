using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI
{
    public interface IWebApiSystemService
    {
        public Task<IRestResponse<T>> GetAllSystems<T>();
        public Task<IRestResponse<T>> PostSystem<T>(object body);
    }
}