using Funq;
using RideAlong.Features;
using RideAlong.Features.Events;
using ServiceStack;

[assembly: HostingStartup(typeof(RideAlong.AppHost))]

namespace RideAlong;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices((context, services) => {
            services.ConfigureNonBreakingSameSiteCookies(context.HostingEnvironment);
        });

    public AppHost() : base("RideAlong",
        typeof(Event).Assembly) {}

    public override void Configure(Container container)
    {
        SetConfig(new HostConfig {
            UseSameSiteCookies = !HostingEnvironment.IsDevelopment()
        });

        Plugins.Add(new SpaFeature {
            EnableSpaFallback = true
        });
        Plugins.Add(new CorsFeature(allowOriginWhitelist:new[]{ 
            "http://localhost:5000",
            "http://localhost:3000",
            "https://localhost:5001",
            "https://" + Environment.GetEnvironmentVariable("DEPLOY_CDN")
        }, allowCredentials:true));

        ConfigurePlugin<UiFeature>(feature => {
            feature.Info.BrandIcon.Uri = "/assets/img/logo.svg";
            feature.Info.BrandIcon.Cls = "inline-block w-8 h-8 mr-2";
        });
    }
}
