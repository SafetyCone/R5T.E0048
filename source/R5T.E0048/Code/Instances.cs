using System;

using R5T.T0062;
using R5T.T0070;


namespace R5T.E0048
{
    public static class Instances
    {
        public static S0036.F001.ICompilationUnitGenerator CompilationUnitGenerator { get; } = S0036.F001.CompilationUnitGenerator.Instance;
        public static IHost Host { get; } = T0070.Host.Instance;
        public static B0002.INamespaceName NamespaceName { get; } = B0002.NamespaceName.Instance;
        public static IProjectReferencesOperator ProjectReferencesOperator { get; } = E0048.ProjectReferencesOperator.Instance;
        public static IServiceAction ServiceAction { get; } = T0062.ServiceAction.Instance;
    }
}