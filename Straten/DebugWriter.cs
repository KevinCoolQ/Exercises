using System.Diagnostics;

namespace Straten
{
    /// <summary>
    /// Method WriteLine only exists in Debug mode
    /// </summary>
    public static class DebugWriter
    {
        [Conditional("DEBUG")]
        public static void WriteLine(string m)
        {
            System.Console.WriteLine(m);
        }
    }
}
