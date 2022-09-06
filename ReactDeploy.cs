


namespace WebStarterkit
{
    public class ReactDeploy
    {

        private List<string>? packages;
        private string directoryName;
        private bool typescript;
        private bool yarn;


        public ReactDeploy(List<string>? packages, string directoryName, bool typescript, bool yarn)
        {
            this.packages = packages;
            this.directoryName = directoryName;
            this.typescript = typescript;
            this.yarn = yarn;
        }

        public ReactDeploy(string directoryName, bool typescript, bool yarn)
        {
            this.directoryName = directoryName;
            this.typescript = typescript;
            this.yarn = yarn;
        }


        public void CreateApp()
        {
            HelperMethods.CopyDirectory("assets/react/react-boilerplate", directoryName + "/frontend", true);

            if (typescript)
            {
                System.IO.File.Copy("assets/react/react-tsconfig.json", directoryName + "/frontend/tsconfig.json", true);
            }

            // need to run commands all at once to stay in proper directory
            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                command = command + (yarn ? (" && yarn add " + package) : (" && npm install " + package));
            });

            HelperMethods.RunShellCommand(command);

        }

    }
}