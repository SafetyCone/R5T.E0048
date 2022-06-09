using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.D0088;
using R5T.D0090;


namespace R5T.E0048
{
    class Program : ProgramAsAServiceBase
    {
        #region Static
        
        static async Task Main()
        {
            //OverridableProcessStartTimeProvider.Override("20211214 - 163052");
            //OverridableProcessStartTimeProvider.DoNotOverride();
        
            await Instances.Host.NewBuilder()
                .UseProgramAsAService<Program, T0075.IHostBuilder>()
                .UseHostStartup<HostStartup, T0075.IHostBuilder>(Instances.ServiceAction.AddHostStartupAction())
                .Build()
                .SerializeConfigurationAudit()
                .SerializeServiceCollectionAudit()
                .RunAsync();
        }

        #endregion

        
        public Program(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override Task ServiceMain(CancellationToken stoppingToken)
        {
            //return this.RunOperation();
            return this.RunMethod();
        }

#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CA1822 // Mark members as static

        private Task RunOperation()
        {
            return Task.CompletedTask;
        }

        private async Task RunMethod()
        {
            await this.CreateServiceDefinitionInterface();
        }

        private async Task CreateServiceDefinitionInterface()
        {
            var compilationRequirements = Instances.CompilationUnitGenerator.CreateServiceDefinitionInterface();

            var codeFileContextProvider = this.ServiceProvider.GetRequiredService<Contexts.N001.ICodeFileContextProvider>();

            var codeFileContext = await codeFileContextProvider.GetCodeFileContext(
                @"C:\Temp\Code.cs");

            await codeFileContext.WriteCompilation(compilationRequirements);
        }
    }
}