

namespace WebStarterkit.CliConfig
{
    public class FrontendConfig
    {
        public static void CreateReactApp(List<Package> packages, bool useNextjs, string directoryName, bool typescript, bool yarn)
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
                if (package.devDependency)
                {
                    command += (yarn ? (" && yarn add -D " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
                else
                {
                    command += (yarn ? (" && yarn add " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
            });



            HelperMethods.RunShellCommand(command);

        }


        public static void CreateVueApp(List<Package> packages, string directoryName, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? "assets/vue/vue-boilerplate-ts" : "assets/vue/vue-boilerplate", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.devDependency)
                {
                    command += (yarn ? (" && yarn add -D " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
                else
                {
                    command += (yarn ? (" && yarn add " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
            });

            HelperMethods.RunShellCommand(command);

        }

        public static void CreateSvelteApp(List<Package> packages, string directoryName, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? "assets/svelte/svelte-boilerplate-ts" : "assets/svelte/svelte-boilerplate", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.devDependency)
                {
                    command += (yarn ? (" && yarn add -D " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
                else
                {
                    command += (yarn ? (" && yarn add " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
            });

            HelperMethods.RunShellCommand(command);

        }

        public static void CreateAngularApp(List<Package> packages, string directoryName, bool yarn)
        {
            HelperMethods.CopyDirectory("assets/angular/angular-boilerplate-sass", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.devDependency)
                {
                    command += (yarn ? (" && yarn add -D " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
                else
                {
                    command += (yarn ? (" && yarn add " + package.name) : (" && npm install " + package.name + " --save-dev"));
                }
            });

            HelperMethods.RunShellCommand(command);

        }

        public static void CreateFlutterApp(List<Package> packages, string directoryName)
        {
            HelperMethods.CopyDirectory("assets/flutter", directoryName + "/frontend", true);


            string command = "cd " + directoryName + "/frontend";

            packages?.ForEach(package =>
            {
                if (package.devDependency)
                {
                    command += ((" && flutter pub add --dev " + package.name));
                }
                else
                {
                    command += ((" && flutter pub add " + package.name));
                }
            });

            HelperMethods.RunShellCommand(command);

        }
    }
}