namespace WebStarterkit.CliConfig
{
    public class BackendConfig
    {
        public static void CreateExpress(string directory, string assetsPath, bool yarn, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory(assetsPath + "/express/express-mysql", directory + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory(assetsPath + "/express/express-mongodb", directory + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory(assetsPath + "/express/express-sqlite", directory + "/backend", true);
                    break;
            }

            string command = "cd " + directory + "/backend && " + (yarn ? "yarn install" : "npm install");

            HelperMethods.RunShellCommand(command);

        }

        public static void CreateRails(string directory, string assetsPath, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory(assetsPath + "/rails/rails-mysql", directory + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory(assetsPath + "/rails/rails-mongodb", directory + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory(assetsPath + "/rails/rails-sqlite", directory + "/backend", true);
                    break;
            }
        }

        public static void CreateDjango(string directory, string assetsPath, string database)
        {
            switch (database)
            {
                case "mysql":
                    HelperMethods.CopyDirectory(assetsPath + "/django/django-mysql", directory + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory(assetsPath + "/django/django-mongodb", directory + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory(assetsPath + "/django/django-sqlite", directory + "/backend", true);
                    break;
            }
        }

        public static void CreateFlask(string directory, string assetsPath, string database)
        {
            switch (database)
            {
                case "mysql":
                    Console.WriteLine("MySql is not yet supported for Flask. Using Sqlite instead.");
                    HelperMethods.CopyDirectory(assetsPath + "/flask/flask-sqlite", directory + "/backend", true);
                    break;
                case "mongodb":
                    HelperMethods.CopyDirectory(assetsPath + "/flask/flask-mongodb", directory + "/backend", true);
                    break;
                default:
                    HelperMethods.CopyDirectory(assetsPath + "/flask/flask-sqlite", directory + "/backend", true);
                    break;
            }
        }

    }
}