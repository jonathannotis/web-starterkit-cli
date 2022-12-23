
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

    public class WebStarterkit
    {
        public static void Main(string[] args)
        {

            // <command name> <frontend> <backend> <appname> -packages <packages> --typescript --yarn
            // dotnet run react flask myapp -packages react-redux react-router-dom --typescript

            string frontend = args[0];
            string backend = args[1];
            string directoryName = args[2];

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm




            List<Package>? packages = args[3].Equals("-packages") ? GetPackages(args) : null;

            // create project directories
            System.IO.Directory.CreateDirectory(directoryName);
            System.IO.Directory.CreateDirectory(directoryName + "/frontend");
            System.IO.Directory.CreateDirectory(directoryName + "/backend");


            switch (frontend)
            {
                case "react":
                    FrontendConfig.CreateReactApp(packages, false, directoryName, typescript, yarn);
                    break;
                case "next":
                    FrontendConfig.CreateReactApp(packages, true, directoryName, typescript, yarn);
                    break;
                case "sveltekit":
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

            }


            // Regex for dash then letter is -[a-zA-z]

        }

        private static List<Package> GetPackages(string[] args)
        {
            List<Package> packages = new List<Package>();
            bool devDependency = false;
            for (int i = 4; i < args.Length; i++)
            {
                if (args[i].Contains("--"))
                {
                    break;
                }
                else if (args[i].Equals("-D"))
                {
                    devDependency = true;
                    continue;
                }
                packages.Add(new Package(args[i], devDependency));
                devDependency = false;
            }

            return packages;
        }
    }
}
