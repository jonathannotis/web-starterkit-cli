

namespace WebStarterkit
{
    public class FrontendConfig
    {
        public static void CreateReactApp(List<string>? packages, bool useNextjs, string directoryName, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(useNextjs ? "assets/react/next-boilerplate" : "assets/react/react-boilerplate", directoryName + "/frontend", true);

            if (typescript)
            {
                System.IO.File.Copy(useNextjs ? "assets/react/next-tsconfig.json" : "assets/react/react-tsconfig.json", directoryName + "/frontend/tsconfig.json", true);
            }

            // need to run commands all at once to stay in proper directory
            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                command += (yarn ? (" && yarn add " + package) : (" && npm install " + package));
            });

            HelperMethods.RunShellCommand(command);

        }

        // add nuxt: https://nuxtjs.org/docs/get-started/installation
        public static void CreateVueApp(List<string>? packages, string directoryName, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? "assets/vue/vuew-boilerplate-ts" : "assets/vue/vue-boilerplate", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                command += (yarn ? (" && yarn add " + package) : (" && npm install " + package));
            });

            HelperMethods.RunShellCommand(command);

        }
        public static void CreateSvelteApp(List<string>? packages, string directoryName, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? "assets/sveltekit/sveltekit-boilerplate-ts" : "assets/sveltekit/sveltekit-boilerplate", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                command += (yarn ? (" && yarn add " + package) : (" && npm install " + package));
            });

            HelperMethods.RunShellCommand(command);

        }
    }
}