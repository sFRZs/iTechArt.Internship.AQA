using Newtonsoft.Json;

namespace iTechArt.Internship.Swagger.API.Tests.Utilities
{
    public class NewtonsoftSerializer
    {
        private static NewtonsoftSerializer _serializer = null;

        private NewtonsoftSerializer()
        {
        }

        public string SerializeObject(object obj)
        {
            string content = JsonConvert.SerializeObject(obj);
            return content;
        }


        public static NewtonsoftSerializer GetInstance()
        {
            if (_serializer == null)
            {
                _serializer = new NewtonsoftSerializer();
            }

            return _serializer;
        }
    }
}