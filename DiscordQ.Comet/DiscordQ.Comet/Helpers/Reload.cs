#nullable enable
//-:cnd
#if DEBUG

using Esp.Resources;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.HotReload;
using System.Threading.Tasks;

namespace Comet
{
    public static partial class Reload
    {
        public static MauiAppBuilder EnableHotReload(this MauiAppBuilder builder, string? ideIp = null, int idePort = Constants.DEFAULT_PORT)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Transient<IMauiInitializeService, HotReloadBuilder>(_ => new HotReloadBuilder
            {
                IdeIp = ideIp,
                IdePort = idePort,
            }));
            return builder;
        }

        private class HotReloadBuilder : IMauiInitializeService
        {
            public string? IdeIp { get; set; }

            public int IdePort { get; set; } = 9988;

            public async void Initialize(IServiceProvider services)
            {
                var handlers = services.GetRequiredService<IMauiHandlersFactory>();

                Reloadify.Reload.Instance.ReplaceType = (d) =>
                {
                    MauiHotReloadHelper.RegisterReplacedView(d.ClassName, d.Type);
                };

                Reloadify.Reload.Instance.FinishedReload = () =>
                {
                    MauiHotReloadHelper.TriggerReload();
                };

                await Task.Run(async () =>
                {
                    try
                    {
                        var success = await Reloadify.Reload.Init(IdeIp, IdePort);

                        Console.WriteLine($"HotReload Initialize: {success}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                });
            }
        }
    }
}

#endif
//+:cnd