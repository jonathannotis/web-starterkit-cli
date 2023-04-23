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

            string frontend = args[0];
            string backend = args[1];
            string directoryName = args[2];

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm

            Tuple<List<Package>, string> flags = GetFlags(args);

            string database = flags.Item2; // sqlite/mongodb/mysql
            List<Package> packages = flags.Item1;

            // create project directories
            System.IO.Directory.CreateDirectory(directoryName);
            System.IO.Directory.CreateDirectory(directoryName + "/frontend");
            System.IO.Directory.CreateDirectory(directoryName + "/backend");

            // Handle frontend input
            switch (frontend)
            {
                case "react":
                    FrontendConfig.CreateReactApp(packages, false, directoryName, typescript, yarn);
                    break;
                case "next":
                    FrontendConfig.CreateReactApp(packages, true, directoryName, typescript, yarn);
                    break;
                case "svelte":
                    FrontendConfig.CreateSvelteApp(packages, directoryName, typescript, yarn);
                    break;
                case "vue":
                    FrontendConfig.CreateVueApp(packages, directoryName, typescript, yarn);
                    break;
                case "angular":
                    FrontendConfig.CreateAngularApp(packages, directoryName, yarn);
                    break;
                case "flutter":
                    FrontendConfig.CreateFlutterApp(packages, directoryName);
                    break;
                default:
                    HelperMethods.RunShellCommand("echo -e \"\033[31;47mYou entered an unsupported frontend frameowork. The program will continue configuration.\033[0m\"");
                    break;
            }

            // Handle backend input
            switch (backend)
            {
                case "express":
                    BackendConfig.CreateExpress(directoryName, yarn, database);
                    break;
                case "flask":
                    BackendConfig.CreateFlask(directoryName, database);
                    break;
                case "django":
                    BackendConfig.CreateDjango(directoryName, database);
                    break;
                case "rails":
                    BackendConfig.CreateRails(directoryName, database);
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
