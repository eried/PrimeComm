using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace ScintillaNet.Configuration.Legacy.SciTE
{
    public enum SciTEPropertyType
    {
        Property = 0,
        Comment,
        Import,
        If,
        IgnoredLine,
        EmptyLine
    }


    public delegate bool SciTEPropertyDelegate(FileInfo file, SciTEPropertyType propertyType, Queue<string> keyQueue, string key, string val);
    
    /// <summary>
    /// A class that reads in ths properties from the 
    /// Justin Greenwood - justin.greenwood@gmail.com
    /// </summary>
    public static class SciTEPropertiesReader
    {
        private static SciTEProperties s_props = null;
        private static bool s_supressImports = true;

        private enum ReadMode
        {
            Key = 0,
            Value,
            Import,
            If,
            FlushWhiteSpace
        }

        public static void Read(FileInfo propsFileInfo, SciTEProperties props)
        {
            Read(propsFileInfo, props, false);
        }

        public static void Read(ConfigResource propsFileInfo, SciTEProperties props)
        {
            Read(propsFileInfo, props, false);
        }

        public static void Read(FileInfo propsFileInfo, SciTEProperties props, bool supressImports)
        {
            s_props = props;
            s_supressImports = supressImports;

            Read(propsFileInfo, PropertyRead);
        }

        public static void Read(ConfigResource propsFileInfo, SciTEProperties props, bool supressImports)
        {
            s_props = props;
            s_supressImports = supressImports;

            Read(propsFileInfo, PropertyRead);
        }


        public static void Read(FileInfo propsFileInfo, SciTEPropertyDelegate propertyRead)
        {
            StreamReader reader = new StreamReader(propsFileInfo.OpenRead());

            char c = ' ', prev = '\\';
            int lastStart = 0, ignoreCount = 0;
            bool ignoreProperties = false;
            string key = null, var = null;
            StringBuilder currentVar = new StringBuilder();
            StringBuilder currentToken = new StringBuilder();

            Queue<string> queue = new Queue<string>();
            StringBuilder currentTokenPiece = new StringBuilder();

            ReadMode mode = ReadMode.Key;
            ReadMode nextModeAfterSpaces = ReadMode.Key;

            string line = reader.ReadLine();
            while (line != null)
            {
                int start = 0;
                bool skipLine = false;

                while ((start < line.Length) && char.IsWhiteSpace(line[start])) ++start;

                if (start >= line.Length)
                {
                    propertyRead(propsFileInfo, SciTEPropertyType.EmptyLine, queue, string.Empty, string.Empty);
                }
                else if (line[start] == '#')
                {
                    propertyRead(propsFileInfo, SciTEPropertyType.Comment, queue, "#", line);
                }
                else
                {
                    if (ignoreProperties)
                    {
                        if ((ignoreCount == 0) || (start == lastStart))
                        {
                            ignoreCount++;
                            lastStart = start;
                            skipLine = true;
                        }
                        else
                        {
                            ignoreCount = 0;
                            ignoreProperties = false;
                        }
                    }

                    if (skipLine)
                    {
                        propertyRead(propsFileInfo, SciTEPropertyType.EmptyLine, queue, string.Empty, string.Empty);
                    }
                    else
                    {
                        for (int i = start; i < line.Length; i++)
                        {
                            c = line[i];

                            if (mode == ReadMode.Key)
                            {
                                if (c == '=')
                                {
                                    if (currentTokenPiece.Length > 0)
                                    {
                                        queue.Enqueue(currentTokenPiece.ToString());
                                    }

                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);

                                    key = currentToken.ToString();
                                    currentToken.Remove(0, currentToken.Length);

                                    mode = ReadMode.Value;
                                    continue;
                                }
                                else if (char.IsWhiteSpace(c))
                                {
                                    key = currentToken.ToString();
                                    currentToken.Remove(0, currentToken.Length);
                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);

                                    if (key == "if")
                                    {
                                        nextModeAfterSpaces = ReadMode.If;
                                    }
                                    else if (key == "import")
                                    {
                                        nextModeAfterSpaces = ReadMode.Import;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    mode = ReadMode.FlushWhiteSpace;
                                    continue;
                                }
                                else if (c == '.')
                                {
                                    currentToken.Append(c);

                                    queue.Enqueue(currentTokenPiece.ToString());
                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);
                                }
                                else
                                {
                                    currentTokenPiece.Append(c);
                                    currentToken.Append(c);
                                }
                            }
                            else if (mode == ReadMode.FlushWhiteSpace)
                            {
                                if (!char.IsWhiteSpace(c))
                                {
                                    currentToken.Append(c);
                                    mode = nextModeAfterSpaces;
                                }
                            }
                            else if (mode == ReadMode.Import)
                            {
                                currentToken.Append(c);
                            }
                            else if (mode == ReadMode.If)
                            {
                                currentToken.Append(c);
                            }
                            else if (mode == ReadMode.Value)
                            {
                                currentToken.Append(c);
                            }
                            prev = c;
                        }

                        if (prev != '\\')
                        {
                            var = currentToken.ToString();
                            if (mode == ReadMode.If)
                            {
                                ignoreProperties = propertyRead(propsFileInfo, SciTEPropertyType.If, queue, key, var);
                            }
                            else if (mode == ReadMode.Import)
                            {
                                // Open another file inline with this one.
                                if (propertyRead(propsFileInfo, SciTEPropertyType.Import, queue, key, var))
                                {
                                    FileInfo fileToImport = new FileInfo(string.Format(@"{0}\{1}.properties", propsFileInfo.Directory.FullName, var));
                                    if (fileToImport.Exists)
                                    {
                                        Read(fileToImport, propertyRead);
                                    }
                                }
                            }
                            else if (mode == ReadMode.Value)
                            {
                                propertyRead(propsFileInfo, SciTEPropertyType.Property, queue, key, var);
                            }
                            currentToken.Remove(0, currentToken.Length);
                            queue.Clear();
                            key = null;
                            mode = ReadMode.Key;
                        }
                        else
                        {
                            currentToken.Remove(currentToken.Length - 1, 1);
                        }
                    }
                }
                line = reader.ReadLine();
            }
            reader.Close();

            if (key != null)
            {
                var = currentToken.ToString();
                propertyRead(propsFileInfo, SciTEPropertyType.Property, queue, key, var);
            }
        }


        public static void Read(ConfigResource resource, SciTEPropertyDelegate propertyRead)
        {
            if (!resource.Exists) return;
            StreamReader reader = new StreamReader(resource.OpenRead());

            char c = ' ', prev = '\\';
            int lastStart = 0, ignoreCount = 0;
            bool ignoreProperties = false;
            string key = null, var = null;
            StringBuilder currentVar = new StringBuilder();
            StringBuilder currentToken = new StringBuilder();

            Queue<string> queue = new Queue<string>();
            StringBuilder currentTokenPiece = new StringBuilder();

            ReadMode mode = ReadMode.Key;
            ReadMode nextModeAfterSpaces = ReadMode.Key;

            string line = reader.ReadLine();
            while (line != null)
            {
                int start = 0;
                bool skipLine = false;

                while ((start < line.Length) && char.IsWhiteSpace(line[start])) ++start;

                if (start >= line.Length)
                {
                    PropertyRead(resource, SciTEPropertyType.EmptyLine, queue, string.Empty, string.Empty);
                }
                else if (line[start] == '#')
                {
                    PropertyRead(resource, SciTEPropertyType.Comment, queue, "#", line);
                }
                else
                {
                    if (ignoreProperties)
                    {
                        if ((ignoreCount == 0) || (start == lastStart))
                        {
                            ignoreCount++;
                            lastStart = start;
                            skipLine = true;
                        }
                        else
                        {
                            ignoreCount = 0;
                            ignoreProperties = false;
                        }
                    }

                    if (skipLine)
                    {
                        PropertyRead(resource, SciTEPropertyType.EmptyLine, queue, string.Empty, string.Empty);
                    }
                    else
                    {
                        for (int i = start; i < line.Length; i++)
                        {
                            c = line[i];

                            if (mode == ReadMode.Key)
                            {
                                if (c == '=')
                                {
                                    if (currentTokenPiece.Length > 0)
                                    {
                                        queue.Enqueue(currentTokenPiece.ToString());
                                    }

                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);

                                    key = currentToken.ToString();
                                    currentToken.Remove(0, currentToken.Length);

                                    mode = ReadMode.Value;
                                    continue;
                                }
                                else if (char.IsWhiteSpace(c))
                                {
                                    key = currentToken.ToString();
                                    currentToken.Remove(0, currentToken.Length);
                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);

                                    if (key == "if")
                                    {
                                        nextModeAfterSpaces = ReadMode.If;
                                    }
                                    else if (key == "import")
                                    {
                                        nextModeAfterSpaces = ReadMode.Import;
                                    }
                                    else
                                    {
                                        break;
                                    }

                                    mode = ReadMode.FlushWhiteSpace;
                                    continue;
                                }
                                else if (c == '.')
                                {
                                    currentToken.Append(c);

                                    queue.Enqueue(currentTokenPiece.ToString());
                                    currentTokenPiece.Remove(0, currentTokenPiece.Length);
                                }
                                else
                                {
                                    currentTokenPiece.Append(c);
                                    currentToken.Append(c);
                                }
                            }
                            else if (mode == ReadMode.FlushWhiteSpace)
                            {
                                if (!char.IsWhiteSpace(c))
                                {
                                    currentToken.Append(c);
                                    mode = nextModeAfterSpaces;
                                }
                            }
                            else if (mode == ReadMode.Import)
                            {
                                currentToken.Append(c);
                            }
                            else if (mode == ReadMode.If)
                            {
                                currentToken.Append(c);
                            }
                            else if (mode == ReadMode.Value)
                            {
                                currentToken.Append(c);
                            }
                            prev = c;
                        }

                        if (prev != '\\')
                        {
                            var = currentToken.ToString();
                            if (mode == ReadMode.If)
                            {
                                ignoreProperties = PropertyRead(resource, SciTEPropertyType.If, queue, key, var);
                            }
                            else if (mode == ReadMode.Import)
                            {
                                // Open another file inline with this one.
                                if (PropertyRead(resource, SciTEPropertyType.Import, queue, key, var))
                                {
                                    if (resource.Exists)
                                    {
                                        Read(resource, propertyRead);
                                    }
                                }
                            }
                            else if (mode == ReadMode.Value)
                            {
                                PropertyRead(resource, SciTEPropertyType.Property, queue, key, var);
                            }
                            currentToken.Remove(0, currentToken.Length);
                            queue.Clear();
                            key = null;
                            mode = ReadMode.Key;
                        }
                        else
                        {
                            currentToken.Remove(currentToken.Length - 1, 1);
                        }
                    }
                }
                line = reader.ReadLine();
            }
            reader.Close();

            if (key != null)
            {
                var = currentToken.ToString();
                PropertyRead(resource, SciTEPropertyType.Property, queue, key, var);
            }
        }


        private static bool PropertyRead(FileInfo file, SciTEPropertyType propertyType, Queue<string> keyQueue, string key, string var)
        {
            bool success = false;
            string filePatternPrefix = "file.patterns.";
            string languageNameListPrefix = "language.names";
            string lang, extList;

            if (s_props != null)
            {
                switch (propertyType)
                {
                    case SciTEPropertyType.Property:
                        success = true;
                        s_props[key] = var;
                        if (key.StartsWith(languageNameListPrefix))
                        {
                            extList = s_props.Evaluate(var);
                            s_props.AddLanguageNames(var.Split(' '));
                        }
                        else if (key.StartsWith(filePatternPrefix))
                        {
                            lang = key.Substring(filePatternPrefix.Length);
                            if (lang.LastIndexOf('.') == -1)
                            {
                                extList = s_props.Evaluate(var);
                                s_props.AddFileExtentionMapping(extList, lang);
                            }
                        }
                        break;
                    case SciTEPropertyType.If:
                        if (s_props.ContainsKey(var))
                        {
                            success = !Convert.ToBoolean(s_props[var]);
                        }
                        break;
                    case SciTEPropertyType.Import:
                        if (!s_supressImports)
                        {
                            FileInfo fileToImport = new FileInfo(string.Format(@"{0}\{1}.properties", file.Directory.FullName, var));
                            success = fileToImport.Exists;
                        }
                        break;
                }
            }

            return success;
        }


        private static bool PropertyRead(ConfigResource file, SciTEPropertyType propertyType, Queue<string> keyQueue, string key, string var)
        {
            bool success = false;
            string filePatternPrefix = "file.patterns.";
            string languageNameListPrefix = "language.names";
            string lang, extList;

            if (s_props != null)
            {
                switch (propertyType)
                {
                    case SciTEPropertyType.Property:
                        success = true;
                        s_props[key] = var;
                        if (key.StartsWith(languageNameListPrefix))
                        {
                            extList = s_props.Evaluate(var);
                            s_props.AddLanguageNames(var.Split(' '));
                        }
                        else if (key.StartsWith(filePatternPrefix))
                        {
                            lang = key.Substring(filePatternPrefix.Length);
                            if (lang.LastIndexOf('.') == -1)
                            {
                                extList = s_props.Evaluate(var);
                                s_props.AddFileExtentionMapping(extList, lang);
                            }
                        }
                        break;
                    case SciTEPropertyType.If:
                        if (s_props.ContainsKey(var))
                        {
                            success = !Convert.ToBoolean(s_props[var]);
                        }
                        break;
                    case SciTEPropertyType.Import:
                        if (!s_supressImports)
                        {
                            success = file.Exists;
                        }
                        break;
                }
            }

            return success;
        }
    }
}
