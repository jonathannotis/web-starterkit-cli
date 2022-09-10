
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


            switch (frontend)
            {
                case "react":
                    ReactDeploy reactDeploy = new ReactDeploy(packages, false, directoryName, typescript, yarn);
                    reactDeploy.CreateApp();
                    break;
                case "next":
                    ReactDeploy nextDeploy = new ReactDeploy(packages, true, directoryName, typescript, yarn);
                    nextDeploy.CreateApp();
                    break;
                case "sveltekit":
                    SvelteKitDeploy svelteKitDeploy = new SvelteKitDeploy(packages, directoryName, typescript, yarn);
                    break;
                case "vue":
                    VueDeploy vueDeploy = new VueDeploy(packages, directoryName, typescript, yarn);
                    break;

            }


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
