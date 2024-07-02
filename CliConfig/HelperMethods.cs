// Installer packages:
// https://learn.microsoft.com/en-us/windows/msix/app-installer/how-to-create-appinstaller-file

using System.Diagnostics;

namespace WebStarterkit.CliConfig
{
    public class HelperMethods
    {
        // returning a string in case output is needed
        public static string RunShellCommand(string command)
        {
            Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "-c \" " + command + " \"";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            proc.WaitForExit();
            Console.WriteLine(proc.StandardOutput.ReadToEnd());
            return proc.StandardOutput.ReadToEnd();

        }

        // via https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        public static void HelpPrintout()
        {
            const string resetTextFormat = "\u001b[0m";
            const string boldGreenTextFormat = "\u001b[1;32m";
            Console.WriteLine(
                "Usage:\n" +
                "  webstarter <frontend> <backend> <appname> [options]\n\n" +
                "Parameters:\n" +
                "  <frontend>\t\t\tFrontend framework/library (e.g., react, vue, angular)\n" +
                "  <backend>\t\t\tBackend framework/language (e.g., express, django, flask)\n" +
                "  <appname>\t\t\tName of the application\n\n" +
                "Options:\n" +
                "  -p <dependencies>\t\tComma-separated list of additional dependencies\n" +
                "  \t\t\t\t(e.g., -p axios,redux)\n" +
                "  -P <devDependencies>\t\tComma-separated list of additional dev dependencies\n" +
                "  \t\t\t\t(e.g., -P eslint,prettier)\n" +
                "  -d <database>\t\t\tDatabase to use (mongodb, mysql, or sqlite)\n" +
                "  --typescript\t\t\tUse TypeScript instead of JavaScript\n" +
                "  --yarn\t\t\tUse Yarn as the package manager instead of npm\n" +
                "  -h, --help\t\t\tShow this help message and exit\n\n" +
                $"{boldGreenTextFormat}Check the full documentation, report issues, or star our repository at https://github.com/jonathannotis/web-starterkit-cli{resetTextFormat}"
            );

        }

    }
}