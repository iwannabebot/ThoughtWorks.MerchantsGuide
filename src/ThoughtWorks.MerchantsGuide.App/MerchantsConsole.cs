namespace ThoughtWorks.MerchantsGuide
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public static class MerchantsConsole
    {
        public static Dictionary<string, object> ArgumentsParser(string[] args)
        {
            var readableArgs = new Dictionary<string, object>();
            foreach (string arg in args)
            {
                var filePathRgx = new Regex(@"-+(file|f)=(""|')?(.*)\b", RegexOptions.IgnoreCase);
                var geekModeRgx = new Regex(@"-+(geek)\b", RegexOptions.IgnoreCase);

                if (filePathRgx.IsMatch(arg))
                {
                    var filePath = filePathRgx.Match(arg)?.Groups[3]?.Value;
                    var fileName = System.IO.Path.GetFullPath(filePath);
                    readableArgs.Add("syntax", ReadFile(fileName));
                }
                if (geekModeRgx.IsMatch(arg))
                {
                    readableArgs.Add("geek", true);
                }
            }
            return readableArgs;
        }

        static string ReadFile(string fileName)
        {
            try
            {
                return System.IO.File.ReadAllText(fileName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                var abs = System.IO.Path.GetDirectoryName(fileName);
                Error($"Cannot read file! File not found! ");
                if (YesNo($"Can you move your file to this location @'{abs}'?"))
                {
                    if (YesNo($"Copy the location?\n"))
                    {
                        Utility.Clipbard.SetText(abs);
                        WriteLine("I just copied the above location!");
                    }
                }
            }
            catch (System.IO.PathTooLongException ex)
            {
                Error("Cannot read file! File path too long. You must be using a Windows.");
                Warning("You can do any of the two things:",
                    "1. Try running this on a linux or mac",
                    "2. Move this project to a smaller path");
            }
            catch (System.IO.IOException ex)
            {
                Error($"Cannot read file! I/O Error", "Reason:", $"{ex.Message}");
            }
            catch (Exception ex)
            {
                Error($"Cannot read file! Reason: {ex.Message}");
            }
            return null;
        }
        #region read
        public static bool YesNo(string question, string option = "Choose (y/n) : ")
        {
            WriteLine(question, ConsoleColor.Green);
            Write(option, ConsoleColor.Green);
             
            var key = Console.ReadKey();
            WriteLine("");
            if (key.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region logs
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Info(params string[] message)
        {
            WriteLine(string.Join(Environment.NewLine, message));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Error(params string[] message)
        {
            WriteLine(string.Join(Environment.NewLine, message), ConsoleColor.Red);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Warning(params string[] message)
        {
            WriteLine(string.Join(Environment.NewLine, message), ConsoleColor.Yellow);
        }

        #endregion

        #region print
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.WriteLine(string.Join(Environment.NewLine, message), color);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="color"></param>
        public static void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.Write(string.Join(Environment.NewLine, message), color);
        }
        #endregion
    }
}
