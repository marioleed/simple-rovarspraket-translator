using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moe.Rövarspråket.TranslatorConsole.Decoders;

namespace Moe.Rövarspråket.UnitTests
{
    [TestClass]
    public class DecoderTests
    {
        [DataTestMethod]
        [DataRow("bob", "b")]
        [DataRow("ror", "r")]
        [DataRow("sos", "s")]
        [DataRow("jojagog totalolaror rorövovarorsospoproråkoketot", "jag talar rövarspråket")]
        public void When_string_contains_rövarspråk_Then_it_should_decode_consonants(string input, string output)
        {
            var decoder = new RövarspråketRegexDecoder();
            var result = decoder.Decode(input);

            Assert.AreEqual(output, result);
        }

        [DataTestMethod]
        [DataRow("Bob", "B")]
        [DataRow("Hohelollolo", "Hello")]
        [DataRow("Jojagog totalolaror Rorövovarorsospoproråkoketot!", "Jag talar Rövarspråket!")]
        [DataRow("I'mom sospopeakokinongog Rorobobboberor'sos lolanongoguagoge!", "I'm speaking Robber's language!")]
        [DataRow("Totrore Kokrorononoror äror vovärorloldodenonsos bobäsostota isoshohocockokeylolagog.", "Tre Kronor är världens bästa ishockeylag.")]
        [DataRow("Vovåror kokunongog äror cocoololarore änon eror kokunongog.", "Vår kung är coolare än er kung.")]
        public void When_string_contains_rövarspråk_with_uppercase_Then_it_should_decode_consonants_to_uppercase(string input, string output)
        {
            var decoder = new RövarspråketRegexDecoder();
            var result = decoder.Decode(input);

            Assert.AreEqual(output, result);
        }

        [DataTestMethod]
        [DataRow("yo")]
        [DataRow(":-)")]
        [DataRow("aeiou yåäö")]
        [DataRow("!#¤%&/()=?`´")]
        [DataRow("")]
        public void When_string_contains_no_rövarspråk_Then_it_should_return_the_same_string(string input)
        {
            var decoder = new RövarspråketRegexDecoder();
            var result = decoder.Decode(input);

            Assert.AreEqual(input, result);
        }
    }
}
