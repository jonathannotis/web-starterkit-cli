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
            string? homebrewCellarPath = Environment.GetEnvironmentVariable("HOMEBREW_CELLAR");
            string? baseDirectory = Path.Combine(homebrewCellarPath, "webstart", "1.0.1");

            string frontend = args[0];
            string backend = args[1];
            string directory = args[2];

            string assetsPath = Path.Combine(baseDirectory, "bin", "assets");

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm

            Tuple<List<Package>, string> flags = GetFlags(args);

            string database = flags.Item2; // sqlite/mongodb/mysql
            List<Package> packages = flags.Item1;

            // create project directories
            System.IO.Directory.CreateDirectory(directory);
            System.IO.Directory.CreateDirectory(directory + "/frontend");
            System.IO.Directory.CreateDirectory(directory + "/backend");

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
                    HelperMethods.RunShellCommand("echo -e \"\033[31;47mYou entered an unsupported frontend frameowork. The program will continue configuration.\033[0m\"");
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
                    HelperMethods.RunShellCommand("echo -e \"\033[31;47mYou entered an unsupported backend frameowork.\033[0m\"");
                    break;
            }
            HelperMethods.RunShellCommand("echo -e \"\033[31;47mThank you. Your project is fully configured. If you have any issues please report them on Github at https://github.com/jonathannotis/web-starterkit-cli\033[0m\"");
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
