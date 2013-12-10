namespace PrimeLib
{
    /// <summary>
    /// Destinations for the Usb file
    /// </summary>
    public enum Destinations
    {
        /// <summary>
        /// Physical device
        /// </summary>
        Calculator, 
        /// <summary>
        /// Connectivity Kit folder (if available)
        /// </summary>
        UserFolder,
        /// <summary>
        /// Custom destination
        /// </summary>
        Custom
    }
}