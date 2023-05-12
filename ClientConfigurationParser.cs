using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Client.Utilities;
using Microsoft.Extensions.Options;

namespace GrpcClientCertificate
{
    public class ClientConfigurationParser
    {
        private const string CertificateFolderName = "Certs";
        private const string DefaultConfigFileName = "client_config.json";
        public ClientOptions Options { get; private set; }
        public ClientConfigurationParser(string configFilePath)
        {
            if (string.IsNullOrEmpty(configFilePath))
                configFilePath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))), DefaultConfigFileName);
            if (File.Exists(configFilePath))
            {
                var input = new StreamReader(configFilePath);
                var serialzerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Options = JsonSerializer.Deserialize<ClientOptions>(input.ReadToEnd(), serialzerOptions);
                string certificateFolder = Path.Combine(Path.GetDirectoryName(configFilePath), CertificateFolderName);
                Options.SetCertificatePaths(certificateFolder);
            }
            else { Options = new ClientOptions(); }
        }
    }
}
