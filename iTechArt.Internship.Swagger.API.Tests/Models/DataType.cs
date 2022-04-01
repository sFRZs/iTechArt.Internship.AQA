using System;

namespace iTechArt.Internship.Swagger.API.Tests.Modules
{
    public class DataType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
    }
}