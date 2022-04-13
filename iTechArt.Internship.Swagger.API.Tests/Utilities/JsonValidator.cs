using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public static class JsonValidator
    {
        public static bool IsValid(string responseContent, string fileName, out IList<string> errorMessages)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path =
                $"{basePath}{Path.DirectorySeparatorChar}TestData{Path.DirectorySeparatorChar}Schemas{Path.DirectorySeparatorChar}{fileName}";

            var jObject = JToken.Parse(responseContent);

            using (TextReader reader = File.OpenText(path))
            {
                var schema = JSchema.Load(new JsonTextReader(reader), new JSchemaReaderSettings
                {
                    Resolver = new JSchemaUrlResolver(),
                    BaseUri = new Uri(path)
                });

                return jObject.IsValid(schema, out errorMessages);
            }
        }
    }
}