


namespace WebStarterkit
{
    public class SvelteKitDeploy
    {

        private List<string>? packages;
        private string directoryName;
        private bool typescript;
        private bool yarn;



        public SvelteKitDeploy(List<string>? packages, string directoryName, bool typescript, bool yarn)
        {
            this.packages = packages;
            this.directoryName = directoryName;
            this.typescript = typescript;
            this.yarn = yarn;

        }

        public void CreateApp()
        {
            HelperMethods.CopyDirectory(typescript ? "assets/sveltekit/sveltekit-boilerplate-ts" : "assets/sveltekit/sveltekit-boilerplate", directoryName + "/frontend", true);


            // need to run commands all at once to stay in proper directory
            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                command += (yarn ? (" && yarn add " + package) : (" && npm install " + package));
            });

            HelperMethods.RunShellCommand(command);

        }

    }
}