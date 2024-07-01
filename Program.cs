using System.Text.RegularExpressions;
using WebStarterkit.CliConfig;

namespace WebStarterkit
{
    public class Package
    {
        public string name;
        public bool devDependency;

        public Package(string name, bool devDependency)
        {
            this.name = name;
            this.devDependency = devDependency;
        }
    }

    /*
    Primary configuration class for the cli
    */
    public class WebStarterkit
    {
        public static void Main(string[] args)
        {
            if (args.Any(arg => Regex.IsMatch(arg, @"^(-h|--help)$")) || args.Length == 0)
            {
                HelpPrintout();
                return;
            }

            const string resetTextFormat = "\u001b[0m";
            const string boldRedTextFormat = "\u001b[1;31m";
            const string boldGreenTextFormat = "\u001b[1;32m";

            bool frontendExists = true;
            bool backendExists = true;

            string frontend = args[0];
            string backend = args[1];
            string directory = args[2];

            if (frontend != "react" && frontend != "next" && frontend != "svelte" && frontend != "vue" && frontend != "angular" && frontend != "flutter")
            {
                frontendExists = false;
                backend = args[0];
            }
            if (backend != "express" && backend != "flask" && backend != "django" && backend != "rails")
            {
                backendExists = false;
            }
            if (!frontendExists && !backendExists)
            {
                HelpPrintout();
                Console.WriteLine($"{boldRedTextFormat}\nYou did not enter any supported frameworks. Please try again according to the format listed.{resetTextFormat}");
                return;
            }

            string homebrewCellarPath = "/usr/local/Cellar/";

            string baseDirectory = Path.Combine(homebrewCellarPath, "webstarter", "1.0.1");

            string assetsPath = Path.Combine(baseDirectory, "bin", "assets");

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm

            Tuple<List<Package>, string> flags = GetFlags(args);

            string database = flags.Item2; // sqlite/mongodb/mysql
            List<Package> packages = flags.Item1;

            // create project directories
            System.IO.Directory.CreateDirectory(directory);
            if (frontendExists)
            {
                System.IO.Directory.CreateDirectory(directory + "/frontend");
            }
            if (backendExists)
            {
                System.IO.Directory.CreateDirectory(directory + "/backend");
            }

            // Handle frontend input
            switch (frontend)
            {
                case "react":
                    FrontendConfig.CreateReactApp(packages, false, directory, assetsPath, typescript, yarn);
                    break;
                case "next":
                    FrontendConfig.CreateReactApp(packages, true, directory, assetsPath, typescript, yarn);
                    break;
                case "svelte":
                    FrontendConfig.CreateSvelteApp(packages, directory, assetsPath, typescript, yarn);
                    break;
                case "vue":
                    FrontendConfig.CreateVueApp(packages, directory, assetsPath, typescript, yarn);
                    break;
                case "angular":
                    FrontendConfig.CreateAngularApp(packages, directory, assetsPath, yarn);
                    break;
                case "flutter":
                    FrontendConfig.CreateFlutterApp(packages, directory, assetsPath);
                    break;
                default:
                    Console.WriteLine($"{boldRedTextFormat}You entered an unsupported frontend framework. The program will continue configuration.{resetTextFormat}");
                    break;
            }

            // Handle backend input
            switch (backend)
            {
                case "express":
                    BackendConfig.CreateExpress(directory, assetsPath, yarn, database);
                    break;
                case "flask":
                    BackendConfig.CreateFlask(directory, assetsPath, database);
                    break;
                case "django":
                    BackendConfig.CreateDjango(directory, assetsPath, database);
                    break;
                case "rails":
                    BackendConfig.CreateRails(directory, assetsPath, database);
                    break;
                default:
                    Console.WriteLine($"{boldRedTextFormat}You entered an unsupported backend framework.{resetTextFormat}");
                    break;
            }
            Console.WriteLine($"{boldGreenTextFormat}Your project is fully configured!\nCheck the full documentation, report issues, or star our repository at https://github.com/jonathannotis/web-starterkit-cli{resetTextFormat}");
        }

        // Retrieves and organizes args that do not have a fixed index in the command 
        private static Tuple<List<Package>, string> GetFlags(string[] args)
        {

            List<Package> packages = new List<Package>();
            string database = "";
            bool atDependencies = false;
            bool atDevDependencies = false;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Contains("--"))
                {
                    atDependencies = false;
                    atDevDependencies = false;
                    continue;
                }
                else if (Regex.Match(args[i], @"^-d$", RegexOptions.None).Success)
                {
                    atDependencies = false;
                    atDevDependencies = false;
                    i++;
                    database = args[i];
                    continue;
                }
                else if (Regex.Match(args[i], @"^-p$", RegexOptions.None).Success)
                {
                    atDependencies = true;
                    atDevDependencies = false;
                    continue;
                }
                else if (Regex.Match(args[i], @"^-P$", RegexOptions.None).Success)
                {
                    atDevDependencies = true;
                    atDependencies = false;
                    continue;
                }
                else if (atDependencies || atDevDependencies)
                {
                    packages.Add(new Package(args[i], atDevDependencies));
                }

            }

            return new Tuple<List<Package>, string>(packages, database);
        }

        private static void HelpPrintout()
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
