using HelpersTool.ConsoleApp.Tools;
using System;

namespace HelpersTool.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var @in = "genres.txt";
            var @out = "out.txt";

            var tool = new MusicGenresTool(@in, @out, Log);
            tool.Run();
        }
        
        static void Log(string @in)
        {
            Console.WriteLine(@in);
        }
    }
}
