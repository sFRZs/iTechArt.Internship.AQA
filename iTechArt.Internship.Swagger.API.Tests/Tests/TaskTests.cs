using System.Threading.Tasks;
using iTechArt.Internship.Swagger.API.Tests.Models.ViewModels;
using iTechArt.Internship.Swagger.API.Tests.Services;
using Xunit;


namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class TaskTests
    {
        private TasksService _tasksService;

        public TaskTests()
        {
            _tasksService = new TasksService();
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveTasksIs200()
        {
            var response = await _tasksService.GetAllActiveTasks<ActiveTaskVM>();
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveTasksGroupIs200()
        {
            var response = await _tasksService.GetAllActiveTasksGroup<ActiveTasksGroupVM>();
            Assert.Equal(200, (int) response.StatusCode);
        }

        [Fact]
        public async Task StatusCodeOfGetAllActiveIndividualIs200()
        {
            var response = await _tasksService.GetAllActiveIndividual<ActiveIndividualVM>();
            Assert.Equal(200, (int) response.StatusCode);
        }
    }
}