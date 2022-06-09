using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0063;


namespace R5T.E0048.Contexts.N001
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CodeFileContextProvider"/> implementation of <see cref="ICodeFileContextProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddCodeFileContextProvider(this IServiceCollection services,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            services
                .Run(stringlyTypedPathOperatorAction)
                .Run(usingDirectivesFormatterAction)
                .Run(visualStudioProjectFileOperatorAction)
                .Run(visualStudioProjectFileReferencesProviderAction)
                .Run(visualStudioSolutionFileOperatorAction)
                .AddSingleton<ICodeFileContextProvider, CodeFileContextProvider>();

            return services;
        }
    }
}
