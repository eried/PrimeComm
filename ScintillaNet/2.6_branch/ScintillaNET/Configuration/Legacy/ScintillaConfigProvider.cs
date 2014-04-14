using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ScintillaNet;
using ScintillaNet.Configuration;
using System.Reflection;

namespace ScintillaNet.Configuration.Legacy
{
    public class ScintillaConfigProvider : IScintillaConfigProvider
    {
        private Assembly resourceAssembly;
        private string resourcePath;
        private DirectoryInfo directory;

        public ScintillaConfigProvider()
        {
            resourceAssembly = Assembly.GetExecutingAssembly();
            resourcePath = "Scintilla.Configuration.Legacy.ConfigFiles";
        }

        public ScintillaConfigProvider(DirectoryInfo dir)
        {
            directory = dir;
        }

        public ScintillaConfigProvider(Assembly assembly, string resourcePath)
        {
            this.resourceAssembly = assembly;
            this.resourcePath = resourcePath;
        }

        private ConfigResource GetResource(string filename)
        {
            ConfigResource res = null;
            if (directory != null)
            {
                FileInfo fileInfo = new FileInfo(directory.FullName + "\\" + filename);
                res = new ConfigResource(fileInfo);
            }
            else if ((resourceAssembly != null) && (resourcePath != null))
            {
                res = new ConfigResource(resourceAssembly, resourcePath, filename);
            }
            return res;
        }

        public bool PopulateScintillaConfig(IScintillaConfig config)
        {
            ScintillaPropertiesHelper.Populate(config, GetResource("global.properties"));
            return true;
        }

        public bool PopulateLexerConfig(ILexerConfig config)
        {
            ScintillaPropertiesHelper.Populate(config.ScintillaConfig, GetResource("lex." + config.LexerName.ToLower() + ".properties"));
            return true;
        }

        public bool PopulateLanguageConfig(ILanguageConfig config, ILexerConfigCollection lexers)
        {
            ScintillaPropertiesHelper.Populate(config.ScintillaConfig, GetResource("lang." + config.Name.ToLower() + ".properties"));
            return true;
        }
    }


    public class ConfigResource
    {
        private Assembly resourceAssembly;
        private string resourcePath;
        private string name;
        private FileInfo file;

        public ConfigResource(FileInfo file)
        {
            this.file = file;
        }

        public ConfigResource(Assembly resourceAssembly, string resourcePath, string resourceName)
        {
            this.resourceAssembly = resourceAssembly;
            this.resourcePath = resourcePath;
            this.name = resourceName.Replace(".", "_");
        }

        public ConfigResource GetLocalConfigResource(string name)
        {
            if (file != null)
            {
                FileInfo tmp = new FileInfo(file.Directory.FullName + "\\" + name);
                return new ConfigResource(tmp);
            }
            else
            {
                return new ConfigResource(resourceAssembly, resourcePath, name.Replace(".", "_"));
            }
        }

        public bool Exists
        {
            get
            {
                if (file != null)
                {
                    return file.Exists;
                }
                else if ((resourceAssembly != null) && (resourcePath != null) && (name != null))
                {
                    List<string> resourceNames = new List<string>(resourceAssembly.GetManifestResourceNames());
                    return resourceNames.Contains(resourcePath + "." + name);
                }

                return false;
            }
        }

        public Stream OpenRead()
        {
            if (file != null)
            {
                return file.OpenRead();
            }
            else if ((resourceAssembly != null) && (resourcePath != null) && (name != null))
            {
                return resourceAssembly.GetManifestResourceStream(resourcePath + "." + name);
            }

            return null;
        }
    }

}
