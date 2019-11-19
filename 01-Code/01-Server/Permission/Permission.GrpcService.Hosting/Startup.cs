using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Permission.GrpcService.Hosting.Consul;
using Permission.GrpcService.Hosting.Consul.Entity;
using Permission.Service.rpc;

namespace Permission.GrpcService.Hosting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //ע��ȫ������
            services.AddOptions();
            services.Configure<Permission.Service.rpc.Entity.GrpcService>(Configuration.GetSection(nameof(Permission.Service.rpc.Entity.GrpcService)));
            services.Configure<HealthService>(Configuration.GetSection(nameof(HealthService)));
            services.Configure<ConsulService>(Configuration.GetSection(nameof(ConsulService)));

            //ע��Rpc����
            services.AddSingleton<IRpcConfig, RpcConfig>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime, IOptions<HealthService> healthService, IOptions<ConsulService> consulService, IRpcConfig rpc)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ��ӽ������·�ɵ�ַ
            app.Map("/health", HealthMap);

            // ����ע��
            app.RegisterConsul(lifetime, healthService, consulService);
            // ����Rpc����
            rpc.Start();
            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
        private static void HealthMap(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("OK");
            });
        }
    }
}
