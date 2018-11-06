using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moe.Rövarspråket.TranslatorConsole.Encoders;

namespace Moe.Rövarspråket.UnitTests
{
    [TestClass]
    public class EncoderTests
    {
        private readonly IRövarspråketEncoder _encoder;

        public EncoderTests()
        {
            //_encoder = new RövarspråketEncoder();
            _encoder = new RövarspråketRegexEncoder();
        }

        [DataTestMethod]
        [DataRow("b", "bob")]
        [DataRow("r", "ror")]
        [DataRow("s", "sos")]
        [DataRow("jag talar rövarspråket", "jojagog totalolaror rorövovarorsospoproråkoketot")]
        public void When_string_contains_consonants_Then_it_should_encode_consonants(string input, string output)
        {
            var result = _encoder.Encode(input);

            Assert.AreEqual(output, result);
        }

        [DataTestMethod]
        [DataRow("B", "Bob")]
        [DataRow("Hello", "Hohelollolo")]
        [DataRow("Jag talar Rövarspråket!", "Jojagog totalolaror Rorövovarorsospoproråkoketot!")]
        [DataRow("I'm speaking Robber's language!", "I'mom sospopeakokinongog Rorobobboberor'sos lolanongoguagoge!")]
        [DataRow("Tre Kronor är världens bästa ishockeylag.", "Totrore Kokrorononoror äror vovärorloldodenonsos bobäsostota isoshohocockokeylolagog.")]
        [DataRow("Vår kung är coolare än er kung.", "Vovåror kokunongog äror cocoololarore änon eror kokunongog.")]
        public void When_string_contains_uppercase_consonants_Then_it_should_lowercase_last_consonant(string input, string output)
        {
            var result = _encoder.Encode(input);

            Assert.AreEqual(output, result);
        }

        [DataTestMethod]
        [DataRow("yo")]
        [DataRow(":-)")]
        [DataRow("aeiou yåäö")]
        [DataRow("!#¤%&/()=?`´")]
        [DataRow("")]
        public void When_string_contains_no_consonants_Then_it_should_return_the_same_string(string input)
        {
            var result = _encoder.Encode(input);

            Assert.AreEqual(input, result);
        }
    }
}
