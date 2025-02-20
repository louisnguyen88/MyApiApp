using System;
using System.Text;
using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Microsoft.Extensions.Configuration;

namespace MyApiApp.Services
{
    public class LambdaService : ILambdaService
    {
        private readonly IAmazonLambda _lambdaClient;
        private readonly string _lambdaFunctionName;

        public LambdaService(IAmazonLambda lambdaClient, IConfiguration config)
        {
            _lambdaClient = lambdaClient;
            _lambdaFunctionName = config["Lambda:FunctionName"];
        }

        public async Task<string> InvokeLambdaAsync(string payload)
        {
            var request = new InvokeRequest
            {
                FunctionName = _lambdaFunctionName,
                Payload = payload
            };

            var response = await _lambdaClient.InvokeAsync(request);
            return Encoding.UTF8.GetString(response.Payload.ToArray());
        }
    }
}
