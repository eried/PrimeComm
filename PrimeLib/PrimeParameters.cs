using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace PrimeLib
{
    /// <summary>
    /// Parameters for Prime related routines
    /// </summary>
    public class PrimeParameters
    {
        private readonly Dictionary<string,object> _properties;

        /// <summary>
        /// Creates a new PrimeParameters object
        /// </summary>
        /// <param name="settings">Use this settings as base</param>
        public PrimeParameters(ApplicationSettingsBase settings): this()
        {
            foreach (SettingsPropertyValue s in settings.PropertyValues)
                _properties.Add(s.Name, s.PropertyValue);
        }

        /// <summary>
        /// Creates a new PrimeParameters object
        /// </summary>
        /// <param name="settings">Use this settings as base</param>
        public PrimeParameters(IEnumerable<KeyValuePair<string, object>> settings): this()
        { 
            foreach (var s in settings)
                _properties.Add(s.Key, s.Value);
        }

        /// <summary>
        /// Creates an empty PrimeParameters object
        /// </summary>
        public PrimeParameters()
        {
            _properties = new Dictionary<string, object>();
        }

        /// <summary>
        /// Get a setting as String
        /// </summary>
        /// <param name="name">Setting name</param>
        /// <returns>Setting value</returns>
        public string GetValue(string name)
        {
            if(_properties.ContainsKey(name))
                return _properties[name] as string ?? string.Empty;
            return string.Empty;
        }

        /// <summary>
        /// Get a setting as True/False
        /// </summary>
        /// <param name="name"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public bool GetFlag(string name, bool defaultValue=false)
        {
            if (_properties.ContainsKey(name))
                return (bool) _properties[name];
            return defaultValue;
        }

        /// <summary>
        /// Get a setting as an specific type
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="name">Setting name</param>
        /// <param name="defaultValue">Default value if setting is null or not found</param>
        /// <returns>Setting value</returns>
        public T GetSetting<T>(string name, T defaultValue)
        {
            return (T) GetObject(name, defaultValue);
        }

        /// <summary>
        /// Get a setting object
        /// </summary>
        /// <param name="name">Setting name</param>
        /// <param name="defaultValue">Default value if setting is null or not found</param>
        /// <returns>Setting value</returns>
        public object GetObject(string name, object defaultValue)
        {
            if (_properties.ContainsKey(name))
                    return _properties[name];
            return defaultValue;
        }
    }
}
