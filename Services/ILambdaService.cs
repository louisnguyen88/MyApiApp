using System.Threading.Tasks;

namespace MyApiApp.Services
{
    public interface ILambdaService
    {
        Task<string> InvokeLambdaAsync(string payload);
    }
}
