using System.Linq;
using System.Text;
using Moe.Rövarspråket.TranslatorConsole.Config;

namespace Moe.Rövarspråket.TranslatorConsole.Encoders
{
    public class RövarspråketEncoder : IRövarspråketEncoder
    {
        private readonly char[] _consonants = RövarspråketConfig.Consonants.ToCharArray();

        public string Encode(string input)
        {
            var builder = new StringBuilder();

            foreach (var character in input)
            {
                builder.Append(character);

                var lowerCaseChar = char.ToLower(character);
                if (_consonants.Contains(lowerCaseChar))
                    builder.AppendFormat(RövarspråketConfig.Filler + lowerCaseChar);
            }

            return builder.ToString();
        }
    }
}