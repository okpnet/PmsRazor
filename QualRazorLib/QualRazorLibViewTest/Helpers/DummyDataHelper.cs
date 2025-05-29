using QualRazorLibViewTest.Dtos;
using System.IO;
using System.Text.Json;

namespace QualRazorLibViewTest.Helpers
{
    public static class DummyDataHelper
    {
        public static TestCustomer[] GetTestCustomers()
        {
            var path = PathHelper.CreateExcecutePathToFile("test_customers.json");
            ArgumentNullException.ThrowIfNullOrEmpty(path);
            return CreateFromJson<TestCustomer[]>(path);
        }

        public static T CreateFromJson<T>(string filePath)
        {
            var options = JsonSerialzerOptionHelper.CreateOption();
            using var stream=new StreamReader(filePath,System.Text.Encoding.UTF8);
            var buffer=stream.ReadToEnd();
            stream.Close();
            var deserialize=JsonSerializer.Deserialize<T>(buffer,options);
            ArgumentNullException.ThrowIfNull(deserialize);
            return deserialize;
        } 


    }
}
