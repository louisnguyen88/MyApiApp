using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class SecretManagerService
{
    private readonly IAmazonSecretsManager _secretsManager;

    public SecretManagerService(IAmazonSecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }

    public async Task<JObject> GetSecretAsync(string secretName)
    {
        var request = new GetSecretValueRequest { SecretId = secretName };
        var response = await _secretsManager.GetSecretValueAsync(request);

        return JObject.Parse(response.SecretString);
    }
}
