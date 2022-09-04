using System.Text.RegularExpressions;


namespace WebStarterkit
{
    public class WebStarterkit
    {
        public static void Main(string[] args)
        {

            // <command name> <frontend> <backend> <appname> -pkg <packages> --typescript --yarn

            string frontend = args[0];
            string backend = args[1];
            string directoryName = args[2];

            bool typescript = args.Contains("--typescript"); // typescript/javascript
            bool yarn = args.Contains("--yarn"); // yarn/npm


            List<string>? packages = args[3].Equals("-pkg") ? GetPackages(args) : null;
            packages?.ForEach(package =>
            {
                Console.WriteLine(package); // prints out each package

            });

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
