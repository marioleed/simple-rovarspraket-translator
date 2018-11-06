using System.Text.RegularExpressions;

namespace Moe.Rövarspråket.TranslatorConsole.Encoders
{
    public class RövarspråketRegexEncoder : IRövarspråketEncoder
    {
        public string Encode(string input)
        {
            return Regex.Replace(input, "([bcdfghjklmnpqrstvwxz])", c => c.Value + "o" + c.Value.ToLower(), RegexOptions.IgnoreCase);
        }
    }
}