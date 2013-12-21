using System;
using PrimeComm.Properties;
using PrimeLib;

namespace PrimeComm
{
    /// <summary>
    /// Structure  that contains the files to be processed and the settings used in the batch processing of these files
    /// </summary>
    public class PrimeFileSet
    {
        public string[] Files { get; set; }
        public PrimeParameters Settings { get; set; }

        public PrimeFileSet(string[] fileNames, PrimeParameters settings)
        {
            Files = fileNames;
            Settings = settings;
        }

        internal static PrimeFileSet Create(string[] p, PrimeParameters settings)
        {
            return new PrimeFileSet(p, settings);
        }

        public Destinations Destination { get; set; }

        public string CustomDestination { get; set; }
    }
}