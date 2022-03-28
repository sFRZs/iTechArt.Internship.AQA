using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Services;
using RestSharp;

namespace iTechArt.Internship.Swagger.API.Tests
{
    public class TaskProcessorApi
    {
        private readonly Helper _helper;

        public TaskProcessorApi()
        {
            _helper = new Helper();
        }

        public async Task<RestResponse> GetAllDataTypes()
        {
            var client = _helper.GetNewRestClient();
            var request = _helper.GetNewGetRequest("/task-processor/dataTypes/all");
            var response = await _helper.GetResponse(client, request);

            return response;
        }

        public async Task<RestResponse> GetAllActiveTasks()
        {
            var client = _helper.GetNewRestClient();
            var request = _helper.GetNewGetRequest("/task-processor/tasks/active");
            var response = await _helper.GetResponse(client, request);

            return response;
        }
        
        public async Task<RestResponse> GetAllActiveTasksGroup()
        {
            var client = _helper.GetNewRestClient();
            var request = _helper.GetNewGetRequest("task-processor/tasks/groups");
            var response = await _helper.GetResponse(client, request);

            return response;
        }
        
        public async Task<RestResponse> GetAllActiveIndividual()
        {
            var client = _helper.GetNewRestClient();
            var request = _helper.GetNewGetRequest("/task-processor/tasks/individual");
            var response = await _helper.GetResponse(client, request);

            return response;
        }
    }
}