namespace iTechArt.Internship.Swagger.API.Tests.Models.ViewModels
{
    public class ErrorModelVM
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ErrorsVM Errors { get; set; }
    }
}