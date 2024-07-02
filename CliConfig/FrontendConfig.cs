

namespace WebStarterkit.CliConfig
{
    public class FrontendConfig
    {
        public static void CreateReactApp(List<Package> packages, bool useNextjs, string directory, string assetsPath, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(useNextjs ? assetsPath + "/react/next-boilerplate" : assetsPath + "/react/react-boilerplate", directory + "/frontend", true);

            if (typescript)
            {
                System.IO.File.Copy(useNextjs ? assetsPath + "/react/next-tsconfig.json" : assetsPath + "/react/react-tsconfig.json", directory + "/frontend/tsconfig.json", true);
            }

            // need to run commands all at once to stay in proper directory
            string command = "cd " + directory + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.isDevDependency)
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


        public static void CreateVueApp(List<Package> packages, string directory, string assetsPath, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? assetsPath + "vue/vue-boilerplate-ts" : assetsPath + "vue/vue-boilerplate", directory + "/frontend", true);


            string command = "cd " + directory + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.isDevDependency)
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

        public static void CreateSvelteApp(List<Package> packages, string directory, string assetsPath, bool typescript, bool yarn)
        {
            HelperMethods.CopyDirectory(typescript ? assetsPath + "svelte/svelte-boilerplate-ts" : assetsPath + "svelte/svelte-boilerplate", directory + "/frontend", true);


            string command = "cd " + directory + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.isDevDependency)
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

        public static void CreateAngularApp(List<Package> packages, string directory, string assetsPath, bool yarn)
        {
            HelperMethods.CopyDirectory(assetsPath + "angular/angular-boilerplate-sass", directory + "/frontend", true);


            string command = "cd " + directory + "/frontend && " + (yarn ? "yarn install" : "npm install");

            packages?.ForEach(package =>
            {
                if (package.isDevDependency)
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

        public static void CreateFlutterApp(List<Package> packages, string directory, string assetsPath)
        {
            HelperMethods.CopyDirectory(assetsPath + "/flutter", directory + "/frontend", true);


            string command = "cd " + directory + "/frontend";

            packages?.ForEach(package =>
            {
                if (package.isDevDependency)
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