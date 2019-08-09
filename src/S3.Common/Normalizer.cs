using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace S3.Common
{
    public class Normalizer
    {
        public static string NormalizeSpaces(string input)
        {
            // Trim and replace excess white spaces with a single space in the new name before checking
            return Regex.Replace(input.Trim(), " {2,}", " ");
        }
    }
}