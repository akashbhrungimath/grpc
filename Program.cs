using GrpcClientCertificateServer.Services;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
/*public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Program>();
        webBuilder.ConfigureKestrel(o =>
        {
            o.ConfigureHttpsDefaults(o =>
            {
                o.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
                o.ServerCertificate = < MyCertificateWithPrivateKey >;
            });
        });
    });*/
builder.Services.AddGrpc();
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = CertificateAuthenticationDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = CertificateAuthenticationDefaults.AuthenticationScheme;
}).AddCertificate();
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.ConfigureHttpsDefaults(options =>
    {
        options.ClientCertificateMode = ClientCertificateMode.RequireCertificate;
    });
});
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.MapGrpcService<StudentService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
