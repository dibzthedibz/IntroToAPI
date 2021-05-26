using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yoda_Translator.Translators;


namespace Yoda_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            TranslatorService service = new TranslatorService();
            HttpResponseMessage response = httpClient.GetAsync("https://funtranslations.com/api/yoda").Result;

            if (response.IsSuccessStatusCode)
            {
                var translated = service.GetTranslation("John is eating an apple").Result;
                Console.WriteLine(translated);

            }
            Console.WriteLine("Press Any Key To Continue...");
            Console.ReadLine();
        }
    }
}
