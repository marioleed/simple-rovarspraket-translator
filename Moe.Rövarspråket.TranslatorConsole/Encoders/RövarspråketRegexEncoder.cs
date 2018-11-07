using System.Text.RegularExpressions;
using Moe.Rövarspråket.TranslatorConsole.Config;

namespace Moe.Rövarspråket.TranslatorConsole.Encoders
{
    public class RövarspråketRegexEncoder : IRövarspråketEncoder
    {
        public string Encode(string input)
        {
            string Evaluator(Match c) => c.Value + RövarspråketConfig.Filler + c.Value.ToLower();

            return Regex.Replace(input, $"([{RövarspråketConfig.Consonants}])", Evaluator, RegexOptions.IgnoreCase);
        }
    }
}