using iTechArt.Internship.Swagger.API.Tests.Modules;
using iTechArt.Internship.Swagger.API.Tests.Services;
using iTechArt.Internship.Swagger.API.Tests.Utilities;
using NUnit.Framework;

namespace iTechArt.Internship.Swagger.API.Tests.Tests
{
    public class TaskTests
    {
        private TasksService _tasksService;

        [SetUp]
        public void SetUp()
        {
            _tasksService = new TasksService();
        }

        [Test]
        public void StatusCodeOfGetAllActiveTasksIs200()
        {
            var response = _tasksService.GetAllActiveTasks<ActiveTask>();
            Assert.AreEqual(200, (int) response.Result.StatusCode);
        }

        [Test]
        public void StatusCodeOfGetAllActiveTasksGroupIs200()
        {
            var response = _tasksService.GetAllActiveTasksGroup<ActiveTasksGroup>();
            Assert.AreEqual(200, (int) response.Result.StatusCode);
        }

        [Test]
        public void StatusCodeOfGetAllActiveIndividualIs200()
        {
            var response = _tasksService.GetAllActiveIndividual<ActiveIndividual>();
            Assert.AreEqual(200, (int) response.Result.StatusCode);
        }
    }
}