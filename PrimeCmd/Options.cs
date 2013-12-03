using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace PrimeCmd
{
    sealed class Options
    {
        [Option('i', "input", MetaValue="FILE", HelpText = "File to be sent to the device or folder (output).")]
        public string SendFile { get; set; }

        [Option('s', "save", MetaValue = "FILE", HelpText = "Receive a file from the device.")]
        public string ReceiveFile { get; set; }

        [Option('o', "output", MetaValue = "FOLDER", HelpText = "Destination folder (if empty, send to device).")]
        public string OutputFolder { get; set; }

        [Option('t', MetaValue="SECONDS",HelpText = "Timeout in seconds", DefaultValue=5)]
        public int Timeout { get; set; }

        [Option("ignore-name", HelpText = "Ignore internal name", DefaultValue = false)]
        public bool IgnoreInternalName { get; set; }

        [Option('c',"server", MutuallyExclusiveSet="server", HelpText = "Starts the command server mode")]
        public bool RemoteMode { get; set; }

        [OptionList("server-mode", MutuallyExclusiveSet = "server", Separator = ',', HelpText = "Configure server mode, use comma as separator")]
        public IList<String> RemoteModeConfiguration { get; set; }

        /*
        [Option("i", HelpText = "If file has errors don't stop processing.")]
        public bool IgnoreErrors { get; set; }

        [Option('j', "jump", MetaValue = "INT", DefaultValue = 0, HelpText = "Data processing start offset.")]
        public double StartOffset { get; set; }

        [ValueList(typeof(List<string>))]
        public IList<string> DefinitionFiles { get; set; }

        [OptionList('o', "operators", Separator = ';', HelpText = "Operators included in processing (+;-;...)." +
            " Separate each operator with a semicolon." + " Do not include spaces between operators and separator.")]
        public IList<string> AllowedOperators { get; set; }*/

        //
        // Marking a property of type IParserState with ParserStateAttribute allows you to
        // receive an instance of ParserState (that contains a IList<ParsingError>).
        // This is equivalent from inheriting from CommandLineOptionsBase (of previous versions)
        // with the advantage to not propagating a type of the library.
        //
        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = HelpText.AutoBuild(this);

            var p = Path.GetFileNameWithoutExtension(Process.GetCurrentProcess().MainModule.FileName).ToUpper();
            var s = new String(' ', p.Length + 21);
            help.AddPreOptionsLine(" ");
            help.AddPreOptionsLine("This application allows you to interact with your HP Prime Calculator via");
            help.AddPreOptionsLine("command line. Call the application using a filename (.txt or .hpprgm) as a");
            help.AddPreOptionsLine("shortcut for -input argument.");

            help.AddPostOptionsLine("Available modes for Command server mode:");
            help.AddPostOptionsLine(s + String.Join(", ",Enum.GetNames(typeof (RemoteModes))));

            help.AddPostOptionsLine(" ");
            help.AddPostOptionsLine("Examples:");
            help.AddPostOptionsLine(p + " FILE                Send FILE to the device");
            help.AddPostOptionsLine(p + " -i FILE             Send FILE to the device");
            help.AddPostOptionsLine(p + " -i FILE -o FOLDER   Convert FILE to .hpprgm and save it to FOLDER");
            help.AddPostOptionsLine(p + " -i FILE -r FILE2    Open FILE and save it to FILE2");
            help.AddPostOptionsLine(p + " -r FILE             Receive FILE from the device");
            help.AddPostOptionsLine(p + " -r FILE -t 10       Receive FILE from the device, waiting 10 secs");
            help.AddPostOptionsLine(s + "as max for the device to be connected");
            help.AddPostOptionsLine(p + " -o FOLDER           Receive an .hpprgm and save it to FOLDER");

            /*if (LastParserState.Errors.Count > 0)
            {
                var errors = help.RenderParsingErrorsText(this, 2); // indent with two spaces
                if (!string.IsNullOrEmpty(errors))
                {
                    help.AddPreOptionsLine(string.Concat(Environment.NewLine, "ERROR(S):"));
                    help.AddPreOptionsLine(errors);
                }
            }*/
            return help;
        }
    }


    public enum RemoteModes
    {
        quiet,
        skip_remote_echo,
        skip_local_echo,
    };
}
