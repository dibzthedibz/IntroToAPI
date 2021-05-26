using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Yoda_Translator.Translators;


namespace Yoda_Translator
{
    class TranslatorService
    {
        private readonly HttpClient _client = new HttpClient();
        public async Task<T> GetAsync<T>(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                T content = await response.Content.ReadAsAsync<T>();
                return content;
            }

            return default;
            //return null;
        }

        //public async Task<Contents> SendTextAsync(string query)
        //{
        //    Uri uri = new Uri("http://funtranslations.com/api/yoda.json?text=" + query);
        //    return uri;
        //}

        public async Task<Contents> GetTranslation(string query)
        {
            HttpResponseMessage response = await _client.GetAsync($"https://funtranslations.com/api/yoda.json?text={query}");

            if (response.IsSuccessStatusCode)
            {
                Contents content = await response.Content.ReadAsAsync<Contents>();
                return content;
            }
            return default;
        }


        //public async Task<T> PostAsync<T>(string url)
        //{

        //    Contents contents = new Contents();
        //    contents.Text = "Here We Go Again."
        //    HttpResponseMessage response = await _client.PostAsync(url);
        //}







       
       

    }
}
