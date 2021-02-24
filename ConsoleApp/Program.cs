using Mono.Options;

using System;
using System.IO;
using System.Reflection;

using TextImage;
using TextImage.Enums;

namespace ConsoleApp
{
    public class Program
    {
        private static string Input { get; set; }
        private static string Output { get; set; }
        private static string Format { get; set; } = "ascii";
        private static bool ShouldShowHelp { get; set; }
        private static byte Threshold { get; set; } = 127;

        public static void Main(string[] args)
        {
            var options = new OptionSet
            {
                { "i|input=", "the input image file path.", i => Input = i },
                { "o|output=", "the output text file path.", o => Output = o },
                { "f|format=", "the format of encoding [ascii | braille], default is ascii.", f => Format = f },
                { "t|threshold=", "threshold used in braille format [0~255], default is 127.", t => Threshold = Convert.ToByte(t) },
                { "h|help", "show this message and exit.", h => ShouldShowHelp = h != null }
            };

            if (!GetOpt(options, args))
                return;

            if (ShouldShowHelp)
            {
                ShowHelp(options);
                return;
            }

            Execute();
        }

        private static void Execute()
        {
            if (string.IsNullOrWhiteSpace(Input) || string.IsNullOrWhiteSpace(Output))
            {
                Console.WriteLine("input and output are required.");
                return;
            }

            if (!Enum.TryParse(Format, true, out ImageTextFormat format))
            {
                Console.WriteLine($"format '{Format}' not found.");
                return;
            }

            try
            {
                string text = new ImageTextBuilder()
                    .WithSource(Input)
                    .WithThreshold(Threshold)
                    .WithFormat(format)
                    .Build();

                File.WriteAllText(Output, text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static bool GetOpt(OptionSet options, string[] args)
        {
            try
            {
                options.Parse(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        private static void ShowHelp(OptionSet optionSet)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Console.WriteLine($"Usage: {assemblyName}.exe +[options]");
            Console.WriteLine("options:");
            optionSet.WriteOptionDescriptions(Console.Out);
        }
    }
}
