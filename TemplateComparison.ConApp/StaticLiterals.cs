namespace TemplateComparison.ConApp
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
        public static string[] SolutionToolProjects { get; } = new[]
        {
            "TemplateComparsion.ConApp",
            "TemplateCopier.ConApp",
        };

        public static string GeneratedCodeLabel => "@GeneratedCode";
        public static string IgnoreLabel => "@Ignore";
        public static string BaseCodeLabel => "@BaseCode";
        public static string CodeCopyLabel => "@CodeCopy";
        public static string SourceFileExtensions => "*.css|*.cs|*.ts|*.cshtml|*.razor|*.razor.cs|*.template";
    }
}
