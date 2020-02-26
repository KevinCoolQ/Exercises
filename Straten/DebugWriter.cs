using System.Diagnostics;

namespace Straten
{
    public static class DebugWriter
    {
        [Conditional("DEBUG")]
        public static void WriteLine(string m)
        {
            System.Console.WriteLine(m);
        }
    }
}
