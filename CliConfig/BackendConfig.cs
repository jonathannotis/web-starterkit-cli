namespace WebStarterkit.CliConfig
{
    public class BackendConfig
    {
        static void createFlask() { }

        public static void CreateExpress(string directoryName, bool yarn, bool mysql)
        {
            HelperMethods.CopyDirectory(mysql ? "assets/express/express-mysql" : "assets/express/express-mongodb", directoryName + "/backend", true);

            string command = "cd " + directoryName + "/backend && " + (yarn ? "yarn install" : "npm install");

            HelperMethods.RunShellCommand(command);

        }
    }
}