using System.Text.RegularExpressions;
using Moe.Rövarspråket.TranslatorConsole.Config;

namespace Moe.Rövarspråket.TranslatorConsole.Decoders
{
    public class RövarspråketRegexDecoder
    {
        public string Decode(string input)
        {
            return Regex.Replace(input, $"([{RövarspråketConfig.Consonants}]){RövarspråketConfig.Filler}\\1", c => c.Value[0].ToString(), RegexOptions.IgnoreCase);
        }
    }
}