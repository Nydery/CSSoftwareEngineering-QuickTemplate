namespace TemplateCopier.ConApp
{
    internal static class StaticLiterals
    {
        public static string SolutionFileExtension => ".sln";
        public static string ProjectFileExtension => ".csproj";
        public static string[] SolutionProjects => new string[]
        {

        };
        public static string[] ProjectExtensions => new string[]
        {
            ".ConApp",
            ".Model",
            ".Logic",
        };

        public static string GeneratedCodeLabel => "@GeneratedCode";
        public static string IgnoreLabel => "@Ignore";
        public static string BaseCodeLabel => "@BaseCode";
        public static string CodeCopyLabel => "@CodeCopy";
    }
}
