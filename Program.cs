using System.Text.RegularExpressions;
using WebStarterkit.CliConfig;

namespace WebStarterkit
{
    public class Package
    {
        public string name;
        public bool isDevDependency;

        public Package(string name, bool isDevDependency)
        {
            this.name = name;
            this.isDevDependency = isDevDependency;
        }
    }

    /*
    Primary configuration class for the cli
    */
    public class WebStarterkit
    {
        public static void Main(string[] args)
        {
            // Check for help flag or empty command
            if (args.Any(arg => Regex.IsMatch(arg, @"^(-h|--help)$")) || args.Length == 0)
            {
                HelperMethods.HelpPrintout();
                return;
            }

            // Text coloring values 
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
            }
            if (backend != "express" && backend != "flask" && backend != "django" && backend != "rails")
            {
                backendExists = false;
            }
            if (!frontendExists && !backendExists)
            {
                HelperMethods.HelpPrintout();
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




    }
}
