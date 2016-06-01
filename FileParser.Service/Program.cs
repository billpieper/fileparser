using FileParser.Modules;
using Topshelf;
using Topshelf.Ninject;

namespace FileParser.Service
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var exitCode = HostFactory.Run
            (
                topshelf =>
                {
                    topshelf.UseNinject(new BusModule());

                    topshelf.Service<Startup>
                    (
                        sc =>
                        {
                            sc.ConstructUsingNinject();

                            sc.WhenStarted((service, host) => service.Start(host));
                            sc.WhenStopped((service, host) => service.Stop(host));
                            sc.WhenShutdown((service, host) => service.Stop(host));
                        }
                    );

                    topshelf.SetDisplayName("File Parser");
                    topshelf.SetServiceName("File Parser");
                    topshelf.SetDescription("File Parser");
                    
                    topshelf.EnablePauseAndContinue();
                    topshelf.EnableShutdown();

                    topshelf.StartAutomaticallyDelayed();
                    topshelf.RunAsLocalSystem();
                }
            );

            return (int)exitCode;
        }
    }
}