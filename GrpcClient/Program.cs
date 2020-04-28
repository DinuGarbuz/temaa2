using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {           
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new Customer.CustomerClient(channel);
            Console.WriteLine("Date: ");
            DateTime input;//= Console.ReadLine();
            // DateTime dt;
            
            var auxx = Console.ReadLine();           
            Console.WriteLine(auxx);
            bool isValid = DateTime.TryParseExact(
           auxx,
           "MM/dd/yyyy",
           CultureInfo.InvariantCulture,
           DateTimeStyles.None,
           out input);
        
            if (isValid)
            {
                var clientRequested = new CustomerLookupModel { Date = auxx };
                var customer = await customerClient.GetCustomerInfoAsync(clientRequested);
            }
            else
            {
                Console.WriteLine("gresit");
            }    

        
        }
    }
}
