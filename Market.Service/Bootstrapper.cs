using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using Market.Logging;

namespace Market.Service
{
    internal class Bootstrapper
    {
        private const string ServiceName = "Market";
        private const string ServiceDisplayName = "Market Service";
        private const string ServiceDescription = "Provides market data and rule execution services";

        private const string ApiName = "Market Service API";
        private const string ApiVersion = "v1";
        private const string ApiXmlDocumentPath = "Market.Service.xml";

        private const string InternalUrl = "http://localhost:8080";

        private readonly string _wwwRootParentPath;
        private readonly bool _isDebuggerAttached;
        private readonly IWebHost _webHost;

        public Bootstrapper()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            if (Debugger.IsAttached || Environment.UserInteractive)
            {
                _isDebuggerAttached = true;
                _wwwRootParentPath = $@"{Directory.GetCurrentDirectory()}\..\..\..\";
            }
            else
            {
                _isDebuggerAttached = false;
                _wwwRootParentPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            }

            var bindUrl = GetHttpSysBindUrl(InternalUrl);
            AddUrlAcl(bindUrl);

            _webHost = new WebHostBuilder()
               .ConfigureServices(sc => BuildContainer(sc))
               .UseHttpSys(options =>
               {
                   options.UrlPrefixes.Add(bindUrl);
               })
               .UseContentRoot(_wwwRootParentPath)
               .UseStartup<ApiStartup>()
               .Build();
        }

        private void BuildContainer(IServiceCollection sc)
        {
            sc.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.Formatting = Formatting.Indented;
            });

            sc.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ApiVersion, new Info { Title = ApiName, Version = ApiVersion });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, ApiXmlDocumentPath);
                c.IncludeXmlComments(xmlPath);
            });

            //Build DI graph
        }

        internal void StartService()
        {
            if (_isDebuggerAttached)
            {
                _webHost.Run();
            }
            else
            {
                _webHost.RunAsService();
            }
        }

        private string GetHttpSysBindUrl(string source)
        {
            var uriReader = new Uri(source);
            var scheme = uriReader.Scheme;
            var port = uriReader.Port;
            var url = $"{scheme}://+:{port}/";
            return url;
        }

        private void AddUrlAcl(string httpSysBindUrl)
        {
            var arguments = $"http add urlacl url=\"{httpSysBindUrl}\" user=\"{WindowsIdentity.GetCurrent().Name}\"";

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    Verb = "runas",
                    Arguments = arguments,
                    FileName = "netsh"
                }
            };

            Log.Write($"Ensuring URL ACL - netsh {arguments}");
            process.Start();
            process.WaitForExit();
        }

        private class ApiStartup
        {
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.UseDefaultFiles();
                app.UseStaticFiles();
                app.UseMvc();

                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "api/doc/{documentName}/swagger";
                });

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "api/doc";
                    c.SwaggerEndpoint("v1/swagger", ServiceDisplayName);
                });
            }
        }
    }
}