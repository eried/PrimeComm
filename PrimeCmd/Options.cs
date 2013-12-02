using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace PrimeComm
{

    sealed class Options
    {
        [Option('i', "input", MetaValue="FILE", HelpText = "File to be sent to the device or folder (output).")]
        public string SendFile { get; set; }

        [Option('r', "receive", MetaValue = "FILE", HelpText = "Receive a file from the device.")]
        public string ReceiveFile { get; set; }

        [Option('o', "output", MetaValue = "FOLDER", HelpText = "Destination folder (if empty, send to device).")]
        public string OutputFolder { get; set; }

        [Option('t', MetaValue="SECONDS",HelpText = "Timeout in seconds", DefaultValue=5)]
        public int Timeout { get; set; }

        [Option("IgnoreInternalName", HelpText = "Ignore internal name", DefaultValue = false)]
        public bool IgnoreInternalName { get; set; }

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
}
