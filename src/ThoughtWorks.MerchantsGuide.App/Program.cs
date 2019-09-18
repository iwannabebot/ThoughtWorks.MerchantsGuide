using System;
using System.Text.RegularExpressions;

namespace ThoughtWorks.MerchantsGuide.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = ReadArguments(args);
        }
        public static string[] ReadArguments(string[] args)
        {
            foreach(string arg in args)
            {
                var filePathRgx = new Regex(@"-+(file|f)=(""|')?(.*)\b", RegexOptions.IgnoreCase);

                if (filePathRgx.IsMatch(arg))
                {
                    var filePath = filePathRgx.Match(arg).Groups[3].Value;
                    var fileName = System.IO.Path.GetFullPath(filePath);
                    try
                    {
                        return System.IO.File.ReadAllLines(fileName);
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        var abs = System.IO.Path.GetDirectoryName(fileName);
                        Console.WriteLine($"File not found! " +
                            $"Can you move your file to this location @'{abs}' and run the same command?" +
                            $"Want to copy path?(y/n)");
                        var key = Console.ReadKey();
                        if(key.Key == ConsoleKey.Y)
                        {
                            try
                            {
                                Helpers.Clipbard.SetText(abs);
                                Console.WriteLine("I just copied the above location!");
                            }
                            catch
                            {
                                Console.WriteLine("Ah shizz, unable to copy!");
                            }
                        }
                    }
                    catch (System.IO.PathTooLongException ex)
                    {
                        Console.WriteLine("File path too long. You must be using a Windows. You can do any of the two things:" + 
                            "1. Try running this on a linux or mac. or" +
                            "2. Move this project to a smaller path");
                    }
                    catch (System.IO.IOException ex)
                    {
                        Console.WriteLine("Cannot read file! Reason: ");
                    }
                }
            }

            Console.WriteLine($"No input provided.");
            Console.WriteLine($"Usage:");
            Console.WriteLine($"Syntax:     --[file|f]=[\"]<filepath>[\"]");
            Console.WriteLine($"Examples:");
            Console.WriteLine($"            --file=<file path>");
            return null;
        }
    }
}
