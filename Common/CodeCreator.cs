using System;
using System.Linq;

namespace Functions
{
    public class CodeCreator
    {
        private static Random random = new Random();

        public static string CreateCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!.";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
