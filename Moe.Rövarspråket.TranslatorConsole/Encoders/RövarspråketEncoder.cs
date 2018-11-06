using System.Linq;
using System.Text;

namespace Moe.Rövarspråket.TranslatorConsole.Encoders
{
    public class RövarspråketEncoder : IRövarspråketEncoder
    {
        private readonly char[] _consonants = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

        public string Encode(string input)
        {
            var builder = new StringBuilder();

            foreach (var character in input)
            {
                builder.Append(character);

                var lowerCaseChar = char.ToLower(character);
                if (_consonants.Contains(lowerCaseChar))
                    builder.AppendFormat("o" + lowerCaseChar);
            }

            return builder.ToString();
        }
    }
}