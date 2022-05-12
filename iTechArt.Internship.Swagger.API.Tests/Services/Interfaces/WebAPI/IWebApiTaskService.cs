using System.Threading.Tasks;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests.Services.Interfaces.WebAPI
{
    public interface IWebApiTaskService
    {
        public Task<IRestResponse<T>> GetAllTasksForSystem<T>(string systemId);
        public Task<IRestResponse> GetAllTasksForSystem(string systemId);
        public Task<IRestResponse<T>> PostTask<T>(object body);
        public Task<IRestResponse> PostTask(object body);
    }
}