using System;

namespace Scintillanet.Configuration
{

	public class ConfigManager
	{
		public class FileMasks
		{
			private ConfigManager instance;
			public FileMasks(ConfigManager i)
			{
				instance = i;
			}
			public string[] this[string index]
			{
				get
				{
					try
					{
						Language l = instance.config.GetLanguage( index );
						string fe = l.fileextensions.Trim().Replace("\n" , " " );
						fe = fe.Replace("\t" , " " );
						while( fe.IndexOf("  " ) > -1 )
							fe = fe.Replace("  " , " " );

						return fe.Split(" ".ToCharArray());

					}
					catch( Exception )
					{
						return new string[0];
					}
					
				}
			}
		}


		private Scintillanet.Configuration.Scintilla config;
		private FileMasks _filemasks;
		public ConfigManager()
		{
			_filemasks = new FileMasks( this );
			ReloadConfig();
		}

		public void ReloadConfig()
		{
			// create the configuration utility.
			// you need to pass a type that exists int the assembly where the class that you use as
			// a base node for configuration.
			ConfigurationUtility cu = new ConfigurationUtility(GetType().Module.Assembly);
			
			// set the configuration to scintilla
			config = (Scintilla)cu.LoadConfiguration( typeof(Scintilla) , "settings\\ScintillaNET.xml" );
		}

		public string[] Languages
		{
			get
			{
				
				string[] result = new string[ config.AllLanguages.Length ];
				for( int i=0;i< result.Length ; i++ )
					result[i] = config.AllLanguages[i].name;
				Array.Sort(result);
				return result;
			}
		}

		public string[] MasterStyles
		{
			get
			{
				
				string[] result = new string[ config.styleclasses.Length ];
				for( int i=0;i< result.Length ; i++ )
					result[i] = config.styleclasses[i].name;
				Array.Sort(result);
				return result;
			}
		}


		public FileMasks filemasks
		{
			get
			{
				return _filemasks;
			}
		}

		public Scintilla Config
		{
			get
			{
				return config;
			}
		}

		public string[] GetLanguagesForFilemask( string filemask )
		{
			filemask = filemask.ToLower();

			System.Collections.ArrayList result = new System.Collections.ArrayList();

			foreach( Language l in  config.AllLanguages )
			{
				string[] fm = filemasks[ l.name ];
				foreach( string msk in fm )
				{
					string mask = msk.ToLower();
					if( filemask.Equals( mask )  || MatchString( mask , filemask ) )
					{
						result.Add( l.name );
						break;
					}
				}
			}
			return (string[])result.ToArray( typeof(string) );
		}

		private static bool CheckAllAsterisks(string s, int index) 
		{
			for (int i = index; i < s.Length; i++) 
				if (s[i] != '*') 
					return false;
			return true;
		}

		private static bool DoMatch(string pattern, int patternIndex, string s, int sIndex) 
		{
			if (sIndex == s.Length) 
			{
				if (patternIndex == pattern.Length) 
					return true;
				return CheckAllAsterisks(pattern, patternIndex);
			}

			if (patternIndex == pattern.Length) 
				return false;

			switch (pattern[patternIndex]) 
			{
				case '?' :
					return DoMatch(pattern, patternIndex + 1, s, sIndex + 1);
				case '*' : 
					if (patternIndex == pattern.Length - 1)
						return true;
					bool testMatch = DoMatch(pattern, patternIndex + 1, s, sIndex);
					if (!testMatch) 
						testMatch = DoMatch(pattern, patternIndex, s, sIndex + 1);
					return testMatch;
				default : 
					if (pattern[patternIndex] != s[sIndex]) 
						return false;
					return DoMatch(pattern, patternIndex + 1, s, sIndex + 1);
			}
		}

		public static bool MatchString(string pattern, string s) 
		{
			return DoMatch(pattern, 0, s, 0);
		}



	}
}
