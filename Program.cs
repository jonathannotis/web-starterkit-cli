
namespace WebStarterkit
{
    public class WebStarterkit
    {
        public static void Main(string[] args)
        {

            // <command name> <frontend> <backend> <appname> -pkg <packages> --typescript --yarn
            // dotnet run react flask myapp -pkg react-redux react-router-dom --typescript

            string frontend = args[0];
            string backend = args[1];
            string directoryName = args[2];

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm


            List<string>? packages = args[3].Equals("-pkg") ? GetPackages(args) : null;


            // create project directories
            System.IO.Directory.CreateDirectory(directoryName);
            System.IO.Directory.CreateDirectory(directoryName + "/frontend");
            System.IO.Directory.CreateDirectory(directoryName + "/backend");

            // this is temporary. replace with a switch statements for frontend/backend
            ReactDeploy reactDeploy = new ReactDeploy(packages, frontend.Equals("next"), directoryName, typescript, yarn);
            reactDeploy.CreateApp();

            // Regex for dash then letter is -[a-zA-z]

        }

        private static List<string> GetPackages(string[] args)
        {
            List<string> packages = new List<string>();
            for (int i = 4; i < args.Length; i++)
            {
                if (args[i].Contains("--"))
                {
                    break;
                }
                packages.Add(args[i]);
            }

            return packages;
        }
    }
}
