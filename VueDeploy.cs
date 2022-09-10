
// https://nuxtjs.org/docs/get-started/installation
// add nuxt

namespace WebStarterkit
{
    public class VueDeploy
    {

        private List<string>? packages;
        private string directoryName;
        private bool typescript;
        private bool yarn;



        public VueDeploy(List<string>? packages, string directoryName, bool typescript, bool yarn)
        {
            this.packages = packages;
            this.directoryName = directoryName;
            this.typescript = typescript;
            this.yarn = yarn;

        }

        public void CreateApp()
        {
            HelperMethods.CopyDirectory(typescript ? "assets/vue/vuew-boilerplate-ts" : "assets/vue/vue-boilerplate", directoryName + "/frontend", true);


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