using System;

namespace WebStarterkit
{
  public class WebStarterkit
  {
    public static void Main(string[] args)
    {
      // TODO: Call function that reads in and delegates work for args
      System.Console.WriteLine("Hello world!");
      Array.ForEach(args, arg => Console.WriteLine(arg));
    }
  }
}
