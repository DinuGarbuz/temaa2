using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Globalization;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;
        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            DateTime input;
            var auxx = request.Date;
            Console.WriteLine(auxx);
            bool isValid = DateTime.TryParseExact(
           auxx,
           "MM/dd/yyyy",
           CultureInfo.InvariantCulture,
           DateTimeStyles.None,
           out input);

            string[] lines = System.IO.File.ReadAllLines("zodie.txt");


            DateTime input1;

            for (int i = 0; i < lines.Length; i++)
            {
                bool isValid1 = DateTime.TryParseExact(
                     lines[i],
                     "MM/dd/yyyy",
                         CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                      out input1);
                

                if (input.DayOfYear <= input1.DayOfYear)
                {
                    Console.WriteLine("Zodia: " + lines[i + 1]);
                    break;
                }

            }
            return Task.FromResult(new CustomerModel { });

        }
    }
}
