namespace WebStarterkit.CliConfig
{
    public class BackendConfig
    {
        public static void CreateExpress(string directoryName, bool yarn, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory("../assets/express/express-mysql", directoryName + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory("../assets/express/express-mongodb", directoryName + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory("../assets/express/express-sqlite", directoryName + "/backend", true);
                    break;
            }

            string command = "cd " + directoryName + "/backend && " + (yarn ? "yarn install" : "npm install");

            HelperMethods.RunShellCommand(command);

        }

        public static void CreateRails(string directoryName, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory("../assets/rails/rails-mysql", directoryName + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory("../assets/rails/rails-mongodb", directoryName + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory("../assets/rails/rails-sqlite", directoryName + "/backend", true);
                    break;
            }
        }

        public static void CreateDjango(string directoryName, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory("../assets/django/django-mysql", directoryName + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory("../assets/django/django-mongodb", directoryName + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory("../assets/django/django-sqlite", directoryName + "/backend", true);
                    break;
            }
        }

        public static void CreateFlask(string directoryName, string database)
        {
            switch (database)
            {
                case "mysql":
                    Console.WriteLine("MySql is not yet supported for Flask. Using Sqlite instead.");
                    HelperMethods.CopyDirectory("../assets/flask/flask-sqlite", directoryName + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory("../assets/flask/flask-mongodb", directoryName + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory("../assets/flask/flask-sqlite", directoryName + "/backend", true);
                    break;
            }
        }

    }
}