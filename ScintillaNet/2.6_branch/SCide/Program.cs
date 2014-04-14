#region Using Directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

#endregion Using Directives


namespace SCide
{
	static class Program
	{
		#region Fields

		public static MainForm MainForm = null;

		#endregion Fields


		#region Properties

		public static DocumentForm ActiveDocument
		{
			get
			{
				return MainForm.ActiveDocument;
			}
		}


		public static string Title
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (!String.IsNullOrEmpty(titleAttribute.Title))
						return titleAttribute.Title;
				}

				// If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		#endregion Properties


		#region Methods

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(args));
		}

		#endregion Methods
	}
}