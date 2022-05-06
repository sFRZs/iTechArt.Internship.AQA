using System.Collections.Generic;
using Newtonsoft.Json;

namespace iTechArt.Internship.Swagger.API.Tests.Models.ViewModels.TaskProcessor
{
    public class ErrorsVM
    {
        [JsonProperty("Authorization header")]
        public List<string> AuthorizationHeader { get; set; }
    }
}