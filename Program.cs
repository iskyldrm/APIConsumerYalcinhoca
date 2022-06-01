using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;

namespace APIConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("https://localhost:44304/weatherforecast/1");

            httpWebRequest.Method = "GET";
            String test = String.Empty;

            using (HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                test = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var CustomerList = JsonSerializer.Deserialize<List<Customer>>(test, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            foreach (Customer c in CustomerList)
            {
                Console.WriteLine(c.CustomerId);
            }
        }
    }
}
