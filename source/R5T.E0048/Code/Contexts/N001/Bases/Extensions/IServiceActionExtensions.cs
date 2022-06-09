using System;

using R5T.Lombardy;

using R5T.D0078;
using R5T.D0079;
using R5T.D0083;
using R5T.D0116;
using R5T.T0062;
using R5T.T0063;


namespace R5T.E0048.Contexts.N001
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="CodeFileContextProvider"/> implementation of <see cref="ICodeFileContextProvider"/> as a <see cref="Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<ICodeFileContextProvider> AddCodeFileContextProviderAction(this IServiceAction _,
            IServiceAction<IStringlyTypedPathOperator> stringlyTypedPathOperatorAction,
            IServiceAction<IUsingDirectivesFormatter> usingDirectivesFormatterAction,
            IServiceAction<IVisualStudioProjectFileOperator> visualStudioProjectFileOperatorAction,
            IServiceAction<IVisualStudioProjectFileReferencesProvider> visualStudioProjectFileReferencesProviderAction,
            IServiceAction<IVisualStudioSolutionFileOperator> visualStudioSolutionFileOperatorAction)
        {
            var serviceAction = _.New<ICodeFileContextProvider>(services => services.AddCodeFileContextProvider(
                stringlyTypedPathOperatorAction,
                usingDirectivesFormatterAction,
                visualStudioProjectFileOperatorAction,
                visualStudioProjectFileReferencesProviderAction,
                visualStudioSolutionFileOperatorAction));

            return serviceAction;
        }
    }
}
