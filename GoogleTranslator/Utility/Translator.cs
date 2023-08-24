using Google.Cloud.Translation.V2;

namespace GoogleTranslator.Utility
{
    public class Translator : ITranslator
    {
        private readonly TranslationClient client;
        public Translator()
        {
            client = TranslationClient.Create();
        }
        public async Task<string> TranslateHtml(string text, string language)
        {
            var response = client.TranslateHtml(text, language);
            return response.TranslatedText;
        }
        public async Task<string> TranslateText(string text, string language)
        {
            var response = client.TranslateText(text, language);
            return response.TranslatedText;
        }
    }
}
