using System.Text.RegularExpressions;

namespace Moe.Rövarspråket.TranslatorConsole.Decoders
{
    public class RövarspråketRegexDecoder
    {
        public string Decode(string input)
        {
            return Regex.Replace(input, "([bcdfghjklmnpqrstvwxz])o\\1", c => c.Value[0].ToString(), RegexOptions.IgnoreCase);
        }
    }
}